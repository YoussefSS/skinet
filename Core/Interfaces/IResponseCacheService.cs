namespace Core.Interfaces
{
    public interface IResponseCacheService
    {
        // When we receive a response from the database, we'll cache that in its entirety to our memory (redis) for a certain amount of time
        Task CacheResponseAsync(string cacheKey, object response, TimeSpan timeToLive);
        Task<string> GetCachedResponseAsync(string cacheKey);
    }
}