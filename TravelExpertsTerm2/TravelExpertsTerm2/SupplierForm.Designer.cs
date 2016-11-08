namespace TravelExpertsTerm2
{
    partial class SupplierForm
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
            this.components = new System.ComponentModel.Container();
            this.lstSuppliers = new System.Windows.Forms.ListView();
            this.SupplierID = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.SupName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.txtSearch = new MetroFramework.Controls.MetroTextBox();
            this.btnAddNewSupplier = new MetroFramework.Controls.MetroButton();
            this.btnUpdateSelected = new MetroFramework.Controls.MetroButton();
            this.btnDeleteSelected = new MetroFramework.Controls.MetroButton();
            this.metroStyleExtender1 = new MetroFramework.Components.MetroStyleExtender(this.components);
            this.pnlAddUpdate = new MetroFramework.Controls.MetroPanel();
            this.lblSupName = new MetroFramework.Controls.MetroLabel();
            this.txtSupName = new MetroFramework.Controls.MetroTextBox();
            this.lblSupplierID = new MetroFramework.Controls.MetroLabel();
            this.txtSupplierID = new MetroFramework.Controls.MetroTextBox();
            this.btnAdd = new MetroFramework.Controls.MetroButton();
            this.btnCancel1 = new MetroFramework.Controls.MetroButton();
            this.metroLabel1 = new MetroFramework.Controls.MetroLabel();
            this.pnlAddUpdate.SuspendLayout();
            this.SuspendLayout();
            // 
            // lstSuppliers
            // 
            this.lstSuppliers.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.SupplierID,
            this.SupName});
            this.lstSuppliers.Font = new System.Drawing.Font("Segoe UI Semilight", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lstSuppliers.FullRowSelect = true;
            this.lstSuppliers.Location = new System.Drawing.Point(360, 26);
            this.lstSuppliers.MultiSelect = false;
            this.lstSuppliers.Name = "lstSuppliers";
            this.lstSuppliers.Size = new System.Drawing.Size(361, 365);
            this.lstSuppliers.TabIndex = 0;
            this.lstSuppliers.UseCompatibleStateImageBehavior = false;
            this.lstSuppliers.View = System.Windows.Forms.View.Details;
            this.lstSuppliers.SelectedIndexChanged += new System.EventHandler(this.lstSuppliers_SelectedIndexChanged);
            // 
            // SupplierID
            // 
            this.SupplierID.Text = "Supplier ID";
            this.SupplierID.Width = 120;
            // 
            // SupName
            // 
            this.SupName.Text = "Supplier Name";
            this.SupName.Width = 350;
            // 
            // txtSearch
            // 
            this.txtSearch.FontSize = MetroFramework.MetroTextBoxSize.Tall;
            this.txtSearch.Lines = new string[0];
            this.txtSearch.Location = new System.Drawing.Point(60, 67);
            this.txtSearch.MaxLength = 32767;
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.PasswordChar = '\0';
            this.txtSearch.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.txtSearch.SelectedText = "";
            this.txtSearch.Size = new System.Drawing.Size(182, 20);
            this.txtSearch.TabIndex = 1;
            this.txtSearch.UseSelectable = true;
            this.txtSearch.TextChanged += new System.EventHandler(this.txtSearch_TextChanged);
            this.txtSearch.Click += new System.EventHandler(this.txtSearch_Click);
            // 
            // btnAddNewSupplier
            // 
            this.btnAddNewSupplier.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(250)))), ((int)(((byte)(250)))));
            this.btnAddNewSupplier.Location = new System.Drawing.Point(58, 121);
            this.btnAddNewSupplier.Name = "btnAddNewSupplier";
            this.btnAddNewSupplier.Size = new System.Drawing.Size(182, 28);
            this.btnAddNewSupplier.Style = MetroFramework.MetroColorStyle.Orange;
            this.btnAddNewSupplier.TabIndex = 2;
            this.btnAddNewSupplier.Text = "&Add New Supplier";
            this.btnAddNewSupplier.UseCustomBackColor = true;
            this.btnAddNewSupplier.UseSelectable = true;
            this.btnAddNewSupplier.UseStyleColors = true;
            this.btnAddNewSupplier.Click += new System.EventHandler(this.btnAddNewSupplier_Click);
            // 
            // btnUpdateSelected
            // 
            this.btnUpdateSelected.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(250)))), ((int)(((byte)(250)))));
            this.btnUpdateSelected.Location = new System.Drawing.Point(58, 157);
            this.btnUpdateSelected.Name = "btnUpdateSelected";
            this.btnUpdateSelected.Size = new System.Drawing.Size(182, 28);
            this.btnUpdateSelected.Style = MetroFramework.MetroColorStyle.Orange;
            this.btnUpdateSelected.TabIndex = 3;
            this.btnUpdateSelected.Text = "&Update Selected";
            this.btnUpdateSelected.UseCustomBackColor = true;
            this.btnUpdateSelected.UseSelectable = true;
            this.btnUpdateSelected.UseStyleColors = true;
            this.btnUpdateSelected.Click += new System.EventHandler(this.btnUpdateSelected_Click);
            // 
            // btnDeleteSelected
            // 
            this.btnDeleteSelected.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(250)))), ((int)(((byte)(250)))));
            this.btnDeleteSelected.Location = new System.Drawing.Point(58, 191);
            this.btnDeleteSelected.Name = "btnDeleteSelected";
            this.btnDeleteSelected.Size = new System.Drawing.Size(182, 28);
            this.btnDeleteSelected.Style = MetroFramework.MetroColorStyle.Orange;
            this.btnDeleteSelected.TabIndex = 4;
            this.btnDeleteSelected.Text = "&Delete Selected";
            this.btnDeleteSelected.UseCustomBackColor = true;
            this.btnDeleteSelected.UseSelectable = true;
            this.btnDeleteSelected.UseStyleColors = true;
            this.btnDeleteSelected.Click += new System.EventHandler(this.btnDeleteSelected_Click);
            // 
            // pnlAddUpdate
            // 
            this.pnlAddUpdate.BackColor = System.Drawing.Color.Transparent;
            this.pnlAddUpdate.Controls.Add(this.lblSupName);
            this.pnlAddUpdate.Controls.Add(this.txtSupName);
            this.pnlAddUpdate.Controls.Add(this.lblSupplierID);
            this.pnlAddUpdate.Controls.Add(this.txtSupplierID);
            this.pnlAddUpdate.Controls.Add(this.btnAdd);
            this.pnlAddUpdate.Controls.Add(this.btnCancel1);
            this.pnlAddUpdate.HorizontalScrollbarBarColor = true;
            this.pnlAddUpdate.HorizontalScrollbarHighlightOnWheel = false;
            this.pnlAddUpdate.HorizontalScrollbarSize = 10;
            this.pnlAddUpdate.Location = new System.Drawing.Point(45, 244);
            this.pnlAddUpdate.Name = "pnlAddUpdate";
            this.pnlAddUpdate.Size = new System.Drawing.Size(299, 144);
            this.pnlAddUpdate.TabIndex = 5;
            this.pnlAddUpdate.VerticalScrollbarBarColor = true;
            this.pnlAddUpdate.VerticalScrollbarHighlightOnWheel = false;
            this.pnlAddUpdate.VerticalScrollbarSize = 10;
            this.pnlAddUpdate.Visible = false;
            // 
            // lblSupName
            // 
            this.lblSupName.AutoSize = true;
            this.lblSupName.Location = new System.Drawing.Point(19, 54);
            this.lblSupName.Name = "lblSupName";
            this.lblSupName.Size = new System.Drawing.Size(101, 20);
            this.lblSupName.TabIndex = 16;
            this.lblSupName.Text = "Supplier Name";
            // 
            // txtSupName
            // 
            this.txtSupName.BackColor = System.Drawing.SystemColors.ControlLight;
            this.txtSupName.FontSize = MetroFramework.MetroTextBoxSize.Tall;
            this.txtSupName.Lines = new string[0];
            this.txtSupName.Location = new System.Drawing.Point(128, 51);
            this.txtSupName.MaxLength = 32767;
            this.txtSupName.Name = "txtSupName";
            this.txtSupName.PasswordChar = '\0';
            this.txtSupName.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.txtSupName.SelectedText = "";
            this.txtSupName.Size = new System.Drawing.Size(156, 20);
            this.txtSupName.TabIndex = 7;
            this.txtSupName.UseSelectable = true;
            // 
            // lblSupplierID
            // 
            this.lblSupplierID.AutoSize = true;
            this.lblSupplierID.BackColor = System.Drawing.SystemColors.ControlLight;
            this.lblSupplierID.Location = new System.Drawing.Point(19, 25);
            this.lblSupplierID.Name = "lblSupplierID";
            this.lblSupplierID.Size = new System.Drawing.Size(72, 20);
            this.lblSupplierID.TabIndex = 16;
            this.lblSupplierID.Text = "SupplierID";
            // 
            // txtSupplierID
            // 
            this.txtSupplierID.BackColor = System.Drawing.SystemColors.ControlLight;
            this.txtSupplierID.FontSize = MetroFramework.MetroTextBoxSize.Tall;
            this.txtSupplierID.Lines = new string[0];
            this.txtSupplierID.Location = new System.Drawing.Point(128, 22);
            this.txtSupplierID.MaxLength = 32767;
            this.txtSupplierID.Name = "txtSupplierID";
            this.txtSupplierID.PasswordChar = '\0';
            this.txtSupplierID.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.txtSupplierID.SelectedText = "";
            this.txtSupplierID.Size = new System.Drawing.Size(156, 20);
            this.txtSupplierID.TabIndex = 6;
            this.txtSupplierID.UseSelectable = true;
            this.txtSupplierID.Click += new System.EventHandler(this.txtSupplierID_Click);
            // 
            // btnAdd
            // 
            this.btnAdd.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(250)))), ((int)(((byte)(250)))));
            this.btnAdd.Location = new System.Drawing.Point(128, 88);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(75, 23);
            this.btnAdd.Style = MetroFramework.MetroColorStyle.Orange;
            this.btnAdd.TabIndex = 8;
            this.btnAdd.Text = "Add";
            this.btnAdd.UseCustomBackColor = true;
            this.btnAdd.UseSelectable = true;
            this.btnAdd.UseStyleColors = true;
            this.btnAdd.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnCancel1
            // 
            this.btnCancel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(250)))), ((int)(((byte)(250)))));
            this.btnCancel1.Location = new System.Drawing.Point(209, 88);
            this.btnCancel1.Name = "btnCancel1";
            this.btnCancel1.Size = new System.Drawing.Size(75, 23);
            this.btnCancel1.Style = MetroFramework.MetroColorStyle.Orange;
            this.btnCancel1.TabIndex = 9;
            this.btnCancel1.Text = "Cancel";
            this.btnCancel1.UseCustomBackColor = true;
            this.btnCancel1.UseSelectable = true;
            this.btnCancel1.UseStyleColors = true;
            this.btnCancel1.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // metroLabel1
            // 
            this.metroLabel1.AutoSize = true;
            this.metroLabel1.Location = new System.Drawing.Point(64, 44);
            this.metroLabel1.Name = "metroLabel1";
            this.metroLabel1.Size = new System.Drawing.Size(175, 20);
            this.metroLabel1.TabIndex = 8;
            this.metroLabel1.Text = "Enter Supplier ID to Search";
            // 
            // SupplierForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(756, 403);
            this.Controls.Add(this.metroLabel1);
            this.Controls.Add(this.pnlAddUpdate);
            this.Controls.Add(this.btnDeleteSelected);
            this.Controls.Add(this.btnUpdateSelected);
            this.Controls.Add(this.btnAddNewSupplier);
            this.Controls.Add(this.txtSearch);
            this.Controls.Add(this.lstSuppliers);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "SupplierForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.pnlAddUpdate.ResumeLayout(false);
            this.pnlAddUpdate.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListView lstSuppliers;
        private System.Windows.Forms.ColumnHeader SupplierID;
        private System.Windows.Forms.ColumnHeader SupName;
        private MetroFramework.Controls.MetroTextBox txtSearch;
        private MetroFramework.Controls.MetroButton btnAddNewSupplier;
        private MetroFramework.Controls.MetroButton btnUpdateSelected;
        private MetroFramework.Controls.MetroButton btnDeleteSelected;
        private MetroFramework.Components.MetroStyleExtender metroStyleExtender1;
        private MetroFramework.Controls.MetroPanel pnlAddUpdate;
        private MetroFramework.Controls.MetroButton btnAdd;
        private MetroFramework.Controls.MetroButton btnCancel1;
        private MetroFramework.Controls.MetroTextBox txtSupplierID;
        private MetroFramework.Controls.MetroTextBox txtSupName;
        private MetroFramework.Controls.MetroLabel lblSupName;
        private MetroFramework.Controls.MetroLabel lblSupplierID;
        private MetroFramework.Controls.MetroLabel metroLabel1;
    }
}

