using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExecuteReader_Parameter
{
    internal class Program
    {
        static void Main(string[] args)
        {
            SqlConnection con = new SqlConnection(@"Data Source=NIRVANA\SQLEXPRESS;Initial Catalog=SQLFULL;Persist Security Info=True;User ID=udemy;Password=1");
            SqlCommand command = new SqlCommand("Select * from Customer where Id=@Id", con);
            command.Parameters.Add("@Id", SqlDbType.Int).Value = 42;
            con.Open();
            SqlDataReader sqlReader=command.ExecuteReader();
            while (sqlReader.Read())
            {
                int Id = sqlReader.GetInt32(0);
                string Name = sqlReader.GetString(1)
;                string Surname = sqlReader.GetString(2);
                Console.WriteLine($"{Id} {Name} {Surname}");
            }

            sqlReader.Close();
            con.Close();

            Console.ReadKey();
        }
    }
}
