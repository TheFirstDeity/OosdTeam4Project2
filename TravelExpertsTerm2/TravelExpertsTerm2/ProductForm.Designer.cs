namespace TravelExpertsTerm2
{
    partial class ProductForm
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
            this.lsvProduct = new System.Windows.Forms.ListView();
            this.cProductId = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.cProductName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.lblSelectProd = new MetroFramework.Controls.MetroLabel();
            this.cboProducts = new MetroFramework.Controls.MetroComboBox();
            this.btnProduct = new MetroFramework.Controls.MetroButton();
            this.btnUpdateProduct = new MetroFramework.Controls.MetroButton();
            this.btnDeleteProduct = new MetroFramework.Controls.MetroButton();
            this.lblProductId = new MetroFramework.Controls.MetroLabel();
            this.lblProductName1 = new MetroFramework.Controls.MetroLabel();
            this.txtProductId = new MetroFramework.Controls.MetroTextBox();
            this.txtProductName = new MetroFramework.Controls.MetroTextBox();
            this.btnSave = new MetroFramework.Controls.MetroButton();
            this.btnCancel = new MetroFramework.Controls.MetroButton();
            this.pnlProduct = new MetroFramework.Controls.MetroPanel();
            this.pnlProduct.SuspendLayout();
            this.SuspendLayout();
            // 
            // lsvProduct
            // 
            this.lsvProduct.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.cProductId,
            this.cProductName});
            this.lsvProduct.Font = new System.Drawing.Font("Segoe UI Semilight", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lsvProduct.Location = new System.Drawing.Point(355, 12);
            this.lsvProduct.Name = "lsvProduct";
            this.lsvProduct.Size = new System.Drawing.Size(265, 150);
            this.lsvProduct.TabIndex = 7;
            this.lsvProduct.UseCompatibleStateImageBehavior = false;
            this.lsvProduct.View = System.Windows.Forms.View.Details;
            this.lsvProduct.ItemSelectionChanged += new System.Windows.Forms.ListViewItemSelectionChangedEventHandler(this.lsvProduct_ItemSelectionChanged);
            // 
            // cProductId
            // 
            this.cProductId.Text = "Product ID";
            this.cProductId.Width = 161;
            // 
            // cProductName
            // 
            this.cProductName.Text = "Product Name";
            this.cProductName.Width = 176;
            // 
            // lblSelectProd
            // 
            this.lblSelectProd.AutoSize = true;
            this.lblSelectProd.Location = new System.Drawing.Point(5, 12);
            this.lblSelectProd.Name = "lblSelectProd";
            this.lblSelectProd.Size = new System.Drawing.Size(101, 20);
            this.lblSelectProd.TabIndex = 8;
            this.lblSelectProd.Text = "Select Product:";
            // 
            // cboProducts
            // 
            this.cboProducts.FormattingEnabled = true;
            this.cboProducts.ItemHeight = 24;
            this.cboProducts.Location = new System.Drawing.Point(143, 12);
            this.cboProducts.Name = "cboProducts";
            this.cboProducts.Size = new System.Drawing.Size(192, 30);
            this.cboProducts.TabIndex = 9;
            this.cboProducts.UseSelectable = true;
            this.cboProducts.SelectedValueChanged += new System.EventHandler(this.cboProducts_SelectedValueChanged);
            // 
            // btnProduct
            // 
            this.btnProduct.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(250)))), ((int)(((byte)(250)))));
            this.btnProduct.Location = new System.Drawing.Point(143, 66);
            this.btnProduct.Name = "btnProduct";
            this.btnProduct.Size = new System.Drawing.Size(192, 23);
            this.btnProduct.Style = MetroFramework.MetroColorStyle.Orange;
            this.btnProduct.TabIndex = 10;
            this.btnProduct.Text = "Create New Product";
            this.btnProduct.UseCustomBackColor = true;
            this.btnProduct.UseSelectable = true;
            this.btnProduct.UseStyleColors = true;
            this.btnProduct.Click += new System.EventHandler(this.btnProduct_Click);
            // 
            // btnUpdateProduct
            // 
            this.btnUpdateProduct.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(250)))), ((int)(((byte)(250)))));
            this.btnUpdateProduct.Location = new System.Drawing.Point(143, 103);
            this.btnUpdateProduct.Name = "btnUpdateProduct";
            this.btnUpdateProduct.Size = new System.Drawing.Size(192, 23);
            this.btnUpdateProduct.Style = MetroFramework.MetroColorStyle.Orange;
            this.btnUpdateProduct.TabIndex = 11;
            this.btnUpdateProduct.Text = "Update Product";
            this.btnUpdateProduct.UseCustomBackColor = true;
            this.btnUpdateProduct.UseSelectable = true;
            this.btnUpdateProduct.UseStyleColors = true;
            this.btnUpdateProduct.Click += new System.EventHandler(this.btnUpdateProduct_Click);
            // 
            // btnDeleteProduct
            // 
            this.btnDeleteProduct.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(250)))), ((int)(((byte)(250)))));
            this.btnDeleteProduct.Location = new System.Drawing.Point(143, 139);
            this.btnDeleteProduct.Name = "btnDeleteProduct";
            this.btnDeleteProduct.Size = new System.Drawing.Size(192, 23);
            this.btnDeleteProduct.Style = MetroFramework.MetroColorStyle.Orange;
            this.btnDeleteProduct.TabIndex = 12;
            this.btnDeleteProduct.Text = "Delete Product";
            this.btnDeleteProduct.UseCustomBackColor = true;
            this.btnDeleteProduct.UseSelectable = true;
            this.btnDeleteProduct.UseStyleColors = true;
            this.btnDeleteProduct.Click += new System.EventHandler(this.btnDeleteProduct_Click);
            // 
            // lblProductId
            // 
            this.lblProductId.AutoSize = true;
            this.lblProductId.Location = new System.Drawing.Point(43, 36);
            this.lblProductId.Name = "lblProductId";
            this.lblProductId.Size = new System.Drawing.Size(77, 20);
            this.lblProductId.TabIndex = 13;
            this.lblProductId.Text = "Product ID:";
            // 
            // lblProductName1
            // 
            this.lblProductName1.AutoSize = true;
            this.lblProductName1.Location = new System.Drawing.Point(18, 82);
            this.lblProductName1.Name = "lblProductName1";
            this.lblProductName1.Size = new System.Drawing.Size(102, 20);
            this.lblProductName1.TabIndex = 14;
            this.lblProductName1.Text = "Product Name:";
            // 
            // txtProductId
            // 
            this.txtProductId.Lines = new string[0];
            this.txtProductId.Location = new System.Drawing.Point(135, 33);
            this.txtProductId.MaxLength = 32767;
            this.txtProductId.Name = "txtProductId";
            this.txtProductId.PasswordChar = '\0';
            this.txtProductId.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.txtProductId.SelectedText = "";
            this.txtProductId.Size = new System.Drawing.Size(192, 23);
            this.txtProductId.TabIndex = 13;
            this.txtProductId.UseSelectable = true;
            // 
            // txtProductName
            // 
            this.txtProductName.Lines = new string[0];
            this.txtProductName.Location = new System.Drawing.Point(135, 82);
            this.txtProductName.MaxLength = 32767;
            this.txtProductName.Name = "txtProductName";
            this.txtProductName.PasswordChar = '\0';
            this.txtProductName.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.txtProductName.SelectedText = "";
            this.txtProductName.Size = new System.Drawing.Size(192, 23);
            this.txtProductName.TabIndex = 14;
            this.txtProductName.UseSelectable = true;
            // 
            // btnSave
            // 
            this.btnSave.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(250)))), ((int)(((byte)(250)))));
            this.btnSave.Location = new System.Drawing.Point(165, 133);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.Style = MetroFramework.MetroColorStyle.Orange;
            this.btnSave.TabIndex = 13;
            this.btnSave.Text = "Save";
            this.btnSave.UseCustomBackColor = true;
            this.btnSave.UseSelectable = true;
            this.btnSave.UseStyleColors = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(250)))), ((int)(((byte)(250)))));
            this.btnCancel.Location = new System.Drawing.Point(252, 134);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.Style = MetroFramework.MetroColorStyle.Orange;
            this.btnCancel.TabIndex = 13;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseCustomBackColor = true;
            this.btnCancel.UseSelectable = true;
            this.btnCancel.UseStyleColors = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // pnlProduct
            // 
            this.pnlProduct.Controls.Add(this.btnCancel);
            this.pnlProduct.Controls.Add(this.txtProductId);
            this.pnlProduct.Controls.Add(this.btnSave);
            this.pnlProduct.Controls.Add(this.lblProductId);
            this.pnlProduct.Controls.Add(this.lblProductName1);
            this.pnlProduct.Controls.Add(this.txtProductName);
            this.pnlProduct.HorizontalScrollbarBarColor = true;
            this.pnlProduct.HorizontalScrollbarHighlightOnWheel = false;
            this.pnlProduct.HorizontalScrollbarSize = 10;
            this.pnlProduct.Location = new System.Drawing.Point(12, 216);
            this.pnlProduct.Name = "pnlProduct";
            this.pnlProduct.Size = new System.Drawing.Size(355, 218);
            this.pnlProduct.TabIndex = 15;
            this.pnlProduct.VerticalScrollbarBarColor = true;
            this.pnlProduct.VerticalScrollbarHighlightOnWheel = false;
            this.pnlProduct.VerticalScrollbarSize = 10;
            // 
            // ProductForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(863, 448);
            this.Controls.Add(this.pnlProduct);
            this.Controls.Add(this.btnDeleteProduct);
            this.Controls.Add(this.btnUpdateProduct);
            this.Controls.Add(this.btnProduct);
            this.Controls.Add(this.cboProducts);
            this.Controls.Add(this.lblSelectProd);
            this.Controls.Add(this.lsvProduct);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "ProductForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "ProductForm";
            this.Load += new System.EventHandler(this.ProductForm_Load);
            this.pnlProduct.ResumeLayout(false);
            this.pnlProduct.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ListView lsvProduct;
        private System.Windows.Forms.ColumnHeader cProductId;
        private System.Windows.Forms.ColumnHeader cProductName;
        private MetroFramework.Controls.MetroLabel lblSelectProd;
        private MetroFramework.Controls.MetroComboBox cboProducts;
        private MetroFramework.Controls.MetroButton btnProduct;
        private MetroFramework.Controls.MetroButton btnUpdateProduct;
        private MetroFramework.Controls.MetroButton btnDeleteProduct;
        private MetroFramework.Controls.MetroLabel lblProductId;
        private MetroFramework.Controls.MetroLabel lblProductName1;
        private MetroFramework.Controls.MetroTextBox txtProductId;
        private MetroFramework.Controls.MetroTextBox txtProductName;
        private MetroFramework.Controls.MetroButton btnSave;
        private MetroFramework.Controls.MetroButton btnCancel;
        private MetroFramework.Controls.MetroPanel pnlProduct;
    }
}