using Store.DataAccess.Data;
using Store.DataAccess.Repository.IRepository;
using Store.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.DataAccess.Repository
{
    public class OrderHeaderRepository : Repository<OrderHeader>, IOrderHeaderRepository
    {
        private AppDbContext _db;

        public OrderHeaderRepository(AppDbContext db) : base(db)
        {
            _db = db;

        }

     
        public void Update(OrderHeader obj)
        {
            _db.OrderHeaders.Update(obj);
        }

        void IOrderHeaderRepository.UpdateStatus(int id, string orderStatus, string? paymentStatus)
        {
            var dbOrderHeader = _db.OrderHeaders.FirstOrDefault(u => u.Id == id);

            if(dbOrderHeader != null)
            {
                dbOrderHeader.OrderStatus = orderStatus;
                if(paymentStatus != null) 
                {
                    dbOrderHeader.PaymentStatus = paymentStatus;
                }
            }
        }

        void IOrderHeaderRepository.UpdateStripePaymentId(int id, string sessionId, string paymentIntentId)
        {
            var dbOrderHeader = _db.OrderHeaders.FirstOrDefault(u => u.Id == id);

            dbOrderHeader.PaymentDate = DateTime.Now;
            dbOrderHeader.SessionId = sessionId;
            dbOrderHeader.PaymentIntentId = paymentIntentId;
        }
    }
}
