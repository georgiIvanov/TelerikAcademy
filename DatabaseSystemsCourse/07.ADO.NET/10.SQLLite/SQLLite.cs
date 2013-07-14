using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;
using System.Globalization;
using System.Threading;
using System.Data;

namespace _10.SQLLite
{
    class SQLLite
    {
        static SQLiteDatabase db;
        static void Main(string[] args)
        {
            Thread.CurrentThread.CurrentCulture = CultureInfo.InvariantCulture;

            db = new SQLiteDatabase("Books");

            // Method used only once to create books table
            // CreateBooksTable();


            // Uncomment methods to test

            //AddBook("SQLite For Professionals", "Homer Simpson", DateTime.Parse("7/14/2013"), 666);

            //ListBooks();

            SearchBook("A Game Of Thrones");
        }

        

        public static void AddBook(string title, string author, DateTime pubDate, int ISBN)
        {
            Dictionary<string, string> data = new Dictionary<string, string>();
            data.Add("TITLE", title);
            data.Add("AUTHOR", author);
            data.Add("PUBDATE", pubDate.ToShortDateString());
            data.Add("ISBN", Convert.ToString(ISBN));

            db.Insert("Books", data);
        }

        public static void ListBooks()
        {
            string query = "select TITLE \"Title\", AUTHOR \"Author\", " +
                "PUBDATE \"Publish Date\", ISBN \"ISBN\" from Books";

            DataTable books = db.GetDataTable(query);

            foreach (DataRow r in books.Rows)
            {

                Console.WriteLine("{0}, {1}, {2}, {3}",r["Title"].ToString(), 
                    r["Author"].ToString(),
                    r["Publish Date"].ToString(),
                    r["ISBN"].ToString());

            }
        }

        public static void SearchBook(string title)
        {
            string query = "select TITLE \"Title\", AUTHOR \"Author\", " +
                "PUBDATE \"Publish Date\", ISBN \"ISBN\" from Books ";

            DataTable books = db.GetDataTable(query);

            foreach (DataRow r in books.Rows)
            {
                if ((string)r["Title"] == title)
                {
                    Console.WriteLine("{0}, {1}, {2}, {3}", r["Title"].ToString(),
                        r["Author"].ToString(),
                        r["Publish Date"].ToString(),
                        r["ISBN"].ToString());
                }

            }
        }

        static void CreateBooksTable()
        {
            string createTable = "create table Books (TITLE varchar(50), " +
                "AUTHOR varchar(50), PUBDATE varchar(10), ISBN int)";
            db.ExecuteNonQuery(createTable);
        }
    }
}
