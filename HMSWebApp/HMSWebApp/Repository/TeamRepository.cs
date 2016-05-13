using System;
using System.Data;
using System.Data.Entity;
using System.Linq;
using HMSWebApp.Interfaces;
using HMSWebApp.Models;

namespace HMSWebApp.Repository
{
    public class TeamRepository : ITeamRepository 
    {
        private HMSDb hmsdb;

        public TeamRepository(UnitOfWorkHms uow)
        {
            hmsdb = uow.HmsDb;
        }

        public IQueryable<Team> All
        {
            get { return hmsdb.Team; }
        }

        public IQueryable<Team> AllIncluding(string[] includeProperties)
        {
            IQueryable<Team> query = hmsdb.Team;
            foreach (var includeProperty in includeProperties)
            {
                query = query.Include(includeProperty);
            }
            return query;
        }

        public Team SingleIncluding(int id, string[] includeProperties)
        {
            IQueryable<Team> query = hmsdb.Team;
            foreach (var includeProperty in includeProperties)
            {
                query = query.Include(includeProperty);
            }
            return query.FirstOrDefault(team => team.Id == id);
        }

        public Team Find(int id)
        {
            return hmsdb.Team.Find(id);
        }

        public void InsertGraph(Team team)
        {
            hmsdb.Team.Add(team);
        }

        public void InsertObject(Team team)
        {
            hmsdb.Entry(team).State = EntityState.Added;
        }

        public void Update(Team team)
        {
            hmsdb.Entry(team).State = EntityState.Modified;
        }

        public void Delete(Team team)
        {
            hmsdb.Team.Remove(team);
        }

        public void Dispose()
        {
            hmsdb.Dispose();
        }

    }
}