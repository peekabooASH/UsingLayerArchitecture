using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProductApp1.DLL.DAO;
using ProductApp1.DLL.GATEWAY;

namespace ProductApp1.BLL
{
    class ProductBLL
    {
        ProductGateway aProductGateway;

        public ProductBLL()
        {
            aProductGateway = new ProductGateway();
        }

        private bool HasFillUpProductInformation(Product aProduct)
        {
            if (aProduct.Code != string.Empty && aProduct.Name != string.Empty && aProduct.Quantity.ToString() !="" )
            {
               return true;
            }
           return false;
        }
        private bool HasFillUpProperlyProductInformation(Product aProduct)
        {
            int codeLength = aProduct.Code.Length;
            int nameLength = aProduct.Name.Length;
            if (codeLength == 3 && (nameLength >= 5 && nameLength <= 10))
            {
                return true;
            }
            return false;
        }
        public string SaveProduct(Product aProduct)
        {
            if (HasFillUpProductInformation(aProduct))
            {
                if (HasFillUpProperlyProductInformation(aProduct))
                {
                    if (!aProductGateway.HasThisProduct(aProduct))
                    {
                        aProductGateway.SaveProduct(aProduct);
                        return "Save Successfully.";
                    }
                }
                return "Check Product Name And Code.Code Should in 3 character and Name should be in 5 or more character.";
            }
            return "Fill up all information.";
        }
    }
}
