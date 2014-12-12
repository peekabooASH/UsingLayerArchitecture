using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProductApp1.DLL.DAO;
using ProductApp1.DLL.GATEWAY;

namespace ProductApp1.BLL
{
    class ProductShowBLL
    {
        private ProductShowGateway aProductShowGateway;
        public int count=0;
        public int total = 0;

        private List<Product> newList;


        public ProductShowBLL()
        {
            aProductShowGateway=new ProductShowGateway();
        }

        public int showQuantity()
        {
            return total;
        }

        public List<Product> ShowAllProduct()
        {
                newList = aProductShowGateway.ShowAllProduct();
                foreach (var product in newList)
                {
                    count++;
                    total += Convert.ToInt32(product.Quantity);
                }
                return newList;
        }
        
    }
}
