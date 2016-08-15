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
    public class MemberMappingModule: IMappingModule
    {
        public void Register()
        {
            Mapper.CreateMap<MemberEntity, Member>()
               .ForMember(m => m.Number, opt => opt.MapFrom(me => me.Number))
               .ForMember(m => m.Adress, opt => opt.MapFrom(me => me.Adress))
               .ForMember(m => m.FirstName, opt => opt.MapFrom(me => me.FirstName))
               .ForMember(m => m.LastName, opt => opt.MapFrom(me => me.LastName))
               .ForMember(m => m.Status, opt => opt.MapFrom(me => me.Status));

            Mapper.CreateMap<Member, MemberEntity>()
                .ForMember(me => me.Number, opt => opt.MapFrom(m => m.Number))
                .ForMember(me => me.Adress, opt => opt.MapFrom(m => m.Adress))
                .ForMember(me => me.FirstName, opt => opt.MapFrom(m => m.FirstName))
                .ForMember(me => me.LastName, opt => opt.MapFrom(m => m.LastName))
                .ForMember(me => me.Status, opt => opt.MapFrom(m => m.Status))
                .ForMember(me => me.Loans, opt => opt.Ignore());
        }
    }
}
