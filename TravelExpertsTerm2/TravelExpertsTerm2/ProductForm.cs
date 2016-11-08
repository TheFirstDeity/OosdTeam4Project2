using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TravelDatabase;
using TravelDatabase.EntityData;
using System.Data.SqlClient;

namespace TravelExpertsTerm2
{
    public partial class ProductForm : Form
    {
        // a global attribute
        public Product prod;
        public ProductForm()
        {
            InitializeComponent();
            //hiding the Product Panel as the form intializes
            pnlProduct.Visible = false;
            lsvProduct.Visible = true;

        }
        // a private method to load information to the combobox
        private void LoadComboxProducts()
        {
            List<Product> products = new List<Product>();
            try
            {
                products = ProductDB.GetProducts();
                cboProducts.DataSource = products;
                cboProducts.DisplayMember = "Name";
                cboProducts.ValueMember = "ProductId";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, ex.GetType().ToString());
            }
        }
        // method to load the listview
        private void LoadListView()
        {
            lsvProduct.Items.Clear();


            List<Product> sortedProducts = new List<Product>();
            try
            {
                List<Product> products = ProductDB.GetProducts();
                sortedProducts = products.OrderBy(x => x.ProductId).ToList();

                foreach (Product prodt in sortedProducts)
                {

                    ListViewItem prodiItem = new ListViewItem(prodt.ProductId.ToString());
                    prodiItem.SubItems.Add(prodt.Name);
                    lsvProduct.Items.Add(prodiItem);

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, ex.GetType().ToString());
            }
        }
        // method to accept form inputs
        private void acceptRecord(Product product)
        {
            product.ProductId = Convert.ToInt32(txtProductId.Text);
            product.Name = txtProductName.Text;
        }

        // method load invent
        private void ProductForm_Load(object sender, EventArgs e)
        {
           this.LoadComboxProducts();
            LoadListView();
        }
        // Combobox selected Value change method. to trigger event of the comboBox selection 
        private void cboProducts_SelectedValueChanged(object sender, EventArgs e)
        {
            //lsvProduct.Items.Clear();
            lsvProduct.FullRowSelect = true;
            lsvProduct.GridLines = true;
            //adding product Item to the listview
            //ListViewItem prodItem = new ListViewItem(cboProducts.SelectedValue.ToString());
            //prodItem.SubItems.Add(cboProducts.GetItemText(cboProducts.SelectedItem));
            //lsvProduct.Items.Add(prodItem);
        }
        // method to make the panel product visible to allow for entry data
        private void btnProduct_Click(object sender, EventArgs e)
        {
            pnlProduct.Visible = true;
            btnSave.Text = "Add";
            txtProductId.Text = "";
            txtProductName.Text = "";
            txtProductId.Enabled = true;
            txtProductName.Focus();
        }
        // method to insert and update records to the database
        private void btnSave_Click(object sender, EventArgs e)
        {
            int num;
            if (btnSave.Text == "Add")
            {
                try
                {
                    if (txtProductId.Text == "")
                    {
                        MessageBox.Show("Please Enter Product Id", "Product Id");
                        txtProductId.Focus();
                    }
                    else if (!Int32.TryParse(txtProductId.Text, out num) && num <= 0)
                    {
                        MessageBox.Show("Please Enter a valid Number", "Entry_Error");
                        txtProductId.Focus();
                    }
                    else if (txtProductName.Text == "")
                    {
                        MessageBox.Show("Please Enter Product Name", "Product Name");
                        txtProductName.Focus();
                    }
                    else
                    {
                        prod = new Product();
                        prod.ProductId = Convert.ToInt32(txtProductId.Text);
                        prod.Name = txtProductName.Text;
                        ProductDB.AddEntity(prod);
                        LoadComboxProducts();
                        LoadListView();
                        pnlProduct.Visible = false;
                        lsvProduct.Visible = true;
                        lblSelectProd.Visible = true;
                        cboProducts.Visible = true;
                        btnDeleteProduct.Enabled = true;
                        btnProduct.Enabled = true;
                        txtProductId.Enabled = true;
                        MessageBox.Show("New Product Added Successfully");
                       
                    }
                }
                catch (SqlException ex)
                {
                    string errorMsg = "A record exist with the same Product Id";
                    MessageBox.Show(errorMsg, ex.Message); 
                }
            }
            // update record
            else if (btnSave.Text == "Update")
            {

                Product newProduct = new Product();
                newProduct.ProductId = prod.ProductId;
                acceptRecord(newProduct);
                try
                {
                    if (!ProductDB.UpdateProduct(prod, newProduct))
                    {
                        MessageBox.Show("Another Product Exist with similar records", "Database Error");
                        this.DialogResult = DialogResult.Retry;
                    }
                    else
                    {
                        prod = newProduct;
                        LoadComboxProducts();
                        LoadListView();
                        pnlProduct.Visible = false;
                        lsvProduct.Visible = true;
                        lblSelectProd.Visible = true;
                        cboProducts.Visible = true;
                        btnDeleteProduct.Enabled = true;
                        btnProduct.Enabled = true;
                        txtProductId.Enabled = true;
                        MessageBox.Show("Product record Updated successfully", "Update Record");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, ex.GetType().ToString());
                }
            }
        }
        // method to hide the product panel
        private void btnCancel_Click(object sender, EventArgs e)
        {
            pnlProduct.Visible = false;
            lsvProduct.Visible = true;
            lblSelectProd.Visible = true;
            cboProducts.Visible = true;
            btnDeleteProduct.Enabled = true;
            btnProduct.Enabled = true;
            txtProductId.Enabled = true;
        }
        // method to make the product panel visible 
        private void btnUpdateProduct_Click(object sender, EventArgs e)
        {
            btnSave.Text = "Update";
            pnlProduct.Visible = true;
            lblSelectProd.Visible = false;
            cboProducts.Visible = false;
            btnDeleteProduct.Enabled = false;
            btnProduct.Enabled = false;
            txtProductId.Text = cboProducts.SelectedValue.ToString();
            txtProductName.Text = cboProducts.GetItemText(cboProducts.SelectedItem);
            txtProductId.Enabled = false;
            prod = new Product();
            prod.ProductId = Convert.ToInt32(txtProductId.Text);
            prod.Name = txtProductName.Text;
            acceptRecord(prod);
            txtProductName.Focus();
        }
        // method to delete record
        private void btnDeleteProduct_Click(object sender, EventArgs e)
        {
            DialogResult deleteDialogResult = MessageBox.Show("Are you sure you want to Delete this Record",
                "Delete Record", MessageBoxButtons.YesNo);
            if (deleteDialogResult == DialogResult.Yes)
            {
                Product prod = new Product();
                prod.ProductId = Convert.ToInt32(cboProducts.SelectedValue.ToString());
                if (ProductDB.checkIfItExist(prod))
                {
                    MessageBox.Show("You cannot delete this record please select another record to delete","Delete Record");
                    cboProducts.Focus();
                }
                else
                {
                    ProductDB.DeleteEntity(prod);
                    LoadComboxProducts();
                    LoadListView();
                    MessageBox.Show("record deleted successfully");
                }
            }
            else if (deleteDialogResult == DialogResult.No)
            {
                
            }
            

        }



        private void lsvProduct_ItemSelectionChanged(object sender, ListViewItemSelectionChangedEventArgs e)
        {
            if (e.IsSelected)
                e.Item.Selected = false;

        }
    }
}
