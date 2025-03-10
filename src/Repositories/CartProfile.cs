using AutoMapper;
using CartService.Domain.Entities;
using CartService.Domain.Models;

namespace CartService.Repositories
{
    public class CartProfile : Profile
    {
        public CartProfile()
        {
            CreateMap<Domain.Entities.Cart, CartModel>();
            CreateMap<CartModel, Domain.Entities.Cart>();
            CreateMap<Domain.Entities.CartItem, CartItemModel>();
            CreateMap<CartItemModel, Domain.Entities.CartItem>();
        }
    }
}
