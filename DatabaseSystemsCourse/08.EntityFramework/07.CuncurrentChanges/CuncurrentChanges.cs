using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntityFramework;
using EntityFramework.Library;
using System.Data.Entity;

namespace _07.CuncurrentChanges
{
    class CuncurrentChanges
    {
        static void Main(string[] args)
        {
            northwindEntities db1 = new northwindEntities();
            northwindEntities db2 = new northwindEntities();

            //Categories can be added simultaneously
            for (int i = 0; i < 10; i++)
            {
                db1.Categories.Add(new Category()
                {
                    CategoryName = "NewCategory" + i
                });
                db2.Categories.Add(new Category()
                {
                    CategoryName = "NewCategory" + i
                });
                db1.SaveChanges();
                db2.SaveChanges();
            }

            //Editin same entry
            var firstEntry = db1.Categories.Where((x) => x.CategoryName == "NewCategory0").First();
            firstEntry.CategoryName = "Lol";

            var sameEntry = db2.Categories.Where(x => x.CategoryName == "NewCategory0").First();

            db2.Categories.Remove(sameEntry);

            //Removing an entry before editing it throws an exception
            //db2.SaveChanges();
            db1.SaveChanges();
            

            
        }
    }
}
