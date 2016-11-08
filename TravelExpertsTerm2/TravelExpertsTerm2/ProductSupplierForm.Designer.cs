namespace TravelExpertsTerm2
{
    partial class ProductSupplierForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.cmbProd = new MetroFramework.Controls.MetroComboBox();
            this.cmbSupplier = new MetroFramework.Controls.MetroComboBox();
            this.dgvProdSup = new System.Windows.Forms.DataGridView();
            this.btnAdd = new MetroFramework.Controls.MetroButton();
            this.btnDelete = new MetroFramework.Controls.MetroButton();
            this.btnFindSupplier = new MetroFramework.Controls.MetroButton();
            this.btnFindProduct = new MetroFramework.Controls.MetroButton();
            this.btnViewAll = new MetroFramework.Controls.MetroButton();
            this.metroLabel1 = new MetroFramework.Controls.MetroLabel();
            this.metroLabel2 = new MetroFramework.Controls.MetroLabel();
            ((System.ComponentModel.ISupportInitialize)(this.dgvProdSup)).BeginInit();
            this.SuspendLayout();
            // 
            // cmbProd
            // 
            this.cmbProd.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmbProd.FormattingEnabled = true;
            this.cmbProd.ItemHeight = 24;
            this.cmbProd.Location = new System.Drawing.Point(311, 374);
            this.cmbProd.Name = "cmbProd";
            this.cmbProd.Size = new System.Drawing.Size(229, 30);
            this.cmbProd.Style = MetroFramework.MetroColorStyle.Orange;
            this.cmbProd.TabIndex = 0;
            this.cmbProd.UseSelectable = true;
            this.cmbProd.UseStyleColors = true;
            // 
            // cmbSupplier
            // 
            this.cmbSupplier.FormattingEnabled = true;
            this.cmbSupplier.ItemHeight = 24;
            this.cmbSupplier.Location = new System.Drawing.Point(27, 374);
            this.cmbSupplier.Name = "cmbSupplier";
            this.cmbSupplier.Size = new System.Drawing.Size(223, 30);
            this.cmbSupplier.TabIndex = 1;
            this.cmbSupplier.UseSelectable = true;
            // 
            // dgvProdSup
            // 
            this.dgvProdSup.AllowUserToAddRows = false;
            this.dgvProdSup.AllowUserToDeleteRows = false;
            this.dgvProdSup.AllowUserToResizeRows = false;
            this.dgvProdSup.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvProdSup.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.DarkOrange;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvProdSup.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvProdSup.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 5.8F);
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.DarkOrange;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvProdSup.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgvProdSup.Location = new System.Drawing.Point(1, 3);
            this.dgvProdSup.MaximumSize = new System.Drawing.Size(1050, 645);
            this.dgvProdSup.MultiSelect = false;
            this.dgvProdSup.Name = "dgvProdSup";
            this.dgvProdSup.ReadOnly = true;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Segoe UI Semilight", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgvProdSup.RowsDefaultCellStyle = dataGridViewCellStyle3;
            this.dgvProdSup.RowTemplate.Height = 24;
            this.dgvProdSup.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvProdSup.Size = new System.Drawing.Size(836, 351);
            this.dgvProdSup.TabIndex = 2;
            // 
            // btnAdd
            // 
            this.btnAdd.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(250)))), ((int)(((byte)(250)))));
            this.btnAdd.Location = new System.Drawing.Point(599, 373);
            this.btnAdd.MaximumSize = new System.Drawing.Size(111, 29);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(111, 29);
            this.btnAdd.Style = MetroFramework.MetroColorStyle.Orange;
            this.btnAdd.TabIndex = 3;
            this.btnAdd.Text = "Add";
            this.btnAdd.UseCustomBackColor = true;
            this.btnAdd.UseSelectable = true;
            this.btnAdd.UseStyleColors = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(250)))), ((int)(((byte)(250)))));
            this.btnDelete.Location = new System.Drawing.Point(726, 373);
            this.btnDelete.MaximumSize = new System.Drawing.Size(111, 29);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(111, 29);
            this.btnDelete.Style = MetroFramework.MetroColorStyle.Orange;
            this.btnDelete.TabIndex = 4;
            this.btnDelete.Text = "Delete";
            this.btnDelete.UseCustomBackColor = true;
            this.btnDelete.UseSelectable = true;
            this.btnDelete.UseStyleColors = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnFindSupplier
            // 
            this.btnFindSupplier.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(250)))), ((int)(((byte)(250)))));
            this.btnFindSupplier.Location = new System.Drawing.Point(83, 412);
            this.btnFindSupplier.Name = "btnFindSupplier";
            this.btnFindSupplier.Size = new System.Drawing.Size(132, 23);
            this.btnFindSupplier.Style = MetroFramework.MetroColorStyle.Orange;
            this.btnFindSupplier.TabIndex = 5;
            this.btnFindSupplier.Text = "Find Supplier";
            this.btnFindSupplier.UseCustomBackColor = true;
            this.btnFindSupplier.UseSelectable = true;
            this.btnFindSupplier.UseStyleColors = true;
            this.btnFindSupplier.Click += new System.EventHandler(this.btnFindSupplier_Click);
            // 
            // btnFindProduct
            // 
            this.btnFindProduct.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(250)))), ((int)(((byte)(250)))));
            this.btnFindProduct.Location = new System.Drawing.Point(362, 412);
            this.btnFindProduct.Name = "btnFindProduct";
            this.btnFindProduct.Size = new System.Drawing.Size(132, 23);
            this.btnFindProduct.Style = MetroFramework.MetroColorStyle.Orange;
            this.btnFindProduct.TabIndex = 6;
            this.btnFindProduct.Text = "Find Product";
            this.btnFindProduct.UseCustomBackColor = true;
            this.btnFindProduct.UseSelectable = true;
            this.btnFindProduct.UseStyleColors = true;
            this.btnFindProduct.Click += new System.EventHandler(this.btnFindProduct_Click);
            // 
            // btnViewAll
            // 
            this.btnViewAll.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(250)))), ((int)(((byte)(250)))));
            this.btnViewAll.Location = new System.Drawing.Point(243, 412);
            this.btnViewAll.Name = "btnViewAll";
            this.btnViewAll.Size = new System.Drawing.Size(75, 23);
            this.btnViewAll.Style = MetroFramework.MetroColorStyle.Orange;
            this.btnViewAll.TabIndex = 7;
            this.btnViewAll.Text = "View All";
            this.btnViewAll.UseCustomBackColor = true;
            this.btnViewAll.UseSelectable = true;
            this.btnViewAll.UseStyleColors = true;
            this.btnViewAll.Click += new System.EventHandler(this.btnViewAll_Click);
            // 
            // metroLabel1
            // 
            this.metroLabel1.AutoSize = true;
            this.metroLabel1.Location = new System.Drawing.Point(104, 355);
            this.metroLabel1.Name = "metroLabel1";
            this.metroLabel1.Size = new System.Drawing.Size(65, 20);
            this.metroLabel1.TabIndex = 8;
            this.metroLabel1.Text = "Suppliers";
            // 
            // metroLabel2
            // 
            this.metroLabel2.AutoSize = true;
            this.metroLabel2.Location = new System.Drawing.Point(390, 356);
            this.metroLabel2.Name = "metroLabel2";
            this.metroLabel2.Size = new System.Drawing.Size(63, 20);
            this.metroLabel2.TabIndex = 9;
            this.metroLabel2.Text = "Products";
            // 
            // ProductSupplierForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(861, 488);
            this.Controls.Add(this.metroLabel2);
            this.Controls.Add(this.metroLabel1);
            this.Controls.Add(this.btnViewAll);
            this.Controls.Add(this.btnFindProduct);
            this.Controls.Add(this.btnFindSupplier);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.dgvProdSup);
            this.Controls.Add(this.cmbSupplier);
            this.Controls.Add(this.cmbProd);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "ProductSupplierForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "ProductSupplierForm";
            this.Load += new System.EventHandler(this.ProductSupplierForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvProdSup)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private MetroFramework.Controls.MetroComboBox cmbProd;
        private MetroFramework.Controls.MetroComboBox cmbSupplier;
        private System.Windows.Forms.DataGridView dgvProdSup;
        private MetroFramework.Controls.MetroButton btnAdd;
        private MetroFramework.Controls.MetroButton btnDelete;
        private MetroFramework.Controls.MetroButton btnFindSupplier;
        private MetroFramework.Controls.MetroButton btnFindProduct;
        private MetroFramework.Controls.MetroButton btnViewAll;
        private MetroFramework.Controls.MetroLabel metroLabel1;
        private MetroFramework.Controls.MetroLabel metroLabel2;
    }
}