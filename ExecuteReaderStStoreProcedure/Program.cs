using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExecuteReaderStStoreProcedure
{
    public class Customer
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Customer> list = new List<Customer>();
            SqlConnection con = new SqlConnection(@"Data Source=NIRVANA\SQLEXPRESS;Initial Catalog=SQLFULL;Persist Security Info=True;User ID=udemy;Password=1");
            SqlCommand command = new SqlCommand("sp_MyCustomer", con);
            command.CommandType=System.Data.CommandType.StoredProcedure;
            con.Open();
            SqlDataReader dataReader=command.ExecuteReader();

            while (dataReader.Read())
            {
                // list.Add(new Customer { Id = dataReader.GetInt32(0), Name = dataReader.GetString(1), Surname=dataReader.GetString(2)});
                list.Add(new Customer {
                    Id = dataReader.IsDBNull(0) ? 0 : dataReader.GetInt32(0),
                    Surname = dataReader.IsDBNull(1) ? String.Empty : dataReader.GetString(1),
                    Name=dataReader.IsDBNull(2) ? String.Empty : dataReader.GetString(2)
                    });
            
            }
            dataReader.Close();
            con.Close();
            foreach (Customer item in list)
            {
                Console.WriteLine($"{item.Id} {item.Name} {item.Surname}");
            }

            Console.ReadKey();

        }
    }
}
