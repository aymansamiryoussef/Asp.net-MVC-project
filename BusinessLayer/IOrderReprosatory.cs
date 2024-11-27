using DataAccessLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Interface
{
    public interface IOrderReprosatory
    {
         List<Order> GetAllOrders ();

         Order GetOrderById(int id);

        Order GetOrdersByUserId(string userid);

        void CreateOrder(Order order);

        void UpdateOrder(int id ,Order order);

        void DeleteOrder(int id);


    }
}
