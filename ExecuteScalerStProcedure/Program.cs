using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExecuteScalerStProcedure
{
    internal class Program
    {
        static void Main(string[] args)
        {
            SqlConnection con = new SqlConnection(@"Data Source=NIRVANA\SQLEXPRESS;Initial Catalog=SQLFULL;Persist Security Info=True;User ID=udemy;Password=1");
            SqlCommand command = new SqlCommand("sp_CustomerName", con);
            command.CommandType = System.Data.CommandType.StoredProcedure;
            command.Parameters.Add("@Id", SqlDbType.Int).Value = 42;

            con.Open();
            string Name=command.ExecuteScalar().ToString();
            con.Close();

            Console.WriteLine($"Name:{Name}");
            Console.ReadKey();

        }
    }
}
