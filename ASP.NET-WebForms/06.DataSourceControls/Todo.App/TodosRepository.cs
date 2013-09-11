using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Todo.App.Models;
using Todo.Data;
using Todo.Models;

namespace Todo.App
{
    public class TodosRepository
    {
        TodoContext db = new TodoContext();

        public List<TodoModel> SelectTodos()
        {
            var found = (from t in db.Todos.Include("Category")
                         select t).ToList();

            var shown = new List<TodoModel>(found.Count);

            foreach (var item in found)
            {
                shown.Add(new TodoModel
                {
                    Id = item.Id,
                    Title = item.Title,
                    Category = item.Category.Name,
                    LastModified = item.LastModified,
                    Text = item.Text

                });
            }

            return shown;
        }

        public void InsertTodo(int Id, string Title, string Text, string LastModified, string Category)
        {

            var cat = db.Categories.Single(x => x.Name == Category);

            TodoEntry newTodo = new TodoEntry()
            {
                Title = Title,
                Text = Text,
                LastModified = DateTime.Now,
                Category = cat
            };

            db.Todos.Add(newTodo);
            db.SaveChanges();
        }

        public void EditTodo(int Id, string Title, string Text, string LastModified, string Category)
        {
            var found = db.Todos.Single(x => x.Id == Id);

            found.Title = Title;
            found.Text = Text;
            found.LastModified = DateTime.Now;

            var cat = db.Categories.Single(x => x.Name == Category);

            found.Category = cat;

            db.SaveChanges();
        }

        public void DeleteTodo(int Id)
        {
            var found = db.Todos.Single(x => x.Id == Id);
            db.Todos.Remove(found);
            db.SaveChanges();
        }
    }
}