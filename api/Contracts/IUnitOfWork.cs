using System;
using MyTeam.Contracts;

namespace MyTeam.Contracts
{
    public interface IUnitOfWork : IDisposable
    {
        ITeamRepository Teams { get; }
        IMemberRepository Members { get; }
        int SaveChanges();
    }
}