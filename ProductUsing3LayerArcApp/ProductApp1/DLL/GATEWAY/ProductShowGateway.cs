using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProductApp1.DLL.DAO;

namespace ProductApp1.DLL.GATEWAY
{
    class ProductShowGateway
    {
           private SqlConnection connection;
        public ProductShowGateway()
        {
             string conn = ConfigurationManager.ConnectionStrings["BootCamp"].ConnectionString;
            connection = new SqlConnection();
            connection.ConnectionString = conn;
        }


        public List<Product> ShowAllProduct()
        {
            List<Product> newlist = new List<Product>();

            connection.Open();
            string query = string.Format("SELECT * FROM productEntry ");
            SqlCommand command = new SqlCommand(query, connection);
      
            SqlDataReader aReader = command.ExecuteReader();

            if (aReader.HasRows)
            {
                while (aReader.Read())
                {
                    Product aProduct1= new Product();
                    aProduct1.Code = aReader[0].ToString();
                    aProduct1.Name = aReader[1].ToString();
                    aProduct1.Quantity = aReader[2].ToString();
                    newlist.Add(aProduct1);
                }
            }
            connection.Close();
            return newlist;
        }
    }
}
