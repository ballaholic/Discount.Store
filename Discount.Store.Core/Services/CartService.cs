using AutoMapper;

using Discount.Store.Core.CartAggregate;
using Discount.Store.Core.Dtos;
using Discount.Store.Core.Interfaces;
using Discount.Store.Core.ItemAggregate;
using Discount.Store.SharedKernel.Interfaces;

using System.Collections.Generic;
using System.Threading.Tasks;

namespace Discount.Store.Core.Services
{
    public class CartService : ICartService
    {
        private readonly IRepository<Cart> cartRepository;
        private readonly IRepository<Item> itemRepository;
        private readonly IJunctionEntityRepository<CartItem> cartItemRepository;

        private readonly IMapper mapper;

        public CartService(
            IRepository<Cart> cartRepository, 
            IRepository<Item> itemRepository,
            IJunctionEntityRepository<CartItem> cartItemRepository,
            IMapper mapper)
        {
            this.cartRepository = cartRepository;
            this.itemRepository = itemRepository;
            this.cartItemRepository = cartItemRepository;
            this.mapper = mapper;
        }

        public async Task<Cart> AddItemToCart(int cartId, int itemId)
        {
            var existingCart = await this.cartRepository.GetByIdAsync(cartId);

            if (existingCart is null)
            {
                await Task.FromException<Cart>(new KeyNotFoundException($"Cart with Id {cartId} was not found."));
            }
            
            var existingItem = await this.itemRepository.GetByIdAsync(itemId);

            if (existingItem is null)
            {
                await Task.FromException<Cart>(new KeyNotFoundException($"Item with Id {itemId} was not found."));
            }

            var cartItemDto = new CartItemDto()
            {
                CartId = existingCart.Id,
                ItemId = existingItem.Id
            };

            var entity = this.mapper.Map<CartItem>(cartItemDto);

            await this.cartItemRepository.AddAsync(entity);
            await this.cartItemRepository.SaveChangesAsync();

            return existingCart;
        }
    }
}
