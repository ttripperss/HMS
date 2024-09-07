using HMS.Models;

namespace HMS.Abstractions
{
    public class IMemberService
    {
        internal void AddMember(Member member)
        {
            throw new NotImplementedException();
        }

        internal void DeleteMember(int id)
        {
            throw new NotImplementedException();
        }

        internal Member? GetMemberById(int id)
        {
            throw new NotImplementedException();
        }

        Task<List<Member>> GetMembers()
        {
            throw new NotImplementedException();
        }
    }
}
