﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntityFramework.Patterns;
using Library.DataModel.Entities;

namespace Library.Database.Repostories
{
    public class MemberRepository: GenericRepository<MemberEntity>
    {
        public MemberRepository(IObjectSetFactory factory) 
            : base(factory)
        {
        }
    }
}
