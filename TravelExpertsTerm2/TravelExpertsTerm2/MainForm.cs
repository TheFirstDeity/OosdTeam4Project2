// ReSharper disable All
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TravelExpertsTerm2
{
    public partial class MainForm : MetroFramework.Forms.MetroForm
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {

        }

        private void metroTile1_Click(object sender, EventArgs e)
        {
            resetViewWindow();
            panel2.Controls.Clear();
            PackagesForm form = new PackagesForm();
            
          // form.MdiParent = this;
            form.TopLevel = false;
            panel2.Controls.Add(form);
            form.Dock = DockStyle.Fill;
            form.Show();
            btnPackages.BackColor=Color.White;
;
        }

        private void MainForm_Resize(object sender, EventArgs e)
        {
            
           // panel2.Width = MdiParent.Width-metroPanel1.Width;

        }

        private void metroButton1_Click(object sender, EventArgs e)
        {
            resetViewWindow();
            panel2.Controls.Clear();
            SupplierForm form = new SupplierForm();
           // form.MdiParent = this;
            form.TopLevel = false;
            panel2.Controls.Add(form);   
            Dock = DockStyle.Fill;
            form.Show();
            btnSuppliers.BackColor = Color.White;
        }

        private void resetViewWindow()
        {
            foreach (Form f in panel2.Controls)
            { f.Close(); }
            btnPackages.BackColor = Color.FromArgb(0, 174, 219);
            BtnProdSup.BackColor = Color.FromArgb(124, 65, 153);
            btnProducts.BackColor = Color.FromArgb(209, 17, 65);
            btnSuppliers.BackColor = Color.Orange;
        }

        private void BtnProdSup_Click(object sender, EventArgs e)
        {
            resetViewWindow();
            panel2.Controls.Clear();
            ProductSupplierForm form = new ProductSupplierForm();
           // form.MdiParent = this;
            form.TopLevel = false;
            panel2.Controls.Add(form);
            Dock = DockStyle.Fill;
            form.Show();

            BtnProdSup.BackColor = Color.White;

        }

        private void metroButton2_Click(object sender, EventArgs e)
        {
            resetViewWindow();
            panel2.Controls.Clear();
            ProductForm form = new ProductForm();
            // form.MdiParent = this;
            form.Anchor = (AnchorStyles.Top | AnchorStyles.Left);
            form.TopLevel = false;
            panel2.Controls.Add(form);
            Dock = DockStyle.Fill;
            form.Show();
            btnProducts.BackColor = Color.White;


        }
    }
}
