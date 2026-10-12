using System;
using System.Collections.Generic;
using System.Text;
using Npgsql;
using Models;

namespace DataAccessLayer
{
    public class crud
    {
        public static List<ProductModel> GetAllData()

        {
            string Query = " select *from \"products\" ";
            List<ProductModel> products = new List<ProductModel>();
            NpgsqlConnection connection = dblhelper.GetConnection();
            connection.Open();
            NpgsqlCommand cmd = new NpgsqlCommand(Query , connection);
            NpgsqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                ProductModel model = new ProductModel();

               model.Pid = Convert.ToInt32(reader["Pid"]);
                model.productname = reader["productname"].ToString();
                model.price = Convert.ToInt32(reader["price"]);
                products.Add(model);
            }
           connection.Close();
            return products;
        }
    }
}
