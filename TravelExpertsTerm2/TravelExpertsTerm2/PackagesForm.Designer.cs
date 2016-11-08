using System.Windows.Forms;

namespace TravelExpertsTerm2
{
    partial class PackagesForm
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
            this.StartDateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.EndDateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.LinkedProductSuppliersListBox = new System.Windows.Forms.ListBox();
            this.OtherProductSuppliersListBox = new System.Windows.Forms.ListBox();
            this.PackageSelectorComboBox = new MetroFramework.Controls.MetroComboBox();
            this.NameTextBox = new MetroFramework.Controls.MetroTextBox();
            this.DescriptionTextBox = new MetroFramework.Controls.MetroTextBox();
            this.BasePriceTextBox = new MetroFramework.Controls.MetroTextBox();
            this.AgencyCommissionTextBox = new MetroFramework.Controls.MetroTextBox();
            this.metroLabel1 = new MetroFramework.Controls.MetroLabel();
            this.metroLabel2 = new MetroFramework.Controls.MetroLabel();
            this.metroLabel3 = new MetroFramework.Controls.MetroLabel();
            this.metroLabel4 = new MetroFramework.Controls.MetroLabel();
            this.metroLabel5 = new MetroFramework.Controls.MetroLabel();
            this.metroLabel6 = new MetroFramework.Controls.MetroLabel();
            this.TotalLabel = new MetroFramework.Controls.MetroLabel();
            this.metroLabel7 = new MetroFramework.Controls.MetroLabel();
            this.DeleteButton = new MetroFramework.Controls.MetroButton();
            this.EditCancelButton = new MetroFramework.Controls.MetroButton();
            this.NewSaveButton = new MetroFramework.Controls.MetroButton();
            this.btnAddSupplier = new MetroFramework.Controls.MetroButton();
            this.btnRemoveSupplier = new MetroFramework.Controls.MetroButton();
            this.metroLabel8 = new MetroFramework.Controls.MetroLabel();
            this.metroLabel10 = new MetroFramework.Controls.MetroLabel();
            this.SuspendLayout();
            // 
            // StartDateTimePicker
            // 
            this.StartDateTimePicker.Font = new System.Drawing.Font("Segoe UI Light", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.StartDateTimePicker.Location = new System.Drawing.Point(125, 127);
            this.StartDateTimePicker.MinDate = new System.DateTime(2000, 1, 1, 0, 0, 0, 0);
            this.StartDateTimePicker.Name = "StartDateTimePicker";
            this.StartDateTimePicker.Size = new System.Drawing.Size(200, 25);
            this.StartDateTimePicker.TabIndex = 7;
            // 
            // EndDateTimePicker
            // 
            this.EndDateTimePicker.CalendarTitleBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(250)))), ((int)(((byte)(250)))));
            this.EndDateTimePicker.Font = new System.Drawing.Font("Segoe UI Light", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.EndDateTimePicker.Location = new System.Drawing.Point(125, 155);
            this.EndDateTimePicker.MinDate = new System.DateTime(2000, 1, 1, 0, 0, 0, 0);
            this.EndDateTimePicker.Name = "EndDateTimePicker";
            this.EndDateTimePicker.Size = new System.Drawing.Size(200, 25);
            this.EndDateTimePicker.TabIndex = 8;
            // 
            // LinkedProductSuppliersListBox
            // 
            this.LinkedProductSuppliersListBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(250)))), ((int)(((byte)(250)))));
            this.LinkedProductSuppliersListBox.Font = new System.Drawing.Font("Segoe UI Semilight", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LinkedProductSuppliersListBox.FormattingEnabled = true;
            this.LinkedProductSuppliersListBox.ItemHeight = 17;
            this.LinkedProductSuppliersListBox.Location = new System.Drawing.Point(353, 60);
            this.LinkedProductSuppliersListBox.Name = "LinkedProductSuppliersListBox";
            this.LinkedProductSuppliersListBox.Size = new System.Drawing.Size(204, 259);
            this.LinkedProductSuppliersListBox.Sorted = true;
            this.LinkedProductSuppliersListBox.TabIndex = 20;
            this.LinkedProductSuppliersListBox.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.LinkedProductSuppliersListBox_MouseDoubleClick);
            // 
            // OtherProductSuppliersListBox
            // 
            this.OtherProductSuppliersListBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(250)))), ((int)(((byte)(250)))));
            this.OtherProductSuppliersListBox.Font = new System.Drawing.Font("Segoe UI Semilight", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.OtherProductSuppliersListBox.FormattingEnabled = true;
            this.OtherProductSuppliersListBox.ItemHeight = 17;
            this.OtherProductSuppliersListBox.Location = new System.Drawing.Point(648, 60);
            this.OtherProductSuppliersListBox.Name = "OtherProductSuppliersListBox";
            this.OtherProductSuppliersListBox.Size = new System.Drawing.Size(204, 259);
            this.OtherProductSuppliersListBox.Sorted = true;
            this.OtherProductSuppliersListBox.TabIndex = 21;
            this.OtherProductSuppliersListBox.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.OtherProductSuppliersListBox_MouseDoubleClick);
            // 
            // PackageSelectorComboBox
            // 
            this.PackageSelectorComboBox.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.PackageSelectorComboBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(250)))), ((int)(((byte)(250)))));
            this.PackageSelectorComboBox.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.PackageSelectorComboBox.FormattingEnabled = true;
            this.PackageSelectorComboBox.ItemHeight = 24;
            this.PackageSelectorComboBox.Location = new System.Drawing.Point(125, 60);
            this.PackageSelectorComboBox.Name = "PackageSelectorComboBox";
            this.PackageSelectorComboBox.Size = new System.Drawing.Size(200, 30);
            this.PackageSelectorComboBox.Style = MetroFramework.MetroColorStyle.Orange;
            this.PackageSelectorComboBox.TabIndex = 24;
            this.PackageSelectorComboBox.UseCustomBackColor = true;
            this.PackageSelectorComboBox.UseSelectable = true;
            this.PackageSelectorComboBox.UseStyleColors = true;
            this.PackageSelectorComboBox.SelectedIndexChanged += new System.EventHandler(this.PackageSelectorComboBox_SelectedIndexChanged);
            // 
            // NameTextBox
            // 
            this.NameTextBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(250)))), ((int)(((byte)(250)))));
            this.NameTextBox.Enabled = false;
            this.NameTextBox.FontSize = MetroFramework.MetroTextBoxSize.Medium;
            this.NameTextBox.Lines = new string[0];
            this.NameTextBox.Location = new System.Drawing.Point(125, 96);
            this.NameTextBox.MaxLength = 32767;
            this.NameTextBox.Name = "NameTextBox";
            this.NameTextBox.PasswordChar = '\0';
            this.NameTextBox.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.NameTextBox.SelectedText = "";
            this.NameTextBox.Size = new System.Drawing.Size(200, 23);
            this.NameTextBox.TabIndex = 25;
            this.NameTextBox.UseCustomBackColor = true;
            this.NameTextBox.UseSelectable = true;
            // 
            // DescriptionTextBox
            // 
            this.DescriptionTextBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(250)))), ((int)(((byte)(250)))));
            this.DescriptionTextBox.FontSize = MetroFramework.MetroTextBoxSize.Medium;
            this.DescriptionTextBox.Lines = new string[0];
            this.DescriptionTextBox.Location = new System.Drawing.Point(125, 179);
            this.DescriptionTextBox.MaxLength = 32767;
            this.DescriptionTextBox.Multiline = true;
            this.DescriptionTextBox.Name = "DescriptionTextBox";
            this.DescriptionTextBox.PasswordChar = '\0';
            this.DescriptionTextBox.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.DescriptionTextBox.SelectedText = "";
            this.DescriptionTextBox.Size = new System.Drawing.Size(200, 92);
            this.DescriptionTextBox.Style = MetroFramework.MetroColorStyle.Orange;
            this.DescriptionTextBox.TabIndex = 26;
            this.DescriptionTextBox.UseCustomBackColor = true;
            this.DescriptionTextBox.UseSelectable = true;
            // 
            // BasePriceTextBox
            // 
            this.BasePriceTextBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(250)))), ((int)(((byte)(250)))));
            this.BasePriceTextBox.FontSize = MetroFramework.MetroTextBoxSize.Medium;
            this.BasePriceTextBox.Lines = new string[0];
            this.BasePriceTextBox.Location = new System.Drawing.Point(125, 276);
            this.BasePriceTextBox.MaxLength = 32767;
            this.BasePriceTextBox.Name = "BasePriceTextBox";
            this.BasePriceTextBox.PasswordChar = '\0';
            this.BasePriceTextBox.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.BasePriceTextBox.SelectedText = "";
            this.BasePriceTextBox.Size = new System.Drawing.Size(200, 23);
            this.BasePriceTextBox.Style = MetroFramework.MetroColorStyle.Orange;
            this.BasePriceTextBox.TabIndex = 27;
            this.BasePriceTextBox.UseCustomBackColor = true;
            this.BasePriceTextBox.UseSelectable = true;
            // 
            // AgencyCommissionTextBox
            // 
            this.AgencyCommissionTextBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(250)))), ((int)(((byte)(250)))));
            this.AgencyCommissionTextBox.FontSize = MetroFramework.MetroTextBoxSize.Medium;
            this.AgencyCommissionTextBox.Lines = new string[0];
            this.AgencyCommissionTextBox.Location = new System.Drawing.Point(125, 304);
            this.AgencyCommissionTextBox.MaxLength = 32767;
            this.AgencyCommissionTextBox.Name = "AgencyCommissionTextBox";
            this.AgencyCommissionTextBox.PasswordChar = '\0';
            this.AgencyCommissionTextBox.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.AgencyCommissionTextBox.SelectedText = "";
            this.AgencyCommissionTextBox.Size = new System.Drawing.Size(200, 23);
            this.AgencyCommissionTextBox.TabIndex = 28;
            this.AgencyCommissionTextBox.UseCustomBackColor = true;
            this.AgencyCommissionTextBox.UseSelectable = true;
            // 
            // metroLabel1
            // 
            this.metroLabel1.AutoSize = true;
            this.metroLabel1.Location = new System.Drawing.Point(69, 96);
            this.metroLabel1.Name = "metroLabel1";
            this.metroLabel1.Size = new System.Drawing.Size(50, 20);
            this.metroLabel1.TabIndex = 29;
            this.metroLabel1.Text = "Name:";
            // 
            // metroLabel2
            // 
            this.metroLabel2.AutoSize = true;
            this.metroLabel2.Location = new System.Drawing.Point(47, 129);
            this.metroLabel2.Name = "metroLabel2";
            this.metroLabel2.Size = new System.Drawing.Size(72, 20);
            this.metroLabel2.TabIndex = 30;
            this.metroLabel2.Text = "Start Date:";
            // 
            // metroLabel3
            // 
            this.metroLabel3.AutoSize = true;
            this.metroLabel3.Location = new System.Drawing.Point(50, 155);
            this.metroLabel3.Name = "metroLabel3";
            this.metroLabel3.Size = new System.Drawing.Size(69, 20);
            this.metroLabel3.TabIndex = 31;
            this.metroLabel3.Text = "End Date:";
            // 
            // metroLabel4
            // 
            this.metroLabel4.AutoSize = true;
            this.metroLabel4.Location = new System.Drawing.Point(37, 185);
            this.metroLabel4.Name = "metroLabel4";
            this.metroLabel4.Size = new System.Drawing.Size(82, 20);
            this.metroLabel4.TabIndex = 32;
            this.metroLabel4.Text = "Description:";
            // 
            // metroLabel5
            // 
            this.metroLabel5.AutoSize = true;
            this.metroLabel5.Location = new System.Drawing.Point(76, 279);
            this.metroLabel5.Name = "metroLabel5";
            this.metroLabel5.Size = new System.Drawing.Size(43, 20);
            this.metroLabel5.TabIndex = 33;
            this.metroLabel5.Text = "Price:";
            // 
            // metroLabel6
            // 
            this.metroLabel6.AutoSize = true;
            this.metroLabel6.Location = new System.Drawing.Point(15, 307);
            this.metroLabel6.Name = "metroLabel6";
            this.metroLabel6.Size = new System.Drawing.Size(138, 20);
            this.metroLabel6.TabIndex = 34;
            this.metroLabel6.Text = "Agency Commission:";
            // 
            // TotalLabel
            // 
            this.TotalLabel.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.TotalLabel.FontWeight = MetroFramework.MetroLabelWeight.Regular;
            this.TotalLabel.Location = new System.Drawing.Point(125, 346);
            this.TotalLabel.Name = "TotalLabel";
            this.TotalLabel.Size = new System.Drawing.Size(117, 23);
            this.TotalLabel.TabIndex = 35;
            this.TotalLabel.Text = "total";
            this.TotalLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // metroLabel7
            // 
            this.metroLabel7.AutoSize = true;
            this.metroLabel7.Location = new System.Drawing.Point(77, 346);
            this.metroLabel7.Name = "metroLabel7";
            this.metroLabel7.Size = new System.Drawing.Size(42, 20);
            this.metroLabel7.TabIndex = 36;
            this.metroLabel7.Text = "Total:";
            // 
            // DeleteButton
            // 
            this.DeleteButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(250)))), ((int)(((byte)(250)))));
            this.DeleteButton.Location = new System.Drawing.Point(270, 393);
            this.DeleteButton.Name = "DeleteButton";
            this.DeleteButton.Size = new System.Drawing.Size(75, 23);
            this.DeleteButton.Style = MetroFramework.MetroColorStyle.Orange;
            this.DeleteButton.TabIndex = 37;
            this.DeleteButton.Text = "Delete";
            this.DeleteButton.UseCustomBackColor = true;
            this.DeleteButton.UseSelectable = true;
            this.DeleteButton.UseStyleColors = true;
            this.DeleteButton.Click += new System.EventHandler(this.DeleteButton_Click);
            // 
            // EditCancelButton
            // 
            this.EditCancelButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(250)))), ((int)(((byte)(250)))));
            this.EditCancelButton.Location = new System.Drawing.Point(125, 393);
            this.EditCancelButton.Name = "EditCancelButton";
            this.EditCancelButton.Size = new System.Drawing.Size(85, 23);
            this.EditCancelButton.Style = MetroFramework.MetroColorStyle.Orange;
            this.EditCancelButton.TabIndex = 38;
            this.EditCancelButton.Text = "Edit/Cancel";
            this.EditCancelButton.UseCustomBackColor = true;
            this.EditCancelButton.UseSelectable = true;
            this.EditCancelButton.UseStyleColors = true;
            this.EditCancelButton.Click += new System.EventHandler(this.EditCancelButton_Click);
            // 
            // NewSaveButton
            // 
            this.NewSaveButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(250)))), ((int)(((byte)(250)))));
            this.NewSaveButton.Location = new System.Drawing.Point(15, 393);
            this.NewSaveButton.Name = "NewSaveButton";
            this.NewSaveButton.Size = new System.Drawing.Size(96, 23);
            this.NewSaveButton.Style = MetroFramework.MetroColorStyle.Orange;
            this.NewSaveButton.TabIndex = 39;
            this.NewSaveButton.Text = "New/Save";
            this.NewSaveButton.UseCustomBackColor = true;
            this.NewSaveButton.UseSelectable = true;
            this.NewSaveButton.UseStyleColors = true;
            this.NewSaveButton.Click += new System.EventHandler(this.NewSaveButton_Click);
            // 
            // btnAddSupplier
            // 
            this.btnAddSupplier.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(250)))), ((int)(((byte)(250)))));
            this.btnAddSupplier.Enabled = false;
            this.btnAddSupplier.Location = new System.Drawing.Point(566, 75);
            this.btnAddSupplier.Name = "btnAddSupplier";
            this.btnAddSupplier.Size = new System.Drawing.Size(75, 26);
            this.btnAddSupplier.Style = MetroFramework.MetroColorStyle.Orange;
            this.btnAddSupplier.TabIndex = 40;
            this.btnAddSupplier.Text = "<-Add";
            this.btnAddSupplier.UseCustomBackColor = true;
            this.btnAddSupplier.UseSelectable = true;
            this.btnAddSupplier.UseStyleColors = true;
            this.btnAddSupplier.Visible = false;
            this.btnAddSupplier.Click += new System.EventHandler(this.btnAddSupplier_Click);
            // 
            // btnRemoveSupplier
            // 
            this.btnRemoveSupplier.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(250)))), ((int)(((byte)(250)))));
            this.btnRemoveSupplier.Enabled = false;
            this.btnRemoveSupplier.Location = new System.Drawing.Point(566, 273);
            this.btnRemoveSupplier.Name = "btnRemoveSupplier";
            this.btnRemoveSupplier.Size = new System.Drawing.Size(75, 26);
            this.btnRemoveSupplier.Style = MetroFramework.MetroColorStyle.Orange;
            this.btnRemoveSupplier.TabIndex = 41;
            this.btnRemoveSupplier.Text = "Remove ->";
            this.btnRemoveSupplier.UseCustomBackColor = true;
            this.btnRemoveSupplier.UseSelectable = true;
            this.btnRemoveSupplier.UseStyleColors = true;
            this.btnRemoveSupplier.Visible = false;
            this.btnRemoveSupplier.Click += new System.EventHandler(this.btnRemoveSupplier_Click);
            // 
            // metroLabel8
            // 
            this.metroLabel8.AutoSize = true;
            this.metroLabel8.FontWeight = MetroFramework.MetroLabelWeight.Regular;
            this.metroLabel8.Location = new System.Drawing.Point(401, 36);
            this.metroLabel8.Name = "metroLabel8";
            this.metroLabel8.Size = new System.Drawing.Size(125, 20);
            this.metroLabel8.TabIndex = 42;
            this.metroLabel8.Text = "Product Suppliers";
            // 
            // metroLabel10
            // 
            this.metroLabel10.AutoSize = true;
            this.metroLabel10.FontWeight = MetroFramework.MetroLabelWeight.Regular;
            this.metroLabel10.Location = new System.Drawing.Point(178, 37);
            this.metroLabel10.Name = "metroLabel10";
            this.metroLabel10.Size = new System.Drawing.Size(120, 20);
            this.metroLabel10.TabIndex = 44;
            this.metroLabel10.Text = "Select a Package";
            // 
            // PackagesForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(882, 618);
            this.Controls.Add(this.metroLabel10);
            this.Controls.Add(this.metroLabel8);
            this.Controls.Add(this.btnRemoveSupplier);
            this.Controls.Add(this.btnAddSupplier);
            this.Controls.Add(this.NewSaveButton);
            this.Controls.Add(this.EditCancelButton);
            this.Controls.Add(this.DeleteButton);
            this.Controls.Add(this.metroLabel7);
            this.Controls.Add(this.TotalLabel);
            this.Controls.Add(this.metroLabel6);
            this.Controls.Add(this.metroLabel5);
            this.Controls.Add(this.metroLabel4);
            this.Controls.Add(this.metroLabel3);
            this.Controls.Add(this.metroLabel2);
            this.Controls.Add(this.metroLabel1);
            this.Controls.Add(this.AgencyCommissionTextBox);
            this.Controls.Add(this.BasePriceTextBox);
            this.Controls.Add(this.DescriptionTextBox);
            this.Controls.Add(this.NameTextBox);
            this.Controls.Add(this.PackageSelectorComboBox);
            this.Controls.Add(this.OtherProductSuppliersListBox);
            this.Controls.Add(this.LinkedProductSuppliersListBox);
            this.Controls.Add(this.EndDateTimePicker);
            this.Controls.Add(this.StartDateTimePicker);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "PackagesForm";
            this.Text = "PackagesPrototype";
            this.Load += new System.EventHandler(this.PackagesPrototypeForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.DateTimePicker StartDateTimePicker;
        private System.Windows.Forms.DateTimePicker EndDateTimePicker;
        private System.Windows.Forms.ListBox LinkedProductSuppliersListBox;
        private System.Windows.Forms.ListBox OtherProductSuppliersListBox;
        private MetroFramework.Controls.MetroComboBox PackageSelectorComboBox;
        private MetroFramework.Controls.MetroTextBox NameTextBox;
        private MetroFramework.Controls.MetroTextBox DescriptionTextBox;
        private MetroFramework.Controls.MetroTextBox BasePriceTextBox;
        private MetroFramework.Controls.MetroTextBox AgencyCommissionTextBox;
        private MetroFramework.Controls.MetroLabel metroLabel1;
        private MetroFramework.Controls.MetroLabel metroLabel2;
        private MetroFramework.Controls.MetroLabel metroLabel3;
        private MetroFramework.Controls.MetroLabel metroLabel4;
        private MetroFramework.Controls.MetroLabel metroLabel5;
        private MetroFramework.Controls.MetroLabel metroLabel6;
        private MetroFramework.Controls.MetroLabel TotalLabel;
        private MetroFramework.Controls.MetroLabel metroLabel7;
        private MetroFramework.Controls.MetroButton DeleteButton;
        private MetroFramework.Controls.MetroButton EditCancelButton;
        private MetroFramework.Controls.MetroButton NewSaveButton;
        private MetroFramework.Controls.MetroButton btnAddSupplier;
        private MetroFramework.Controls.MetroButton btnRemoveSupplier;
        private MetroFramework.Controls.MetroLabel metroLabel8;
        private MetroFramework.Controls.MetroLabel metroLabel10;
    }
}