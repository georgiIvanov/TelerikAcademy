using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntityFramework.Library;
using System.Data.Entity.Infrastructure;
using System.Data.SqlClient;

namespace _06.NorthwindTwin
{
    class NorthwindTwin
    {
        static void Main(string[] args)
        {
            IObjectContextAdapter context = new northwindEntities();
            string cloneNorthwind = context.ObjectContext.CreateDatabaseScript();

            var db = new northwindEntities();
            
            string[] splitter = new string[] { "\r\nGO\r\n" };
            string[] commandTexts = createDB.Split(splitter,
              StringSplitOptions.RemoveEmptyEntries);
            foreach (string commandText in commandTexts)
            {
                db.Database.ExecuteSqlCommand(commandText);
            }

            SqlConnection dbConForCreatingDB = new SqlConnection(
            "Server=LOCALHOST; " +
            "Database=NorthwindTwin; " +
            "Integrated Security=true");

            dbConForCreatingDB.Open();

            using (dbConForCreatingDB)
            {
                SqlCommand cloneDB = new SqlCommand(cloneNorthwind, dbConForCreatingDB);
                cloneDB.ExecuteNonQuery();
            }
        }

        static string createDB = @"CREATE DATABASE [NorthwindTwin]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'NorthwindTwin', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL11.MSSQLSERVER\MSSQL\DATA\NorthwindTwin.mdf' , SIZE = 5120KB , FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'NorthwindTwin_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL11.MSSQLSERVER\MSSQL\DATA\NorthwindTwin_log.ldf' , SIZE = 2048KB , FILEGROWTH = 10%)
GO
ALTER DATABASE [NorthwindTwin] SET COMPATIBILITY_LEVEL = 110
GO
ALTER DATABASE [NorthwindTwin] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [NorthwindTwin] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [NorthwindTwin] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [NorthwindTwin] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [NorthwindTwin] SET ARITHABORT OFF 
GO
ALTER DATABASE [NorthwindTwin] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [NorthwindTwin] SET AUTO_CREATE_STATISTICS ON 
GO
ALTER DATABASE [NorthwindTwin] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [NorthwindTwin] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [NorthwindTwin] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [NorthwindTwin] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [NorthwindTwin] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [NorthwindTwin] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [NorthwindTwin] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [NorthwindTwin] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [NorthwindTwin] SET  DISABLE_BROKER 
GO
ALTER DATABASE [NorthwindTwin] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [NorthwindTwin] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [NorthwindTwin] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [NorthwindTwin] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [NorthwindTwin] SET  READ_WRITE 
GO
ALTER DATABASE [NorthwindTwin] SET RECOVERY FULL 
GO
ALTER DATABASE [NorthwindTwin] SET  MULTI_USER 
GO
ALTER DATABASE [NorthwindTwin] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [NorthwindTwin] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
USE [NorthwindTwin]
GO
IF NOT EXISTS (SELECT name FROM sys.filegroups WHERE is_default=1 AND name = N'PRIMARY') ALTER DATABASE [NorthwindTwin] MODIFY FILEGROUP [PRIMARY] DEFAULT
GO
";

    }
}
