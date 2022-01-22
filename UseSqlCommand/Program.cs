using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UseSqlCommand
{
    internal class Program
    {
        static void Main(string[] args)
        {
            SqlConnection con=new SqlConnection(@"Data Source=NIRVANA\SQLEXPRESS;Initial Catalog=SQLFULL;Persist Security Info=True;User ID=udemy;Password=1");
            SqlCommand command=new SqlCommand("Insert into Customer values (1,'Nergis','Aktug')",con);
            con.Open();
            int HowManyRecord=command.ExecuteNonQuery();//returned count of row affected
            con.Close();

            Console.WriteLine(HowManyRecord);

            Console.ReadKey();
        }
    }
}
