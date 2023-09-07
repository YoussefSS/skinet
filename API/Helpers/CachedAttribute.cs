using System.Text;
using Core.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace API.Helpers
{
    // Filters allow code to be ran before or after specific stages in the request processing pipeline
    public class CachedAttribute : Attribute, IAsyncActionFilter
    {
        private readonly int _timeToLiveSeconds;
        public CachedAttribute(int timeToLiveSeconds)
        {
            _timeToLiveSeconds = timeToLiveSeconds;
        }

        // From the IAsyncActionFilterInterface
        public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            /*
            *   This will run immediately before an action method in our controller is called. 
            *   This is our opportunity to check if the request is already in our cache or not
            *
            *   To move onto the controller step, we have to call next()
            *
            *   We can execute code after the request has been passed onto our controller and processed
            *   This is our opportunity to cache the result to be used later!
            */

            // Cannot inject dependencies in attributes, we use this to get the service we need instead
            var cacheService = context.HttpContext.RequestServices.GetRequiredService<IResponseCacheService>();

            // Generating the key
            var cacheKey = GenerateCacheKeyFromRequest(context.HttpContext.Request);
            var cachedResponse = await cacheService.GetCachedResponseAsync(cacheKey);

            // We found something that matches in our cache!
            if (!string.IsNullOrEmpty(cachedResponse))
            {
                var contentResult = new ContentResult
                {
                    // We'll do this instead of letting the request go to our controllers action method
                    Content = cachedResponse,
                    ContentType = "application/json",
                    StatusCode = 200
                };

                context.Result = contentResult;

                return;
            }

            // We didn't find anything that matches in our cache
            // So we'll move the request onto the controller
            var executedContext = await next();

            // Now the request is finished in our controller, we want to add the result to the cache!
            if (executedContext.Result is OkObjectResult okObjectResult)
            {
                await cacheService.CacheResponseAsync(cacheKey, okObjectResult.Value, TimeSpan.FromSeconds(_timeToLiveSeconds));
            }
        }

        private string GenerateCacheKeyFromRequest(HttpRequest request)
        {
            var keyBuilder = new StringBuilder();

            keyBuilder.Append($"{request.Path}");

            // For query strings, we want to sort them in a predictable order so that we always get the same key
            foreach (var (key, value) in request.Query.OrderBy(x => x.Key))
            {
                keyBuilder.Append($"|{key}-{value}"); // pipe '|' has no meaning, we're just using it to separate values       
            }

            return keyBuilder.ToString();
        }
    }
}