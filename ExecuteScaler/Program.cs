using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExecuteScaler
{
    internal class Program
    {
        static void Main(string[] args)
        {
            SqlConnection con = new SqlConnection(@"Data Source=NIRVANA\SQLEXPRESS;Initial Catalog=SQLFULL;Persist Security Info=True;User ID=udemy;Password=1");
            SqlCommand command = new SqlCommand("Select Name from Customer Where Id=4",con);

            con.Open();
            string name=command.ExecuteScalar().ToString();
            con.Close();
            Console.WriteLine($"Name:{name}");
            Console.ReadKey();
        }
    }
}
