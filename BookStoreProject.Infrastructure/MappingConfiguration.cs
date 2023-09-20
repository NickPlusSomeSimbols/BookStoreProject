using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mapster;
using WA.Pizza.Core.Model;
using WA.Pizza.Infrastructure.Dtos;
using WA.Pizza.Infrastructure.Dtos.Basket;
using WA.Pizza.Infrastructure.Dtos.Catalog;
using WA.Pizza.Infrastructure.Dtos.Order;

namespace WA.Pizza.Infrastructure
{
    public class MappingConfiguration
    {
        public static void Configure()
        {
            //CATALOG
            TypeAdapterConfig<CatalogItem, BasketItem>.NewConfig()
                .Ignore(d => d.Id)
                .Ignore(d => d.Quantity)
                .Map(d => d.Name, s => s.Name)
                .Map(d => d.Price, s => s.Price);
            TypeAdapterConfig<CatalogItem, BasketItemDto>.NewConfig()
                .Ignore(d => d.Id)
                .Map(d => d.Name, s => s.Name)
                .Map(d => d.Price, s => s.Price)
                .Map(d => d.CatalogItemId, s => s.Id);
            TypeAdapterConfig<CatalogItem, CatalogItemDto>.NewConfig()
                .Map(d => d.Id, s => s.Id)
                .Map(d => d.Name, s => s.Name)
                .Map(d => d.Description, s => s.Description)
                .Map(d => d.Price, s => s.Price)
                .Map(d => d.Quantity, s => s.Quantity);
            TypeAdapterConfig<CatalogItemDto, CatalogItem>.NewConfig()
                .Map(d => d.Name, s => s.Name)
                .Map(d => d.Description, s => s.Description)
                .Map(d => d.Price, s => s.Price)
                .Map(d => d.Quantity, s => s.Quantity);
            //BASKET
            TypeAdapterConfig<Basket, BasketDto>.NewConfig()
                .Map(d => d.Id, s => s.Id)
                .Map(d => d.Items, s => s.Items);
            TypeAdapterConfig<Basket, Order>.NewConfig()
                .Ignore(d => d.Id)
                .Map(d => d.Date, s => DateTime.Now)
                .Map(d => d.Items, s => s.Items)
                .Map(d => d.State, s => OrderState.NextUp);
            TypeAdapterConfig<BasketDto, Basket>.NewConfig()
                .Map(d => d.Items, s => s.Items);
            TypeAdapterConfig<BasketItem, BasketItemDto>.NewConfig()
                .Map(d => d.Id, s => s.Id)
                .Map(d => d.Name, s => s.Name)
                .Map(d => d.Price, s => s.Price)
                .Map(d => d.Quantity, s => s.Quantity)
                .Map(d => d.BasketId, s => s.BasketId)
                .Map(d => d.CatalogItemId, s => s.CatalogItemId);
            TypeAdapterConfig<BasketItem, OrderItem>.NewConfig()
                .Ignore(d => d.Id)
                .Map(d => d.Name, s => s.Name)
                .Map(d => d.Price, s => s.Price)
                .Map(d => d.Quantity, s => s.Quantity);
            TypeAdapterConfig<BasketItemDto, BasketItem>.NewConfig()
                .Map(d => d.Name, s => s.Name)
                .Map(d => d.Price, s => s.Price)
                .Map(d => d.Quantity, s => s.Quantity)
                .Map(d => d.BasketId, s => s.BasketId)
                .Map(d => d.CatalogItemId, s => s.CatalogItemId);
            //ORDER
            TypeAdapterConfig<Order, OrderDto>.NewConfig()
                .Map(d => d.Id, s => s.Id)
                .Map(d => d.Date, s => s.Date)
                .Map(d => d.Price, s => s.Price)
                .Map(d => d.Items, s => s.Items)
                .Map(d => d.State, s => s.State);
            TypeAdapterConfig<OrderDto, Order>.NewConfig()
                .Map(d => d.Date, s => s.Date)
                .Map(d => d.Price, s => s.Price)
                .Map(d => d.Items, s => s.Items)
                .Map(d => d.State, s => s.State);
            TypeAdapterConfig<OrderItem, OrderItemDto>.NewConfig()
                .Map(d => d.Id, s => s.Id)
                .Map(d => d.Name, s => s.Name)
                .Map(d => d.Price, s => s.Price)
                .Map(d => d.Quantity, s => s.Quantity)
                .Map(d => d.OrderId, s => s.OrderId);
            TypeAdapterConfig<OrderItemDto, OrderItem>.NewConfig()
                .Map(d => d.Name, s => s.Name)
                .Map(d => d.Price, s => s.Price)
                .Map(d => d.Quantity, s => s.Quantity)
                .Map(d => d.OrderId, s => s.OrderId);

            //OTHER
            TypeAdapterConfig<AddBasketItemRequest, BasketItem>.NewConfig()
                .Map(d => d.Quantity, s => s.Quantity)
                .Map(d => d.BasketId, s => s.BasketId)
                .Map(d => d.CatalogItemId, s => s.CatalogItemId);

        }
    }
}
