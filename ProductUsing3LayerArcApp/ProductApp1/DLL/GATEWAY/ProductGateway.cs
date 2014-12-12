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
    class ProductGateway
    {
        private SqlConnection connection;
        public ProductGateway()
        {
            string conn = ConfigurationManager.ConnectionStrings["BootCamp"].ConnectionString;
            connection = new SqlConnection();
            connection.ConnectionString = conn;
        }


        public bool HasThisProduct(Product aProduct)
        {
            connection.Open();
            string query = string.Format("SELECT * FROM productEntry WHERE Code=@NewCode And  Name=@NewName");
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.Add(new SqlParameter("@NewCode", aProduct.Code));
            command.Parameters.Add(new SqlParameter("@NewName", aProduct.Name));
            SqlDataReader aReader = command.ExecuteReader();
            bool Hasrow = aReader.HasRows;
            connection.Close();
            return Hasrow;
        }

        public void SaveProduct(Product aProduct)
        {
            connection.Open();
            string query = string.Format("INSERT INTO productEntry VALUES(@NewCode,@NewName,@NewQuantity )");
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.Add(new SqlParameter("@NewCode",aProduct.Code ));
            command.Parameters.Add(new SqlParameter("@NewName", aProduct.Name));
            command.Parameters.Add(new SqlParameter("@NewQuantity",Convert.ToInt32(aProduct.Quantity)));

            SqlDataReader aReader = command.ExecuteReader();
            connection.Close();

        }
    }
}
