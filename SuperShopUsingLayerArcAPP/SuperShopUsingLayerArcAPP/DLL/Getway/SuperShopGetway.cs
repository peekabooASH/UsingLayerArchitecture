using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using SuperShopUsingLayerArcAPP.DLL.DAO;

namespace SuperShopUsingLayerArcAPP.DLL.Getway
{
    class SuperShopGetway
    {
        private SqlConnection connection;
        private int totalQuantity = 0;
        public SuperShopGetway()
        {
            string conn = ConfigurationManager.ConnectionStrings["MyDBConnection"].ConnectionString;
            connection = new SqlConnection();
            connection.ConnectionString = conn;
        }
        public string AddShop(Shop aShop)
        {
            connection.Open();
            if (HasThisShopNameValid(aShop.ShopName))
            {
                connection.Close();
                return "Information Repeated";
            }
            connection.Close();

            connection.Open();


           //string user = Request.QueryString["user"];
           // string queryString = HttpContext.Current.Request.QueryString[aShop.ShopName];

            //string strID = Request.QueryString[aShop.ShopName];




            string query = "INSERT INTO ShopTable VALUES (@ShopName , @ShopAddress) ";
            SqlCommand command = new SqlCommand(query, connection);
            SqlParameter p1 = new SqlParameter("@ShopName", SqlDbType.VarChar);
            p1.Value = aShop.ShopName;
            command.Parameters.Add(p1);
            SqlParameter p2 = new SqlParameter("@ShopAddress", SqlDbType.VarChar);
            p2.Value = aShop.ShopAddress;
            command.Parameters.Add(p2);


            //////////////////////PROCEDURE 1///////////////////////////////////////////

            //string query = "INSERT INTO ShopTable VALUES (@ShopName , @ShopAddress) ";
            //SqlCommand command = new SqlCommand(query, connection);
            //SqlParameter p1 = new SqlParameter("@ShopName", SqlDbType.VarChar);
            //p1.Value = aShop.ShopName;
            //command.Parameters.Add(p1);
            //SqlParameter p2 = new SqlParameter("@ShopAddress", SqlDbType.VarChar);
            //p2.Value = aShop.ShopAddress;
            //command.Parameters.Add(p2);



            ////command.Parameters.Add("@ID", SqlDbType.Int);


            //////////////////////PROCEDURE 2///////////////////////////////////////////
            //string query = string.Format("INSERT INTO ShopTable VALUES('{0}','{1}')", aShop.ShopName, aShop.ShopAddress);
            //SqlCommand command = new SqlCommand(query, connection);

            //command.Parameters.Add("@ShopName", SqlDbType.VarChar);
            //command.Parameters["@ShopName"].Value = aShop.ShopName;

            //command.Parameters.Add("@ShopAddress", SqlDbType.VarChar);
            //command.Parameters["@ShopAddress"].Value = aShop.ShopAddress;


            //////////////////////PROCEDURE 3///////////////////////////////////////////
            //string query = string.Format("INSERT INTO ShopTable VALUES('{0}','{1}')", aShop.ShopName, aShop.ShopAddress);
            //SqlCommand command = new SqlCommand(query, connection);
            //command.Parameters.Add("@ShopName", aShop.ShopName);
            //command.Parameters.Add("@ShopAddress", aShop.ShopAddress);

            //////////////////////PROCEDURE 4///////////////////////////////////////////
            //string query = string.Format("INSERT INTO ShopTable VALUES('{0}','{1}')", aShop.ShopName, aShop.ShopAddress);
            //SqlCommand command = new SqlCommand(query, connection);
            //command.Parameters.Add("@ShopName", SqlDbType.VarChar, 50).Value = aShop.ShopName;
            //command.Parameters.Add("@ShopAddress", SqlDbType.VarChar, 50).Value = aShop.ShopAddress;


            int affectedRows = command.ExecuteNonQuery();
            connection.Close();
            return "Shop Information is Inserted";
        }

