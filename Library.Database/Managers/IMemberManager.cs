using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Library.DataModel.Business;

namespace Library.Database.Managers
{
    public interface IMemberManager : IDisposable
    {
        Member GetMember(int memberNumber);
        IEnumerable<Member> GetMembers();
        Member SetMember(Member member);
        void DeleteMember(int memberNumber);
    }
}
