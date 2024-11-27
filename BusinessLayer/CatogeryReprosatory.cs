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
    public class CatogeryReprosatory : ICategoryReprosatory
    {
        ApplicationContextClass db;
        public CatogeryReprosatory(ApplicationContextClass _db)
        {
            db = _db;
        }
        public void AddCategory(Category category)
        {
            db.categories.Add(category);
            db.SaveChanges();

        }

        public void DeleteCategory(string Name)
        {
            Category category = db.categories.FirstOrDefault(c=>c.CatogeryName == Name);
            db.categories.Remove(category);
            db.SaveChanges();
        }

        public List<Category> GetAllCategories()
        {
           return(db.categories.ToList());
        }

        public Category GetCategoryById(int id)
        {
            Category Cat= db.categories.FirstOrDefault(C=>C.Id == id);
            return (Cat);
        }

        public void UpdateCategory(int id, Category category)
        {
           Category cat = db.categories.FirstOrDefault(c=>c.Id == id);
            cat.CatogeryName=category.CatogeryName;
            db.SaveChanges();
        }
    }
}
