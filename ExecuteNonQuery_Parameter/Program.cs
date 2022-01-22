using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExecuteNonQuery_Parameter
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Customer customer=new Customer();
            customer.Id = 4;
            customer.Name = "canan";
            customer.Surname = "Canlı";
            SqlConnection con = new SqlConnection(@"Data Source=NIRVANA\SQLEXPRESS;Initial Catalog=SQLFULL;Persist Security Info=True;User ID=udemy;Password=1");
            SqlCommand command = new SqlCommand("insert into Customer VAlues(@Id,@Name,@Surname)",con);
            command.Parameters.Add("@Id", SqlDbType.Int).Value = customer.Id;
            command.Parameters.Add("@Name", SqlDbType.NVarChar).Value = customer.Name;
            command.Parameters.Add("@Surname",SqlDbType.NVarChar).Value=customer.Surname;
            
            con.Open();
            int IsThereAnyChange=command.ExecuteNonQuery();
            con.Close();

            Console.WriteLine(IsThereAnyChange);

            Console.ReadKey();
            
        
        }
    }
}
