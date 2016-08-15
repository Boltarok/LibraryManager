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
    public class LoanMappingModule: IMappingModule
    {
        public void Register()
        {
            Mapper.CreateMap<LoanEntity, Loan>()
               .ForMember(l => l.Number, opt => opt.MapFrom(le => le.Number))
               .ForMember(l => l.BookCode, opt => opt.MapFrom(le => le.BookCode))
               .ForMember(l => l.LoanDate, opt => opt.MapFrom(le => le.LoanDate))
               .ForMember(l => l.MemberNumber, opt => opt.MapFrom(le => le.MemberNumber));

            Mapper.CreateMap<Loan, LoanEntity>()
               .ForMember(le => le.Number, opt => opt.MapFrom(l => l.Number))
               .ForMember(le => le.BookCode, opt => opt.MapFrom(l => l.BookCode))
               .ForMember(le => le.LoanDate, opt => opt.MapFrom(l => l.LoanDate))
               .ForMember(le => le.MemberNumber, opt => opt.MapFrom(l => l.MemberNumber))
               .ForMember(le => le.Book, opt => opt.Ignore())
               .ForMember(le => le.Member, opt => opt.Ignore());
        }
    }
}
