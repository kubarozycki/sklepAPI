using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using WebApplication2.ViewModels;

namespace WebApplication2.Repositories
{
    public class CategoriesRepository
    {
        public static List<CategoryViewModel> GetCategories()
        {
            List<CategoryViewModel> results = new List<CategoryViewModel>();
            using (SqlConnection connection = new SqlConnection("Server=.;Database=TSQL2012;Trusted_Connection=True;"))
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = connection;
                cmd.CommandText = $"SELECT categoryid,categoryname,description FROM Production.Categories";

                connection.Open();

                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    CategoryViewModel temp = new CategoryViewModel
                    {
                        CategoryId = int.Parse(reader["categoryid"].ToString()),
                        CategoryName = reader["categoryname"].ToString(),
                        Description = reader["description"].ToString()
                    };
                    results.Add(temp);

                }
            }

            return results;
        }
    }
}
