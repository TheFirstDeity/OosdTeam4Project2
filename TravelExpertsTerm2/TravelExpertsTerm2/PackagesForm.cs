// Author: Team 4 (See Annotations)
// Project: TravelExpertsTerm2
// Date: 2016-01

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using JetBrains.Annotations;
using TravelDatabase;

namespace TravelExpertsTerm2
{
    [Devin]
    public partial class PackagesForm : Form
    {
        private readonly BindingList<Package> _Packages = new BindingList<Package>();
        private readonly BindingList<ProductSupplier> _LinkedProductSuppliers = new BindingList<ProductSupplier>();
        private readonly BindingList<ProductSupplier> _OtherProductSuppliers = new BindingList<ProductSupplier>();
        private bool _EditMode;
        private bool _CreateNew; // used to track whether the user clicked "New" or "Edit"

        [CanBeNull]
        private Package SelectedPackage
        {
            get { return (Package) PackageSelectorComboBox.SelectedItem; }
            set { PackageSelectorComboBox.SelectedItem = value; }
        }

        #region Constructor

        public PackagesForm()
        {
            InitializeComponent();

            // Bind Package Selector
            PackageSelectorComboBox.DataSource = _Packages;
            PackageSelectorComboBox.DisplayMember = nameof(Package.Name);
            PackageSelectorComboBox.ValueMember = nameof(Package.PackageId);

            // Bind OtherProductSuppliers
            OtherProductSuppliersListBox.DataSource = _OtherProductSuppliers;
            OtherProductSuppliersListBox.DisplayMember = nameof(ProductSupplier.FullName);
            OtherProductSuppliersListBox.ValueMember = nameof(ProductSupplier.ProductSupplierId);

            // Bind LinkedProductSuppliers
            LinkedProductSuppliersListBox.DataSource = _LinkedProductSuppliers;
            LinkedProductSuppliersListBox.DisplayMember = nameof(ProductSupplier.FullName);
            LinkedProductSuppliersListBox.ValueMember = nameof(ProductSupplier.ProductSupplierId);
        }
        
        #endregion

        #region Event Handlers

        private void PackagesPrototypeForm_Load(object sender, EventArgs e)
        {
            _Packages.Clear();
            SetEditMode(false);
            PackageSelectorComboBox.Enabled = true;

            // get product suppliers
            IEnumerable<ProductSupplier> allProductSuppliers;
            if (!TryReport(Database.ProductSuppliers.GetEntities, out allProductSuppliers)) return;
            
            // add and display them
            foreach (var productSupplier in allProductSuppliers)
                _OtherProductSuppliers.Add(productSupplier);

            // get packages, reporting errors
            IEnumerable<Package> packages;
            if (!TryReport(Database.Packages.GetEntitiesWithChildren, out packages)) return;
            foreach (var package in packages)
            {
                _Packages.Add(package);

                // Associate package with the object references in the ListBox, instead of the
                // ones that were created when the package was parsed. This is inefficient and
                // a bit of a hack. Would be better to pull down the whole Packages_Products_Suppliers
                // table and do the associations that way.
                var psIds = package.ProductSuppliers.Select(ps => ps.ProductSupplierId).ToList();
                package.ProductSuppliers.Clear();
                package.ProductSuppliers.AddRange(
                    psIds.Select(id => 
                        _OtherProductSuppliers
                        .First(ps => ps.ProductSupplierId == id)));
            }
                
            ShowPackage(SelectedPackage);
        }

        private void PackageSelectorComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            ShowPackage(SelectedPackage);
        }

        private void OtherProductSuppliersListBox_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            var productSupplier = (ProductSupplier)((ListBox)sender).SelectedItem;
            if (productSupplier == null) return;

