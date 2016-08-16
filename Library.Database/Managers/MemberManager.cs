using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntityFramework.Patterns;
using Library.Database.Repostories;
using Library.DataModel.Business;
using Library.DataModel.Entities;
using Library.DataModel.Mappings;

namespace Library.Database.Managers
{
    public class MemberManager: BaseManager, IMemberManager
    {
        protected MemberRepository Members;
        public MemberManager(DataModelContext dbContext)
        {
            if (dbContext == null)
            {
                throw new ArgumentNullException(nameof(dbContext), "The data container cannot be undefined");
            }

            DbContext = dbContext;
            ContextAdapter = new DbContextAdapter(dbContext);
            Members = new MemberRepository(ContextAdapter);
        }
        public void Dispose()
        {
            if (ContextAdapter != null)
            {
                ContextAdapter.Dispose();
                ContextAdapter = null;
            }

            DbContext = null;
            Members = null;
        }

        public Member GetMember(int memberNumber)
        {
            var member = Members.FirstOrDefault(me => me.Number.Equals(memberNumber));
            return member?.Map<MemberEntity, Member>();
        }

        public IEnumerable<Member> GetMembers()
        {
            return Members.GetAll().Map<MemberEntity, Member>();
        }

        public Member SetMember(Member member)
        {
            try
            {
                // Validate parameters.
                if (member == null)
                {
                    throw new ArgumentNullException(nameof(member), "Cannot set an undefined member");
                }

                var memberEntity = Members.FirstOrDefault(le => le.Number.Equals(member.Number));
                if (memberEntity == null)
                {
                    // Insert a new entity.

                    memberEntity = member.Map<Member, MemberEntity>();

                    Members.Insert(memberEntity);
                    ContextAdapter.SaveChanges();

                }
                else
                {
                    // Update an existing entity.
                    Mappings.Map(member, memberEntity);
                    Members.Update(memberEntity);
                    ContextAdapter.SaveChanges();

                }

                return memberEntity.Map<MemberEntity, Member>();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void DeleteMember(int memberNumber)
        {
            // Find the member.
            var member = Members.FirstOrDefault(me => me.Number.Equals(memberNumber));
            if (member == null)
            {
                throw new ArgumentException($"Could not find any Member with the Number '{memberNumber}' to delete.");
            }

            // Delete the member.
            Members.Delete(member);
            ContextAdapter.SaveChanges();
        }
    }
}
