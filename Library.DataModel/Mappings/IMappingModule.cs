using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.DataModel.Mappings
{
    public interface IMappingModule
    {
        /// <summary>
        /// Registers object mapping rules for this module.
        /// </summary>
        void Register();
    }
}
