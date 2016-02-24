using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using HMSWebApp.Models;

namespace HMSWebApp.Repository
{
    public class PaymentRepository
    {
        HMSDb _db = new HMSDb();

        /// <summary>
        ///  Retrieves a payment object based from its id
        /// </summary>
        /// <param name="voteEntryId"></param>
        /// <returns></returns>
        public Payment RetrieveById(int paymentId) 
        {
            var payment = _db.Payment.Where(p => p.Id == paymentId).FirstOrDefault();
            return payment;
        }


        public void StorePayment(Payment payment)
        {
            if (payment != null)
            {
                _db.Payment.Add(payment);
                _db.SaveChanges();
            }
        }

        public void UpdatePayment(Payment payment)
        {
            if (payment != null)
            {
                _db.Entry(payment).State = System.Data.EntityState.Modified;
                _db.SaveChanges();
            }
        }
    }
}