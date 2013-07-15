using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;

class SQLiteDatabase
{
    String dbConnection;

    public SQLiteDatabase(String inputFile)
    {
        dbConnection = String.Format("Data Source=..\\..\\{0}", inputFile);
    }

    public DataTable GetDataTable(string sql)
    {
        DataTable dt = new DataTable();
        try
        {
            SQLiteConnection cnn = new SQLiteConnection(dbConnection);
            cnn.Open();
            SQLiteCommand mycommand = new SQLiteCommand(cnn);
            mycommand.CommandText = sql;
            SQLiteDataReader reader = mycommand.ExecuteReader();
            dt.Load(reader);
            reader.Close();
            cnn.Close();
        }
        catch (Exception e)
        {
            throw new Exception(e.Message);
        }
        return dt;
    }

    public int ExecuteNonQuery(string sql)
    {
        SQLiteConnection cnn = new SQLiteConnection(dbConnection);
        cnn.Open();
        SQLiteCommand mycommand = new SQLiteCommand(cnn);
        mycommand.CommandText = sql;
        int rowsUpdated = mycommand.ExecuteNonQuery();
        cnn.Close();
        return rowsUpdated;
    }

    public bool Insert(String tableName, Dictionary<String, String> data)
    {
        String columns = "";
        String values = "";
        Boolean returnCode = true;
        foreach (KeyValuePair<String, String> val in data)
        {
            columns += String.Format(" {0},", val.Key.ToString());
            values += String.Format(" '{0}',", val.Value);
        }
        columns = columns.Substring(0, columns.Length - 1);
        values = values.Substring(0, values.Length - 1);
     
        this.ExecuteNonQuery(String.Format("insert into {0}({1}) values({2});", tableName, columns, values));
        
        return returnCode;
    }
}

