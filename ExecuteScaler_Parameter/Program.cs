using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExecuteScaler_Parameter
{
    internal class Program
    {
        static void Main(string[] args)
        {
            SqlConnection con = new SqlConnection(@"Data Source=NIRVANA\SQLEXPRESS;Initial Catalog=SQLFULL;Persist Security Info=True;User ID=udemy;Password=1");
            SqlCommand command = new SqlCommand("Select Name from Customer Where Id=@Id", con);
            command.Parameters.Add("@Id", SqlDbType.Int).Value = 4;

            con.Open();
            string name=command.ExecuteScalar().ToString();
            con.Close();
            Console.WriteLine($"Name:{name}");
            Console.ReadKey();
        }
    }
}
