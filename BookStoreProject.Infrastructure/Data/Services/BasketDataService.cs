using BookStoreProjectCore;
using BookStoreProjectCore.Exceptions;
using BookStoreProjectCore.Model;
using BookStoreProjectInfrastructure.Dtos.Basket;
using Mapster;

namespace BookStoreProjectInfrastructure.Data.Services;

public class BasketDataService
{
    private readonly BookStoreDbContext _context;

    public BasketDataService(BookStoreDbContext dbContext)
    {
        _context = dbContext;
    }
    public async Task BindBuyerToBasket(string userId, int basketToBindId)
    {
        _context.Basket.FirstOrDefault(i => i.Id == basketToBindId).CustomerId = userId;

        await _context.SaveChangesAsync();
    }
    public async Task<BasketItemDto> GetItemAsync(int ItemId)
    {
        var item = await _context.BasketItem.FindAsync(ItemId);

        if (item == null)
        {
            throw new ItemNotFoundException();
        }

        var itemDto = item.Adapt<BasketItemDto>();
        return itemDto;
    }
    public async Task<int> AddItemAsync(AddBasketItemDto createRequest)
    {
        var basketItem = createRequest.Adapt<BasketItem>();

        var storage = await _context.BookStorages.FindAsync(createRequest.BookStorageId);
        var book = await _context.Books.FindAsync(basketItem.BookId);

        if(book == null || storage == null)
        {
            throw new ItemNotFoundException();
        }

        if (basketItem.Amount <= storage.Amount)
        {

            var bookSoldReport = new BookSoldReport
            {
                Date = DateTime.Now,
                Income = basketItem.Amount * _context.Books.First(i => i.Id == basketItem.BookId).Price,
                Amount = basketItem.Amount,
                SoldBookId = basketItem.BookId,
                BookStoreId = _context.BookStorages.First(i => i.Id == basketItem.BookStorageId).BookStoreId
            };

            await _context.BookSoldReports.AddAsync(bookSoldReport);
            await _context.BasketItem.AddAsync(basketItem);

            storage.Amount -= basketItem.Amount;
        }
        else
        {
            throw new Exception("Not enough books in storages");
        }

        await _context.SaveChangesAsync();

        return basketItem.Id;
    }

    public async Task<int> UpdateItemAsync(UpdateBasketItemDto updateRequest)
    {
        var basketItem = await _context.BasketItem.FindAsync(updateRequest.Id);

        if (basketItem == null)
        {
            throw new ItemNotFoundException();
        }

        var storage = await _context.BookStorages.FindAsync(basketItem.BookStorageId);
        
        if (updateRequest.Amount <= storage.Amount + basketItem.Amount)
        {
            var bookSoldReport = new BookSoldReport
            {
                Date = DateTime.Now,
                Income = basketItem.Amount * _context.Books.First(i => i.Id == basketItem.BookId).Price,
                Amount = updateRequest.Amount,
                BookStoreId = _context.BookStorages.First(i => i.Id == basketItem.BookStorageId).BookStoreId,
                SoldBookId = basketItem.BookId
            };
            
            await _context.BookSoldReports.AddAsync(bookSoldReport); // no remove canceled sell mechanism

            storage.Amount = storage.Amount - updateRequest.Amount + basketItem.Amount;
            basketItem.Amount = updateRequest.Amount;
            
        }
        else
        {
            throw new Exception("Not enough books in storages");
        }

        await _context.SaveChangesAsync();
        
        return basketItem.Id;
    }

    public async Task<bool> DeleteBasketItemAsync(int basketItemId)
    {
        var basketItem = await _context.BasketItem.FindAsync(basketItemId);

        if (basketItem == null)
        {
            throw new ItemNotFoundException();
        }

        _context.BasketItem.Remove(basketItem);
        _context.SaveChanges();

        return true;
    }
}