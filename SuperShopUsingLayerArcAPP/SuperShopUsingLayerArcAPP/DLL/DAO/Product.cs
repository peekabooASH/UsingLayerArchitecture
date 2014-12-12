using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperShopUsingLayerArcAPP.DLL.DAO
{
    class Product
    {
        public string ProductId { set; get; }
        public string ProductQuantity { set; get; }
        public string ShopName { set; get; }
        public Product(string productId, string productQuantity, string shopName)
        {
            ProductId = productId;
            ProductQuantity = productQuantity;
            ShopName = shopName;
        }

        public Product()
        {
        }
    }
}