        public bool HasThisShopNameValid(string shopName)
        {
            string query = "SELECT * FROM ShopTable WHERE ShopName=@shopName";
            ////SqlCommand cmd = new SqlCommand(commandText, connection);
            //cmd.Parameters.Add("@shopName", shopName);

            //string query = string.Format("SELECT * FROM ShopTable WHERE ShopName='{0}'", shopName);

            SqlCommand command = new SqlCommand(query, connection);
            SqlParameter p1 = new SqlParameter("@ShopName", SqlDbType.VarChar);
            p1.Value = shopName;
            command.Parameters.Add(p1);
            SqlDataReader aReader = command.ExecuteReader();
            bool Hasrow = aReader.HasRows;
            return Hasrow;
        }

        public string AddProductAndShopName(Product aProduct, string shopName)
        {

            if (!hasShopNameExists(shopName))
            {
                return "Check product Id and Shop Name."; 
            }
            if (hasItem(aProduct.ProductId, shopName))
            {

                connection.Open();
                totalQuantity += Convert.ToInt32(aProduct.ProductQuantity);
                string query1 = string.Format("update Product set ProductQuantity={0} WHERE ProductName='{1}'and ShopName='{2}'", totalQuantity, aProduct.ProductId, shopName);
                SqlCommand command1 = new SqlCommand(query1, connection);
                int affectedRows1 = command1.ExecuteNonQuery();
                connection.Close();
                return "Item Quantity is Updated";
            }
            connection.Open();
            string query = string.Format("INSERT INTO Product VALUES('{0}','{1}','{2}')", aProduct.ProductId, aProduct.ProductQuantity, shopName);
            SqlCommand command = new SqlCommand(query, connection);
            int affectedRows = command.ExecuteNonQuery();
            connection.Close();
            return "Product Information is Inserted";
        }

        private bool hasItem(string productId,string shopName)
        {
            connection.Open();
            string query = string.Format("SELECT * FROM Product WHERE ProductName='{0}' and ShopName='{1}'", productId,shopName);
            SqlCommand command = new SqlCommand(query, connection);
            SqlDataReader aReader = command.ExecuteReader();
            totalQuantity = 0;
            if (aReader.HasRows)
            {
                Product aProduct = new Product();
                while (aReader.Read())
                {
                    aProduct.ProductId = aReader[0].ToString();
                    aProduct.ProductQuantity = aReader[1].ToString();
                }
                totalQuantity += Convert.ToInt32(aProduct.ProductQuantity);
            }
            bool Hasrow = aReader.HasRows;
            connection.Close();
           
            return Hasrow;
        }

        private bool hasShopNameExists(string shopName)
        {
            connection.Open();
            string query = string.Format("SELECT * FROM ShopTable WHERE  ShopName='{0}'",shopName);
            SqlCommand command = new SqlCommand(query, connection);
            SqlDataReader aReader = command.ExecuteReader();
            if (aReader.HasRows)
            {
                Product aProduct = new Product();
                while (aReader.Read())
                {
                    aProduct.ShopName = aReader[0].ToString();
                }
            }
            bool Hasrow = aReader.HasRows;
            connection.Close();
           
            return Hasrow;
        }

        public List<Product> GetAllProductInfo()
        {
            connection.Open();
            string query = string.Format("SELECT * FROM Product");
            SqlCommand command = new SqlCommand(query, connection);
            SqlDataReader aReader = command.ExecuteReader();
            List<Product> productList=new List<Product>();
           
            if (aReader.HasRows)
            {

                while (aReader.Read())
                {
                    Product aProduct = new Product();
                    aProduct.ProductId = aReader[0].ToString();
                    aProduct.ProductQuantity =aReader[1].ToString();
                    aProduct.ShopName = aReader[2].ToString();
                   
                    productList.Add(aProduct);
                }
              
            }
            connection.Close();
            return productList;
        }
    }
}
