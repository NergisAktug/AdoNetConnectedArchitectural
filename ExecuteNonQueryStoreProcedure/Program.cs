using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExecuteNonQueryStoreProcedure
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Customer customer = new Customer();
            customer.Id= 42;
            customer.Name = "Nalan";
            customer.Surname = "Akgun";

            SqlConnection con = new SqlConnection(@"Data Source=NIRVANA\SQLEXPRESS;Initial Catalog=SQLFULL;Persist Security Info=True;User ID=udemy;Password=1");
            SqlCommand command = new SqlCommand("sp_customerRecord",con);
            command.CommandType=System.Data.CommandType.StoredProcedure;

            command.Parameters.Add("@Id", SqlDbType.Int).Value = customer.Id;
            command.Parameters.Add("@Name", SqlDbType.NVarChar).Value = customer.Name;
            command.Parameters.Add("@Surname", SqlDbType.NVarChar).Value = customer.Surname;

            con.Open();
            int IsThereAnyCustomer=command.ExecuteNonQuery();
            con.Close();
            Console.WriteLine($"Returned count of row affected: {IsThereAnyCustomer}");
            Console.ReadKey();
        }
    }
}
