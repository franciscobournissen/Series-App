using AutoMapper;
using SeriesApp.Books;

namespace SeriesApp;

public class SeriesAppApplicationAutoMapperProfile : Profile
{
    public SeriesAppApplicationAutoMapperProfile()
    {
        CreateMap<Book, BookDto>();
        CreateMap<CreateUpdateBookDto, Book>();
        /* You can configure your AutoMapper mapping configuration here.
         * Alternatively, you can split your mapping configurations
         * into multiple profile classes for a better organization. */
    }
}
