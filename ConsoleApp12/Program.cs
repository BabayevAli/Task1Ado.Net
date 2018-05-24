using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp12
{
    class Program
    {
        static void Main(string[] args)
        {
            //AllNeedGivees();
            //WithById(2);
            //AllHavingBooks();
            //BookWithUsId(2);
            DeleteAllGives();
        }
        static SqlConnection sqlConnection = new SqlConnection("Data Source=(local);Initial Catalog=Library;Integrated Security=true");

        public static void AllNeedGivees()
        {
            SqlCommand sqlCommand = new SqlCommand("SELECT * FROM S_Cards WHERE S_Cards.DateIn IS NULL UNION SELECT * FROM T_Cards WHERE T_Cards.DateIn IS NULL;", sqlConnection);
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
            DataTable dataTable = new DataTable();
            sqlDataAdapter.Fill(dataTable);
            foreach (DataRow datarow in dataTable.Rows)
            {
                for (int i = 0; i < 10; i++)
                    Console.Write("-");
                Console.WriteLine();
                foreach (DataColumn dc in dataTable.Columns)
                    Console.WriteLine("{0} : {1}", dc.ColumnName, datarow[dc]);
            }
        }

        public static void WithById(int index)
        {
            SqlCommand sqlCommand = new SqlCommand("SELECT Authors.FirstName + N' ' + Authors.LastName AS [Author_Name] FROM Books INNER JOIN Authors ON Authors.Id = Books.Id_Author WHERE Books.Id = @id;", sqlConnection);
            sqlCommand.Parameters.AddWithValue("@id", index);
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
            DataTable dataTable = new DataTable();
            sqlDataAdapter.Fill(dataTable);
            foreach (DataRow datarow in dataTable.Rows)
            {
                for (int i = 0; i < 10; i++)
                    Console.Write("-");
                Console.WriteLine();
                foreach (DataColumn dc in dataTable.Columns)
                    Console.WriteLine("{0} : {1}", dc.ColumnName, datarow[dc]);
            }
        }

        public  static void AllHavingBooks()
        {
            SqlCommand sqlCommand = new SqlCommand("SELECT * FROM Books WHERE Books.Quantity <> 0;", sqlConnection);
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
            DataTable dataTable = new DataTable();
            sqlDataAdapter.Fill(dataTable);
            foreach (DataRow datarow in dataTable.Rows)
            {
                for (int i = 0; i < 10; i++)
                    Console.Write("-");
                Console.WriteLine();
                foreach (DataColumn dc in dataTable.Columns)
                    Console.WriteLine("{0} : {1}", dc.ColumnName, datarow[dc]);
            }
        }

        public static void BookWithUsId(int userid)
        {
            SqlCommand sqlCommand = new SqlCommand("SELECT Books.* FROM S_Cards INNER JOIN Books ON Books.Id = S_Cards.Id_Book WHERE S_Cards.Id_Student = @id UNION SELECT Books.* FROM T_Cards INNER JOIN Books ON Books.Id = T_Cards.Id_Book WHERE T_Cards.Id_Teacher = @id;", sqlConnection);
            sqlCommand.Parameters.AddWithValue("@id", userid);
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
            DataTable dataTable = new DataTable();
            sqlDataAdapter.Fill(dataTable);
            foreach (DataRow datarow in dataTable.Rows)
            {
                for (int i = 0; i < 10; i++)
                    Console.Write("-");
                Console.WriteLine();
                foreach (DataColumn dc in dataTable.Columns)
                    Console.WriteLine("{0} : {1}", dc.ColumnName, datarow[dc]);
            }
        }

        public static void DeleteAllGives()
        {
            SqlCommand sqlCommand = new SqlCommand("DELETE FROM T_Cards;", sqlConnection);
            sqlConnection.Open();
            sqlCommand.ExecuteNonQuery();
        }
    }
}
