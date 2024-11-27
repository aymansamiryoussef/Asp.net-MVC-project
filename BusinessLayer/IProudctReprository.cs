using DataAccessLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Interface
{
    public interface IProudctReprository
    {
        List<Proudct> GetAll();

        Proudct GetByID(int id);

        Proudct GetByName(string name);

        void add(Proudct proudct);

        void update(int id ,Proudct proudct);

        void remove(int id);

        List<Proudct>ProudctonCategory(int id);


        


    }
}
