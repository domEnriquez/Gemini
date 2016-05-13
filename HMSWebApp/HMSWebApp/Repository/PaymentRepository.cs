using System;
using System.Data.Entity;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using HMSWebApp.Interfaces;
using HMSWebApp.Models;
using System.Data;

namespace HMSWebApp.Repository
{
    public class PaymentRepository : IPaymentRepository
    {
        private HMSDb hmsdb;

        public PaymentRepository(UnitOfWorkHms uow)
        {
            hmsdb = uow.HmsDb;
        }

        public IQueryable<Payment> All
        {
            get { return hmsdb.Payment; }
        }

        public IQueryable<Payment> AllIncluding(string[] includeProperties)
        {
            IQueryable<Payment> query = hmsdb.Payment;
            foreach (var includeProperty in includeProperties)
            {
                query = query.Include(includeProperty);
            }
            return query;
        }

        public Payment SingleIncluding(int id, string[] includeProperties)
        {
            IQueryable<Payment> query = hmsdb.Payment;
            foreach (var includeProperty in includeProperties)
            {
                query = query.Include(includeProperty);
            }
            return query.FirstOrDefault(payment => payment.Id == id);
        }

        public Payment Find(int id)
        {
            return hmsdb.Payment.Find(id);
        }

        public void InsertGraph(Payment payment)
        {
            hmsdb.Payment.Add(payment);
        }

        public void InsertObject(Payment payment)
        {
            hmsdb.Entry(payment).State = EntityState.Added;
        }

        public void Update(Payment payment)
        {
            hmsdb.Entry(payment).State = EntityState.Modified;
        }

        public void Delete(Payment payment)
        {
            hmsdb.Payment.Remove(payment);
        }

        public void Dispose()
        {
            hmsdb.Dispose();
        }
    }
}