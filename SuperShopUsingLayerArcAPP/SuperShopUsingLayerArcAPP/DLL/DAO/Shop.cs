using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperShopUsingLayerArcAPP.DLL.DAO
{
    class Shop
    {
        public string ShopName { get; set; }
        public string ShopAddress { get; set; }
        public List<Product> Products { set; get; }
        public Shop(string shopName, string shopAddress)
        {
            ShopName = shopName;
            ShopAddress = shopAddress;
            Products =new List<Product>();
        }
    }
}
