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

        _context.BasketItem.Add(basketItem);

        var storage = _context.BookStorages.Find(basketItem.BookStorageId);
        var book = _context.Books.Find(basketItem.BookId);

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

            _context.BookSoldReports.Add(bookSoldReport);

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

        var replacingItem = updateRequest.Adapt<BasketItem>();
        var storage = _context.BookStorages.First(i => i.Id == basketItem.BookStorageId);

        if (replacingItem.Amount <= storage.Amount + basketItem.Amount)
        {

            var bookSoldReport = new BookSoldReport
            {
                Date = DateTime.Now,
                Income = replacingItem.Amount * _context.Books.First(i => i.Id == basketItem.BookId).Price,
                Amount = replacingItem.Amount,
            };

            _context.BookSoldReports.Add(bookSoldReport); // no remove cancelled sell mechanism

            basketItem.Amount = updateRequest.Amount;

            storage.Amount += -replacingItem.Amount + basketItem.Amount;
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