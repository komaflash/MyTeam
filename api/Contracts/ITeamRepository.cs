using MyTeam.Contracts;
using MyTeam.Entities;

namespace MyTeam.Contracts
{
    public interface ITeamRepository : IRepository<Team>
    {
        // team specific methods go here
        // for example
        // Team GetLargesTeam()
    }
}