using System.Drawing.Drawing2D;

namespace TravelExpertsTerm2
{
    partial class MainForm
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
            this.metroPanel1 = new MetroFramework.Controls.MetroPanel();
            this.btnPackages = new MetroFramework.Controls.MetroButton();
            this.BtnProdSup = new MetroFramework.Controls.MetroButton();
            this.btnProducts = new MetroFramework.Controls.MetroButton();
            this.btnSuppliers = new MetroFramework.Controls.MetroButton();
            this.metroStyleManager1 = new MetroFramework.Components.MetroStyleManager(this.components);
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.metroPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.metroStyleManager1)).BeginInit();
            this.SuspendLayout();
            // 
            // metroPanel1
            // 
            this.metroPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.metroPanel1.AutoScroll = true;
            this.metroPanel1.BackColor = System.Drawing.Color.White;
            this.metroPanel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.metroPanel1.Controls.Add(this.btnPackages);
            this.metroPanel1.Controls.Add(this.BtnProdSup);
            this.metroPanel1.Controls.Add(this.btnProducts);
            this.metroPanel1.Controls.Add(this.btnSuppliers);
            this.metroPanel1.HorizontalScrollbar = true;
            this.metroPanel1.HorizontalScrollbarBarColor = true;
            this.metroPanel1.HorizontalScrollbarHighlightOnWheel = false;
            this.metroPanel1.HorizontalScrollbarSize = 14;
            this.metroPanel1.Location = new System.Drawing.Point(30, 83);
            this.metroPanel1.Margin = new System.Windows.Forms.Padding(4);
            this.metroPanel1.Name = "metroPanel1";
            this.metroPanel1.Size = new System.Drawing.Size(187, 751);
            this.metroPanel1.Style = MetroFramework.MetroColorStyle.Silver;
            this.metroPanel1.TabIndex = 4;
            this.metroPanel1.Theme = MetroFramework.MetroThemeStyle.Light;
            this.metroPanel1.UseCustomBackColor = true;
            this.metroPanel1.VerticalScrollbar = true;
            this.metroPanel1.VerticalScrollbarBarColor = true;
            this.metroPanel1.VerticalScrollbarHighlightOnWheel = false;
            this.metroPanel1.VerticalScrollbarSize = 15;
            // 
            // btnPackages
            // 
            this.btnPackages.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(174)))), ((int)(((byte)(219)))));
            this.btnPackages.BackgroundImage = global::TravelExpertsTerm2.Properties.Resources.Package3;
            this.btnPackages.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnPackages.FontSize = MetroFramework.MetroButtonSize.Tall;
            this.btnPackages.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.btnPackages.Highlight = true;
            this.btnPackages.Location = new System.Drawing.Point(19, 40);
            this.btnPackages.Name = "btnPackages";
            this.btnPackages.Size = new System.Drawing.Size(146, 146);
            this.btnPackages.Style = MetroFramework.MetroColorStyle.Brown;
            this.btnPackages.TabIndex = 8;
            this.btnPackages.Text = "Packages";
            this.btnPackages.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnPackages.UseCustomBackColor = true;
            this.btnPackages.UseCustomForeColor = true;
            this.btnPackages.UseSelectable = true;
            this.btnPackages.UseStyleColors = true;
            this.btnPackages.Click += new System.EventHandler(this.metroTile1_Click);
            // 
            // BtnProdSup
            // 
            this.BtnProdSup.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(124)))), ((int)(((byte)(65)))), ((int)(((byte)(153)))));
            this.BtnProdSup.BackgroundImage = global::TravelExpertsTerm2.Properties.Resources.ProdSup;
            this.BtnProdSup.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.BtnProdSup.FontSize = MetroFramework.MetroButtonSize.Tall;
            this.BtnProdSup.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.BtnProdSup.Highlight = true;
            this.BtnProdSup.Location = new System.Drawing.Point(19, 220);
            this.BtnProdSup.Name = "BtnProdSup";
            this.BtnProdSup.Size = new System.Drawing.Size(146, 146);
            this.BtnProdSup.Style = MetroFramework.MetroColorStyle.Brown;
            this.BtnProdSup.TabIndex = 7;
            this.BtnProdSup.Text = "ProductSupplier";
            this.BtnProdSup.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.BtnProdSup.UseCustomBackColor = true;
            this.BtnProdSup.UseCustomForeColor = true;
            this.BtnProdSup.UseSelectable = true;
            this.BtnProdSup.UseStyleColors = true;
            this.BtnProdSup.Click += new System.EventHandler(this.BtnProdSup_Click);
            // 
            // btnProducts
            // 
            this.btnProducts.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(209)))), ((int)(((byte)(17)))), ((int)(((byte)(65)))));
            this.btnProducts.BackgroundImage = global::TravelExpertsTerm2.Properties.Resources.Products;
            this.btnProducts.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnProducts.FontSize = MetroFramework.MetroButtonSize.Tall;
            this.btnProducts.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.btnProducts.Highlight = true;
            this.btnProducts.Location = new System.Drawing.Point(19, 394);
            this.btnProducts.Name = "btnProducts";
            this.btnProducts.Size = new System.Drawing.Size(146, 146);
            this.btnProducts.Style = MetroFramework.MetroColorStyle.Brown;
            this.btnProducts.TabIndex = 6;
            this.btnProducts.Text = "Products";
            this.btnProducts.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnProducts.UseCustomBackColor = true;
            this.btnProducts.UseCustomForeColor = true;
            this.btnProducts.UseSelectable = true;
            this.btnProducts.UseStyleColors = true;
            this.btnProducts.Click += new System.EventHandler(this.metroButton2_Click);
            // 
            // btnSuppliers
            // 
            this.btnSuppliers.BackColor = System.Drawing.Color.DarkOrange;
            this.btnSuppliers.BackgroundImage = global::TravelExpertsTerm2.Properties.Resources.Supplier;
            this.btnSuppliers.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnSuppliers.FontSize = MetroFramework.MetroButtonSize.Tall;
            this.btnSuppliers.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.btnSuppliers.Highlight = true;
            this.btnSuppliers.Location = new System.Drawing.Point(19, 574);
            this.btnSuppliers.Name = "btnSuppliers";
            this.btnSuppliers.Size = new System.Drawing.Size(146, 146);
            this.btnSuppliers.Style = MetroFramework.MetroColorStyle.Brown;
            this.btnSuppliers.TabIndex = 5;
            this.btnSuppliers.Text = "Suppliers";
            this.btnSuppliers.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnSuppliers.UseCustomBackColor = true;
            this.btnSuppliers.UseCustomForeColor = true;
            this.btnSuppliers.UseSelectable = true;
            this.btnSuppliers.UseStyleColors = true;
            this.btnSuppliers.Click += new System.EventHandler(this.metroButton1_Click);
            // 
            // metroStyleManager1
            // 
            this.metroStyleManager1.Owner = this;
            this.metroStyleManager1.Style = MetroFramework.MetroColorStyle.Magenta;
            // 
            // panel2
            // 
            this.panel2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel2.AutoScroll = true;
            this.panel2.BackColor = System.Drawing.Color.White;
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel2.Location = new System.Drawing.Point(217, 83);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1215, 750);
            this.panel2.TabIndex = 8;
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.panel1.AutoSize = true;
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(119)))), ((int)(((byte)(53)))));
            this.panel1.Location = new System.Drawing.Point(-1, -1);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(24, 872);
            this.panel1.TabIndex = 7;
            // 
            // panel3
            // 
            this.panel3.BackgroundImage = global::TravelExpertsTerm2.Properties.Resources.TravelExpertLogo;
            this.panel3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panel3.Location = new System.Drawing.Point(24, 7);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(298, 75);
            this.panel3.TabIndex = 10;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.BorderStyle = MetroFramework.Forms.MetroFormBorderStyle.FixedSingle;
            this.ClientSize = new System.Drawing.Size(1455, 864);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.metroPanel1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "MainForm";
            this.Padding = new System.Windows.Forms.Padding(30, 83, 30, 28);
            this.Resizable = false;
            this.ShadowType = MetroFramework.Forms.MetroFormShadowType.AeroShadow;
            this.Style = MetroFramework.MetroColorStyle.Orange;
            this.Text = "Travel Experts";
            this.TransparencyKey = System.Drawing.Color.Empty;
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.Resize += new System.EventHandler(this.MainForm_Resize);
            this.metroPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.metroStyleManager1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private MetroFramework.Controls.MetroPanel metroPanel1;
        private MetroFramework.Components.MetroStyleManager metroStyleManager1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel1;
        private MetroFramework.Controls.MetroButton btnSuppliers;
        private MetroFramework.Controls.MetroButton btnPackages;
        private MetroFramework.Controls.MetroButton BtnProdSup;
        private MetroFramework.Controls.MetroButton btnProducts;
        private System.Windows.Forms.Panel panel3;
    }
}

