using MyTeam.Contracts;
using MyTeam.Entities;

namespace MyTeam.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AppDbContext context;

        public ITeamRepository Teams { get; }
        public IMemberRepository Members { get; }

        public UnitOfWork(AppDbContext context)
        {
            this.context = context;
            Teams = new TeamRepository(context);
            Members = new MemberRepository(context);
        }

        public int SaveChanges()
        {
            return context.SaveChanges();
        }

        public void Dispose()
        {
            context.Dispose();
        }
    }
}