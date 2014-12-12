using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SuperShopUsingLayerArcAPP.DLL.DAO;

namespace SuperShopUsingLayerArcAPP
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            ShowDataInGrid();
        }
        private SuperShopBLL aSuperShopBll=new SuperShopBLL();
        private Shop aShop ;
        private Product aProduct;
      
        private void saveButton_Click(object sender, EventArgs e)
        {
            aShop = new Shop(shopNameTextBox.Text, shopAddressTextBox.Text);
            string msg = aSuperShopBll.AddShop(aShop);
            MessageBox.Show(msg);
            shopNameTextBox.Text = "";
            shopAddressTextBox.Text = "";
        }

        private void addItemButton_Click(object sender, EventArgs e)
        {
            aProduct = new Product(itemIdTextBox.Text, quantityTextBox.Text, shopNameAddTextBox.Text);
            
            string msg = aSuperShopBll.AddProductAndShopName(aProduct, aProduct.ShopName);
            MessageBox.Show(msg);
            itemIdTextBox.Text = "";
            quantityTextBox.Text = "";
            shopNameAddTextBox.Text = "";
        }

        private void showButton_Click(object sender, EventArgs e)
        {
            ShowDataInGrid();
        }

        private void ShowDataInGrid()
        {
            List<Product> Products=new List<Product>();
            Products = aSuperShopBll.GetAllProductInfo();
            dataGridView1.DataSource = Products;
        }
    }
}
