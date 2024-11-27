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
    public class OrderReprosatory:IOrderReprosatory
    {

        ApplicationContextClass db;
        public OrderReprosatory(ApplicationContextClass _db)
        {
            db = _db;
        }

        public void CreateOrder(Order order)
        {
            db.orders.Add(order);
            db.SaveChanges();
        }

        public void DeleteOrder(int id)
        {
            Order o = db.orders.FirstOrDefault(O=>O.Id==id);
            db.orders.Remove(o);
            db.SaveChanges();
        }

        public List<Order> GetAllOrders()
        {
            return (db.orders.ToList());
        }

        public Order GetOrderById(int id)
        {
           Order order = db.orders.FirstOrDefault(o=>o.Id == id);
            return (order);
        }

        public Order GetOrdersByUserId(string userid)
        {
            Order order = db.orders.FirstOrDefault(O=>O.UserID == userid);
            return (order);
        }

        public void UpdateOrder(int id, Order order)
        {
            Order O = db.orders.FirstOrDefault(o=>o.Id == id);
            O.OrderDate = order.OrderDate;
            O.OrderStatus = order.OrderStatus;
            O.UserID = order.UserID;
            db.SaveChanges(); 

        }
    }
}
