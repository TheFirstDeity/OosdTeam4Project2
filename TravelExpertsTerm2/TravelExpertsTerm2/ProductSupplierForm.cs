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

namespace TravelExpertsTerm2
{


    public partial class ProductSupplierForm : Form
    {
        List<Supplier> suppliers = SupplierDB.GetSuppliers();
        List<Product> products = ProductDB.GetProducts();
        List<ProductSupplier> ProdSups = ProductSupplierDB.GetProductSuppliers();
        BindingSource source = new BindingSource();
        public ProductSupplierForm()
        {
            InitializeComponent();
        }

        private void ProductSupplierForm_Load(object sender, EventArgs e)
        {
            var data = from ps in ProdSups
                       orderby ps.Supplier.Name
                        select new {ID = ps.ProductSupplierId, Supplier = ps.Supplier.Name, Product = ps.Product.Name, ps.FullName};
            source.DataSource = data;
             cmbSupplier.DataSource = suppliers;
            cmbProd.DataSource = products;
            dgvProdSup.DataSource = source;
            dgvProdSup.Columns[0].Width = 80;
        }

        private void btnFindSupplier_Click(object sender, EventArgs e)
        {
            string name = cmbSupplier.SelectedItem.ToString();
            var data = from ps in ProdSups
                where ps.Supplier.Name == name
                select new { ID = ps.ProductSupplierId, Supplier = ps.Supplier.Name, Product = ps.Product.Name, ps.FullName };
            source.DataSource = data;
            dgvProdSup.Focus();
        }

        private void btnViewAll_Click(object sender, EventArgs e)
        {
            var data = from ps in ProdSups
                       orderby ps.Supplier.Name
                       select new { ID = ps.ProductSupplierId, Supplier = ps.Supplier.Name, Product = ps.Product.Name, ps.FullName };
            source.DataSource = data;
            dgvProdSup.Focus();
        }

        private void btnFindProduct_Click(object sender, EventArgs e)
        {
            string name = cmbProd.SelectedItem.ToString();
            var data = from ps in ProdSups
                       where ps.Product.Name == name
                       select new { ID = ps.ProductSupplierId, Supplier = ps.Supplier.Name, Product = ps.Product.Name, ps.FullName };
            source.DataSource = data;
            dgvProdSup.Focus();
        }

        private bool checkDuplicate(string supName,string prodName)
        {
            
            var data = from ps in ProdSups
                       where ps.Product.Name == prodName && ps.Supplier.Name == supName
                       select new { ID = ps.ProductSupplierId, Supplier = ps.Supplier.Name, Product = ps.Product.Name, ps.FullName };

            if (data.Any())
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (checkDuplicate(cmbSupplier.Text,cmbProd.Text))
            {
                MessageBox.Show("This Product Supplier Already Exists");
                cmbSupplier.Focus();
            }
            else
            {
                
                ProductSupplierDB.AddProductSupplier((Product) cmbProd.SelectedItem,(Supplier)cmbSupplier.SelectedItem);
                refreshDataSource();
                dgvProdSup.Focus();
            }
        }

        private void refreshDataSource()
        {
            ProdSups = ProductSupplierDB.GetProductSuppliers();
            var data = from ps in ProdSups
                       orderby ps.Supplier.Name
                       select new { ID = ps.ProductSupplierId, Supplier = ps.Supplier.Name, Product = ps.Product.Name, ps.FullName };
            source.DataSource = data;
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {

            //ProductSupplierDB.CheckDependency((int)dgvProdSup.CurrentRow.Cells[1].ToString());
            if (dgvProdSup.SelectedCells.Count > 0)
            {
                int selectedrowindex = dgvProdSup.SelectedCells[0].RowIndex;

                DataGridViewRow selectedRow = dgvProdSup.Rows[selectedrowindex];

                int id = Convert.ToInt32(selectedRow.Cells["ID"].Value);
                DialogResult result = MessageBox.Show("Are you sure you want to delete this record?" + "\n\nProductSupplier: " + Convert.ToString(selectedRow.Cells["FullName"].Value),"Confirmation", MessageBoxButtons.YesNo);
                if (result == DialogResult.Yes)
                {
                    string message = ProductSupplierDB.DeleteProductSupplier(id);
                    MessageBox.Show(message);
                    refreshDataSource();
                    dgvProdSup.Focus();
                }
            }
        }
    }
}
