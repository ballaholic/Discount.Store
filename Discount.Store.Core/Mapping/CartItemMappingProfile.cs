using AutoMapper;

using Discount.Store.Core.Dtos;
using Discount.Store.Core.CartAggregate;

namespace Discount.Store.Core.Mapping
{
    public class CartItemMappingProfile : Profile
    {
        public CartItemMappingProfile()
        {
            CreateMap<CartItemDto, CartItem>();
        }
    }
}
