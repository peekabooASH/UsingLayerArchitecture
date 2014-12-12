using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ProductApp1.BLL;
using ProductApp1.DLL.DAO;

namespace ProductApp1
{
    public partial class ProductUI : Form
    {
        public ProductUI()
        {
            InitializeComponent();
        }
        Product aProduct = new Product();
        private void saveButton_Click(object sender, EventArgs e)
        {
            
            aProduct.Code = productCodeTextBox.Text;
            aProduct.Name = productNameTextBox.Text;
            aProduct.Quantity =productQuntityTextBox.Text;
             ProductBLL aProductBll=new ProductBLL();
            string msg=  aProductBll.SaveProduct(aProduct);
            MessageBox.Show(msg);
        }


        private void ShowStudentEnrollCourseListView()
        {

            showProductListView.View = View.Details;
            showProductListView.GridLines = true;
            showProductListView.FullRowSelect = true;
            showProductListView.Columns.Add("Product Code", 70);
            showProductListView.Columns.Add("Product Name", 200);
            showProductListView.Columns.Add("Quantity", 200);
        }

        private void showButton_Click(object sender, EventArgs e)
        {
            ShowStudentEnrollCourseListView();
            ProductShowBLL aProductShowBll=new ProductShowBLL();
            List<Product> productList = aProductShowBll.ShowAllProduct();
            showProductListView.Items.Clear();
            foreach (Product aValue in productList)
            {
                showProductListView.Items.Add(new ListViewItem(new string[] { aValue.Code,aValue.Name,aValue.Quantity }));
            }
            totalQantityTextBox.Text = aProductShowBll.showQuantity().ToString();
        }
    }
}
