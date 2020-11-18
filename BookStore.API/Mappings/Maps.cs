using AutoMapper;
using BookStore.API.DTOs;
using BookStore.API.Models;

namespace BookStore.API.Mappings
{
    public class Maps : Profile
    {
        public Maps()
        {
            CreateMap<Author, AuthorDTO>().ReverseMap();
            CreateMap<Book, BookDTO>().ReverseMap();
        }

    }
}