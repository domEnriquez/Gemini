using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using HMSWebApp.Interfaces;
using HMSWebApp.Models;

namespace HMSWebApp.Repository
{
    /// <summary>
    ///  Data logic class for handling add/delete/update of vote entry objects in the database
    /// </summary>
    public class VoteEntryRepository : IVoteEntryInterface
    {

        private HMSDb hmsdb;
        //HMSDb hmsdb = new HMSDb();

        public VoteEntryRepository(UnitOfWorkHms uow)
        {
            hmsdb = uow.HmsDb;
        }

        public IQueryable<VoteEntry> All
        {
            get { return hmsdb.VoteEntry; }
        }


        public IQueryable<VoteEntry> AllIncluding(string[] includeProperties)
        {
            IQueryable<VoteEntry> query = hmsdb.VoteEntry;
            foreach (var includeProperty in includeProperties)
            {
                query = query.Include(includeProperty);
            }
            return query;
        }

        public VoteEntry SingleIncluding(int id, string[] includeProperties)
        {
            IQueryable<VoteEntry> query = hmsdb.VoteEntry;
            foreach (var includeProperty in includeProperties)
            {
                query = query.Include(includeProperty);
            }
            return query.FirstOrDefault(voteEntry => voteEntry.Id == id);
        }

        //public IQueryable<VoteEntry> AllIncluding(params Expression<Func<VoteEntry, object>>[] includeProperties)
        //{
        //    IQueryable<VoteEntry> query = hmsdb.VoteEntry;
        //    foreach (var includeProperty in includeProperties)
        //    {
        //        query = query.Include(includeProperty);
        //    }
        //    return query;
        //}

        public void InsertGraph(VoteEntry voteEntry)
        {
            hmsdb.VoteEntry.Add(voteEntry);
        }

        public void InsertObject(VoteEntry voteEntry)
        {
            hmsdb.Entry(voteEntry).State = EntityState.Added;
        }

        public void Update(VoteEntry voteEntry)
        {
            hmsdb.Entry(voteEntry).State = EntityState.Modified;
        }

        public VoteEntry Find(int id)
        {
            return hmsdb.VoteEntry.Find(id);
        }

        public void Delete(VoteEntry voteEntry)
        {
            hmsdb.VoteEntry.Remove(voteEntry);
        }

        public void Dispose()
        {
            hmsdb.Dispose();
        }


    }
}