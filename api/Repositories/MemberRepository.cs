using MyTeam.Contracts;
using MyTeam.Entities;

namespace MyTeam.Repositories
{
    public class MemberRepository : Repository<Member>, IMemberRepository
    {
        private readonly AppDbContext context;

        public MemberRepository(AppDbContext context) : base(context)
        {
            this.context = context;
        }
    }
}