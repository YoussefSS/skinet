using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Dtos;
using AutoMapper;
using Core.Entities;
using Core.Entities.Identity;

namespace API.Helpers
{

    // Maps objects. Useful for AutoMapper
    public class MappingProfiles : Profile // Profile is an AutoMapper class
    {
        public MappingProfiles()
        {
            // CreateMap looks at the names of properties inside Product, and is going to try to map them
            // to what's inside ProductToReturnDto. As long as the names match, then we don't need to add any
            // additional configuration
            CreateMap<Product, ProductToReturnDto>()
                .ForMember(d => d.ProductBrand, o => o.MapFrom(s => s.ProductBrand.Name)) // Set the ProductBrand on the Dto to ProductBrand.Name on Product
                .ForMember(d => d.ProductType, o => o.MapFrom(s => s.ProductType.Name))
                .ForMember(d => d.PictureUrl, o => o.MapFrom<ProductUrlResolver>());

            // no need to do anything extra as the property names are the exact same
            // Reverse map also maps AddressDto to Address
            CreateMap<Address, AddressDto>().ReverseMap();

            CreateMap<CustomerBasketDto, CustomerBasket>();
            CreateMap<BasketItemDto, BasketItem>();

            // Address in our order aggregate, using full namespace so it doesn't conflict with the other 'Address' from identity
            CreateMap<AddressDto, Core.Entities.OrderAggregate.Address>();
        }
    }
}