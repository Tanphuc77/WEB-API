using AutoMapper;
using WebAPI.Data;
using WebAPI.Models;

namespace WebAPI.Helpers
{
    public class ApplicationMapper : Profile
    {
        public ApplicationMapper() 
        {
            CreateMap<Book,BookModel>().ReverseMap();
        }

    }
}
