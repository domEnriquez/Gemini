using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HMSWebApp.Repository
{
    public class UnitOfWorkHms : IDisposable
    {
        private readonly HMSDb _hmmsDb;

        public UnitOfWorkHms() 
        {
            _hmmsDb = new HMSDb();
        }

        public UnitOfWorkHms(HMSDb hmsdb)
        {
            _hmmsDb = hmsdb;
        }

        public int Save()
        {
            return _hmmsDb.SaveChanges();
        }

        internal HMSDb HmsDb
        {
            get { return _hmmsDb; }
        }

        public void Dispose()
        {
            _hmmsDb.Dispose();
        }
    }
}