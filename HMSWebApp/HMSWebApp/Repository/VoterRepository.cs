using System.Data;
using System.Data.Entity;
using System.Linq;
using HMSWebApp.Interfaces;
using HMSWebApp.Models;

namespace HMSWebApp.Repository
{
    public class VoterRepository : IVoterRepository
    {
        private HMSDb hmsdb;

        public VoterRepository(UnitOfWorkHms uow)
        {
            hmsdb = uow.HmsDb;
        }

        public IQueryable<Voter> All
        {
            get { return hmsdb.Voter; }
        }


        public IQueryable<Voter> AllIncluding(string[] includeProperties)
        {
            IQueryable<Voter> query = hmsdb.Voter;
            foreach (var includeProperty in includeProperties)
            {
                query = query.Include(includeProperty);
            }
            return query;
        }

        public Voter SingleIncluding(int id, string[] includeProperties)
        {
            IQueryable<Voter> query = hmsdb.Voter;
            foreach (var includeProperty in includeProperties)
            {
                query = query.Include(includeProperty);
            }
            return query.FirstOrDefault(voter => voter.Id == id);
        }

        public void InsertGraph(Voter voter)
        {
            hmsdb.Voter.Add(voter);
        }

        public void InsertObject(Voter voter)
        {
            hmsdb.Entry(voter).State = EntityState.Added;
        }

        public void Update(Voter voter)
        {
            hmsdb.Entry(voter).State = EntityState.Modified;
        }

        public Voter Find(int id)
        {
            return hmsdb.Voter.Find(id);
        }

        public void Delete(Voter voter)
        {
            hmsdb.Voter.Remove(voter);
        }

        public void Dispose()
        {
            hmsdb.Dispose();
        }

        public Voter FindByEmailAddress(string emailAddress)
        {
            return hmsdb.Voter.FirstOrDefault(voter => voter.EmailAddress == emailAddress);
        }

        public bool VoterAlreadyExists(Voter voter)
        {
            if (voter != null)
            {
                if (FindByEmailAddress(voter.EmailAddress) != null) return true;
                else return false;
            }
            else return false;
        }


    }
}