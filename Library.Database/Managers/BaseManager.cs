using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntityFramework.Patterns;
using Library.DataModel.Entities;

namespace Library.Database.Managers
{
    public abstract class BaseManager
    {
        protected DbContextAdapter ContextAdapter;
        protected DataModelContext DbContext;
    }
}
