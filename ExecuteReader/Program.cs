using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExecuteReader
{
    internal class Program
    {
        static void Main(string[] args)
        {
            SqlConnection con = new SqlConnection(@"Data Source=NIRVANA\SQLEXPRESS;Initial Catalog=SQLFULL;Persist Security Info=True;User ID=udemy;Password=1");
            SqlCommand command = new SqlCommand("Select * from Customer",con);
            con.Open();
             SqlDataReader sqlReader=command.ExecuteReader();
            while (sqlReader.Read())
            {
                int Id = (int)sqlReader[0];
                string Name=(string)sqlReader[1];
                string Surname=sqlReader.GetString(2);//2.Index'deki veriyi getirir

                Console.WriteLine($"Id:{Id} Name:{Name} Surname:{Surname}");
            }
            sqlReader.Close();

            Console.ReadKey();

        }
    }
}
