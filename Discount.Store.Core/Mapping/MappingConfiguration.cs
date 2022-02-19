using AutoMapper;

using Discount.Store.Core.Dtos;
using Discount.Store.Core.CartAggregate;

namespace Discount.Store.Core.Mapping
{
    public static class MappingConfiguration
    {
        private static bool initialized;

        public static IMapper MapperInstance { get; set; }

        public static void RegisterMappings()
        {
            if (initialized)
            {
                return;
            }

            initialized = true;

            var config = new MapperConfigurationExpression();
            config.CreateMap<CartItem, CartItemDto>();
            config.CreateMap<CartItemDto, CartItem>();
        }
    }
}
