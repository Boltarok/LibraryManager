using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Library.DataModel.Business;
using Library.DataModel.Entities;

namespace Library.DataModel.Mappings
{
    public class BookMappingModule : IMappingModule
    {
        public void Register()
        {
            Mapper.CreateMap<BookEntity, Book>()
                .ForMember(b => b.Code, opt => opt.MapFrom(be => be.Code))
                .ForMember(b => b.AmmountAvailable, opt => opt.MapFrom(be => be.AmmountAvailable))
                .ForMember(b => b.Status, opt => opt.MapFrom(be => be.Status))
                .ForMember(b => b.Title, opt => opt.MapFrom(be => be.Title));

            Mapper.CreateMap<Book, BookEntity>()
                .ForMember(be => be.Code, opt => opt.MapFrom(b => b.Code))
                .ForMember(be => be.AmmountAvailable, opt => opt.MapFrom(b => b.AmmountAvailable))
                .ForMember(be => be.Status, opt => opt.MapFrom(b => b.Status))
                .ForMember(be => be.Title, opt => opt.MapFrom(b => b.Title))
                .ForMember(be => be.Loans, opt => opt.Ignore());
        }
    }
}