            _OtherProductSuppliers.Remove(productSupplier);
            _LinkedProductSuppliers.Add(productSupplier);
        }

        private void LinkedProductSuppliersListBox_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            var productSupplier = (ProductSupplier)((ListBox)sender).SelectedItem;
            if (productSupplier == null) return;

            _LinkedProductSuppliers.Remove(productSupplier);
            _OtherProductSuppliers.Add(productSupplier);
        }

        private void DeleteButton_Click(object sender, EventArgs e)
        {
            // ReSharper disable once InvertIf
            if (DialogResult.Yes == MessageBox.Show(@"This will permanently delete this package. Continue?",
                @"Confirm Delete", MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning,
                MessageBoxDefaultButton.Button2) 
                && TryReport(() =>
                {
                    if (SelectedPackage != null) Database.Packages.DeleteEntity(SelectedPackage);
                }))
            {
                _Packages.Remove(SelectedPackage);
                ShowPackage(SelectedPackage);
            }
            PackageSelectorComboBox.Focus();
        }

        private void EditCancelButton_Click(object sender, EventArgs e)
        {
            if (_EditMode) // clicked Cancel
            {
                SetEditMode(false);
                ShowPackage(SelectedPackage);
                PackageSelectorComboBox.Focus();
            }
            else // clicked Edit
            {
                _CreateNew = false; // existing item should be updated, not created
                SetEditMode(true);
                NameTextBox.Focus();
            }
        }

        private void NewSaveButton_Click(object sender, EventArgs e)
        {
            if (_EditMode) // clicked Save
            {
                // does not parse/validate the ID property, but that shouldn't ever matter
                var package = ParsePackage();
                if (!ValidateAndDisplayErrors(package, "Please fix the following:")) return;

                if (_CreateNew)
                {
                    int id;
                    if (!TryReport(() => Database.Packages.AddEntity(package), out id)) return;

                    if (id < 0) // negative means item wasn't added
                    {
                        Error("Could not add item.");
                        return;
                    }

                    package.PackageId = id; // save actual id before adding/displaying on form
                    _Packages.Add(package);
                    SelectedPackage = package;
                   
                }
                else // updating package
                {
                    if (SelectedPackage == null)
                    {
                        Error("No package selected.");
                        return;
                    }
                    package.PackageId = SelectedPackage.PackageId;
                    
                    bool success;
                    if (!TryReport(() => Database.Packages.UpdateEntity(package), out success)) return;
                    if (!success)
                    {
                        Error("Could not update item.");
                        return;
                    }

                    // on success, replace the old object reference with the new one we just parsed
                    _Packages[_Packages.IndexOf(SelectedPackage)] = package;
                    SelectedPackage = package;
                    NameTextBox.Focus();
                }
                LinkedProductSuppliersListBox.Focus();

                SetEditMode(false); // turn off edit mode on success, else return
            }
            else // clicked New
            {
                _CreateNew = true; // new item should be added to the database
                SetEditMode(true);
                ShowPackage(null); // make fields blank
                NameTextBox.Focus();
            }
        }

        #endregion

        #region Private Methods

        private void ShowPackage([CanBeNull] Package package)
        {
            NameTextBox.Text = package?.Name;
            DescriptionTextBox.Text = package?.Description;
            StartDateTimePicker.Value = package?.StartDate ?? DateTime.Today;
            EndDateTimePicker.Value = package?.EndDate ?? DateTime.Today + TimeSpan.FromDays(1);

            var basePrice = package?.BasePrice ?? 0;
            var agencyCommission = package?.AgencyCommission ?? 0;
            BasePriceTextBox.Text = basePrice.ToString("C2");
            AgencyCommissionTextBox.Text = agencyCommission.ToString("C2");
            TotalLabel.Text = (basePrice + agencyCommission).ToString("C2");

            // Clear linked ProductSuppliers
            foreach (var linkedProductSupplier in _LinkedProductSuppliers)
                _OtherProductSuppliers.Add(linkedProductSupplier); // Add them back into the "Other" list box
            _LinkedProductSuppliers.Clear(); // Clear related product suppliers
            
            // Add current package's ProductSuppliers
            foreach (var productSupplier in package?.ProductSuppliers ?? new List<ProductSupplier>())
            {
                _LinkedProductSuppliers.Add(productSupplier);
                _OtherProductSuppliers.Remove(productSupplier);
            }
        }

        [Pure]
        [NotNull]
        private Package ParsePackage()
        {
            decimal basePrice, agencyCommission;
            var package = new Package
            {
                Name = NameTextBox.Text,
                StartDate = StartDateTimePicker.Value,
                EndDate = EndDateTimePicker.Value,
                Description = DescriptionTextBox.Text,
                BasePrice = decimal.TryParse(
                        BasePriceTextBox.Text.Replace("$", string.Empty), out basePrice)
                    ? basePrice : decimal.MinValue,
                AgencyCommission = decimal.TryParse(
                        AgencyCommissionTextBox.Text.Replace("$", string.Empty), out agencyCommission)
                    ? agencyCommission : decimal.MinValue
            };
            package.ProductSuppliers.AddRange(_LinkedProductSuppliers);
            return package;
        }

        private void SetReadonlyFields(bool @readonly)
        {
            NameTextBox.Enabled = !@readonly;
            DescriptionTextBox.Enabled = !@readonly;
            BasePriceTextBox.Enabled = !@readonly;
            AgencyCommissionTextBox.Enabled = !@readonly;
            StartDateTimePicker.Enabled = !@readonly;
            EndDateTimePicker.Enabled = !@readonly;
            btnAddSupplier.Enabled = !@readonly;
            btnRemoveSupplier.Enabled = !@readonly;



            LinkedProductSuppliersListBox.SelectionMode = @readonly ? SelectionMode.None : SelectionMode.One;
            LinkedProductSuppliersListBox.BackColor = @readonly ? Color.FromArgb(250,250,250) : Color.White;
            OtherProductSuppliersListBox.Enabled = !@readonly;
            OtherProductSuppliersListBox.Visible = !@readonly;
            //OtherProductSuppliersLabel.Visible = !@readonly;
            btnAddSupplier.Visible = !@readonly;
            btnRemoveSupplier.Visible = !@readonly;
            TotalLabel.Visible = @readonly;
        }

        private void SetEditMode(bool enabled)
        {
            _EditMode = enabled;

            if (_EditMode)
            {
                NewSaveButton.Text = @"Save";
                EditCancelButton.Text = @"Cancel";
                DeleteButton.Enabled = false;
                PackageSelectorComboBox.Enabled = false;
                SetReadonlyFields(false);
            }
            else
            {
                NewSaveButton.Text = @"New";
                EditCancelButton.Text = @"Edit";
                DeleteButton.Enabled = true;
                PackageSelectorComboBox.Enabled = true;
                SetReadonlyFields(true);
            }
        }

        private void btnAddSupplier_Click(object sender, EventArgs e)
        {
            var productSupplier = (ProductSupplier)OtherProductSuppliersListBox.SelectedItem;
            if (productSupplier == null) return;

            _OtherProductSuppliers.Remove(productSupplier);
            _LinkedProductSuppliers.Add(productSupplier);
            OtherProductSuppliersListBox.Focus();
        }

        private void btnRemoveSupplier_Click(object sender, EventArgs e)
        {
            var productSupplier = (ProductSupplier)LinkedProductSuppliersListBox.SelectedItem;
            if (productSupplier == null) return;

            _LinkedProductSuppliers.Remove(productSupplier);
            _OtherProductSuppliers.Add(productSupplier);
            LinkedProductSuppliersListBox.Focus();
        }
        #endregion

        // TODO: Maybe move these to a shared utility class for use on other forms
        #region Static Utility Methods

        private static bool ValidateAndDisplayErrors([NotNull] IValidatable obj, string header = null)
        {
            var validationResult = obj.ValidateSelf();
            if (!validationResult.IsValid) Error(validationResult.FormattedErrorMessageList(header));
            return validationResult.IsValid;
        }

        private static void Error([NotNull] string message)
        {
            MessageBox.Show(message, @"Error",
                MessageBoxButtons.OK, MessageBoxIcon.Error,
                MessageBoxDefaultButton.Button1);
        }

        private static bool TryReport<TReturn>([NotNull] Func<TReturn> func, out TReturn result)
        {
            try
            {
                result = func();
                return true;
            }
            catch (Exception e)
            {
                Error($"An exception of type {e.GetType().Name} has occurred. {e.Message}");
                result = default(TReturn);
                return false;
            }
        }

        private static bool TryReport([NotNull] Action action)
        {
            try
            {
                action();
                return true;
            }
            catch (Exception e)
            {
                Error($"An exception of type {e.GetType().Name} has occurred. {e.Message}");
                return false;
            }
        }

        #endregion


    }
}
