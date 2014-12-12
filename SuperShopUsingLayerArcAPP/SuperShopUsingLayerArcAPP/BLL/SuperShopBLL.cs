using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SuperShopUsingLayerArcAPP.DLL.DAO;
using SuperShopUsingLayerArcAPP.DLL.Getway;

namespace SuperShopUsingLayerArcAPP
{
    class SuperShopBLL
    {
        private SuperShopGetway aGetway=new SuperShopGetway();
        public string AddShop(Shop aShop)
        {
            if (aShop.ShopName == "" && aShop.ShopAddress == "")
            {
                return "Fill Up All Shop Information. ";
            }
            else
            {
                return aGetway.AddShop(aShop);
            }
        }
        public string AddProductAndShopName(Product aProduct, string shopName)
        {
             int n;
             bool isNumeric = int.TryParse( aProduct.ProductQuantity, out n);
             if (!isNumeric)
                 return "Quantity can not be String.";
            if (aProduct.ProductId == "" &&  aProduct.ProductQuantity.ToString() == "")
            {
                return "Fill All Product Information.";
               
            }
              return aGetway.AddProductAndShopName(aProduct, shopName);
 
        }

        public List<Product> GetAllProductInfo()
        {
            return aGetway.GetAllProductInfo();
        }
    }
}
