using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication2.Repositories
{
    public class CategoriesRepository
    {
        public static List<string> GetCategories()
        {
            List<string> results = new List<string>();
            using (SqlConnection connection = new SqlConnection("Server=.;Database=TSQL2012;Trusted_Connection=True;"))
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = connection;
                cmd.CommandText = $"SELECT categoryname FROM Production.Categories";

                connection.Open();

                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    results.Add(reader["categoryname"].ToString());
                }
            }

            return results;
        }
    }
}
