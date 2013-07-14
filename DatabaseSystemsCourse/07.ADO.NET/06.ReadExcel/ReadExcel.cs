using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _06.ReadExcel
{
    class ReadExcel
    {
        static void Main(string[] args)
        {
            var fileName = string.Format("{0}\\..\\..\\..\\file.xlsx", Directory.GetCurrentDirectory());

            DataSet sheet1 = new DataSet();
            OleDbConnectionStringBuilder conString = new OleDbConnectionStringBuilder();
            conString.Provider = "Microsoft.ACE.OLEDB.12.0";
            conString.DataSource = fileName;
            conString.Add("Extended Properties", "Excel 12.0 Xml;HDR=YES");

            using (OleDbConnection connection = new OleDbConnection(conString.ConnectionString))
            {
                connection.Open();
                string selectSql = @"SELECT * FROM [Sheet1$]";
                using (OleDbDataAdapter adapter = new OleDbDataAdapter(selectSql, connection))
                {
                    adapter.Fill(sheet1);
                }
                connection.Close();
            }

            var table = sheet1.Tables[0];

            foreach (DataRow row in table.Rows)
            {
                foreach (DataColumn column in table.Columns)
                {
                    Console.Write("{0, 15} ", row[column]);
                }

                Console.WriteLine();
            }
        }
    }
}
