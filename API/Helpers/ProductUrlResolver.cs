using API.Dtos;
using AutoMapper;
using Core.Entities;
using Microsoft.Extensions.Configuration;

namespace API.Helpers
{
    // Map from Product to ProductToReturnDto, and the url is going to be a string
    public class ProductUrlResolver : IValueResolver<Product, ProductToReturnDto, string>
    {
        private readonly IConfiguration _config;
        public ProductUrlResolver(IConfiguration config) // IConfiguration from Microsoft.Extensions.Configuration
        {
            _config = config;
        }

        public string Resolve(Product source, ProductToReturnDto destination, string destMember, ResolutionContext context)
        {
            if (!string.IsNullOrEmpty(source.PictureUrl))
            {
                return _config["ApiUrl"] + source.PictureUrl; // ApiUrl is in appsettings.Development.json
            }

            return null; // likely will never be reached as the pictureUrl is not nullable
        }
    }
}