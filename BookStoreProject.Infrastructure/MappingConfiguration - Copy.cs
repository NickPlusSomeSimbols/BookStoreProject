using AutoMapper;
using BookStoreProjectCore.Model;
using BookStoreProjectInfrastructure.Dtos.Author;
using BookStoreProjectInfrastructure.Dtos.Basket;
using BookStoreProjectInfrastructure.Dtos.Book;

public class AppMappingProfile : Profile
{
	public AppMappingProfile()
	{
		CreateMap<Book, BookDto>().ReverseMap();
        CreateMap<Book, CreateBookDto>();
        CreateMap<Book, UpdateBookDto>();

        CreateMap<Author, AuthorDto>();
        CreateMap<Author, CreateAuthorDto>();
        CreateMap<Author, UpdateAuthorDto>();

        CreateMap<AddBasketItemDto, BasketItem>();
        CreateMap<BasketItemDto, BasketItem>();
        CreateMap<UpdateBasketItemDto, BasketItem>();
    }
}