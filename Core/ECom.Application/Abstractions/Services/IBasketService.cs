using Application.DTOs;
using ECom.Domain.Entities;

namespace ECom.Application.Abstractions.Services;

public interface IBasketService
{
    public Task<List<BasketItem>> GetBasketItemsAsync();
    public Task AddItemToBasketAsync(CreateBasketItemDto createBasketItemDto);
    public Task UpdateQuantityAsync(UpdateBasketItemDto updateBasketItemDto);
    public Task RemoveBasketItemAsync(string basketItemId);
}