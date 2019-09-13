using MyTeam.Contracts;
using MyTeam.Entities;
using MyTeam.Repositories;

namespace MyTeam.Repositories
{
    public class TeamRepository : Repository<Team>, ITeamRepository
    {
        private readonly AppDbContext context;

        public TeamRepository(AppDbContext context) : base(context)
        {
            this.context = context;
        }
    }
}