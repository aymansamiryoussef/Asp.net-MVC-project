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
    public class ProudctReprosatory:IProudctReprository
    {
        ApplicationContextClass db ;

        public ProudctReprosatory(ApplicationContextClass _db)
        {
            db= _db;
        }

        public void add(Proudct proudct)
        {
            db.Add(proudct);
            db.SaveChanges();
        }

        public List<Proudct> GetAll()
        {
            return(db.Proudcts.ToList());
        }

        public Proudct GetByID(int id)
        {
            Proudct proudct_Needed= db.Proudcts.FirstOrDefault(p=> p.Id == id);
            return (proudct_Needed);
        }

        public Proudct GetByName(string name)
        {
            Proudct proudct = db.Proudcts.FirstOrDefault(P=>P.Name==name);

            return (proudct);
        }

        public List<Proudct> ProudctonCategory(int id)
        {
            List<Proudct> proudcts = db.Proudcts.Where(p=>p.CategoryId==id).ToList();
            return (proudcts);
        }

        public void remove(int id)
        {
            Proudct proudct= db.Proudcts.FirstOrDefault(p=>p.Id==id);
            db.Remove(proudct);
            db.SaveChanges();
        }

        public void update(int id, Proudct proudct)
        {
            Proudct oldproudct = db.Proudcts.FirstOrDefault(p=>p.Id == id);
            oldproudct.Name=proudct.Name;
            oldproudct.Price=proudct.Price;
            oldproudct.Stockquantity=proudct.Stockquantity;
            oldproudct.Description=proudct.Description;
            oldproudct.CategoryId=proudct.CategoryId;
            oldproudct.ImageUrl=proudct.ImageUrl;
            db.SaveChanges();
        }
    }
}
