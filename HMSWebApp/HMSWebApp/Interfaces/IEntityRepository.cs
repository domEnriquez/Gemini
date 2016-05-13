using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web;
using HMSWebApp.Models;

namespace HMSWebApp.Interfaces
{

    public interface IVoteEntryInterface : IEntityRepository<VoteEntry>
    {
    }

    public interface IVoterRepository : IEntityRepository<Voter>
    {
    }

    public interface IPaymentRepository : IEntityRepository<Payment>
    {
    }

    public interface ITeamRepository : IEntityRepository<Team>
    {
    }

    public interface IEntityRepository<T> : IDisposable
    {
        IQueryable<T> All { get; }
        //IQueryable<T> AllIncluding(params Expression<Func<T, object>>[] includeProperties);
        IQueryable<T> AllIncluding(string[] includeProperties);
        T SingleIncluding(int id, string[] includeProperties);
        T Find(int id);
        void InsertGraph(T entity);
        void InsertObject(T entity);
        void Update(T entity);
        void Delete(T entity);
        //void Save();
    }
}