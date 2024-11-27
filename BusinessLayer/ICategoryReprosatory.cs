using DataAccessLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Interface
{
    public interface ICategoryReprosatory
    {
        List<Category> GetAllCategories ();

        Category GetCategoryById (int id);

        void AddCategory(Category category);

        void UpdateCategory(int id, Category category);

        void DeleteCategory(string Name);


    }
}
