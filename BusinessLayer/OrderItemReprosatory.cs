using BusinessLayer.Interface;
using DataAccessLayer;
using DataAccessLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Reprosetory
{
    public class OrderItemReprosatory : IOrderItemReprosatory
    {
        ApplicationContextClass db;
        public OrderItemReprosatory(ApplicationContextClass _db)
        {
            db = _db;
        }

        public void AddOrderItem(Orderitem orderitem)
        {
           db.orderitem.Add(orderitem);
            db.SaveChanges();
        }

        public List<Orderitem> GetAllOrderItemsByOrderId(int orderId)
        {
           return (db.orderitem.Where(o=>o.OrderID==orderId).ToList());
        }

        public void RemoveOrderItem(int orderId)
        {
           Orderitem or= db.orderitem.FirstOrDefault(O=>O.OrderID==orderId);
            db.orderitem.Remove(or);
            db.SaveChanges();
        }
    }
}
