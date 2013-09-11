using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Todo.App.Models;
using Todo.Data;
using Todo.Models;

namespace Todo.App
{
    public class CategoriesRepository
    {
        TodoContext db = new TodoContext();

        public List<Category> SelectCategories()
        {
            var found = (from t in db.Categories
                         select t).ToList();


            return found;
        }

        public void InsertCategory(int Id, string Name)
        {
            Category newCategory = new Category()
            {
                Name = Name
            };

            db.Categories.Add(newCategory);
            db.SaveChanges();
        }

        public void EditCategories(int Id, string Name)
        {
            var found = db.Categories.Single(x => x.Id == Id);

            found.Name = Name;
            db.SaveChanges();
        }

        public void DeleteCategories(int Id)
        {
            var found = db.Categories.Single(x => x.Id == Id);
            db.Categories.Remove(found);
            db.SaveChanges();
        }
    }
}