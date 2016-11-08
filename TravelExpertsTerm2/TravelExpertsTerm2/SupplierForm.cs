// ReSharper disable All
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TravelDatabase;
using TravelDatabase.EntityData;

namespace TravelExpertsTerm2
{
    public partial class SupplierForm : Form
    {

        public string selectedSupplierID = "";
        public string selectedSupName = "";

        public SupplierForm()
        {
            InitializeComponent();
        }

        #region Events
        private void MainForm_Load(object sender, EventArgs e)
        {

            List<Supplier> suppliersList = SupplierDB.GetSuppliers(); //creates supplier list to pass to updateListView()
            updateListView(suppliersList);
        }
        
        //SEARCH FUNCTIONALITY
        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            List<Supplier> suppliersList = SupplierDB.GetSuppliers();  //create list of Supplier objects from DB
            List<Supplier> searchResults = new List<Supplier>();  //create new list of Supplier for search results

            foreach (Supplier supplier in suppliersList)
            {
                if (supplier.SupplierId.ToString().Contains(txtSearch.Text.ToUpper())) //if there is a match
                {
                    searchResults.Add(supplier); //add to search results
                }
            }
            updateListView(searchResults);  //display search results
        }
       
       //selecting items in list view
        private void lstSuppliers_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lstSuppliers.SelectedItems.Count == 1)  //if occuring on item selected not item deselectd
            {
                clearForm();
                try
                {
                    selectedSupplierID = lstSuppliers.Items[lstSuppliers.SelectedIndices[0]].Text.Trim(); //store selected supplier id
                    selectedSupName = lstSuppliers.Items[lstSuppliers.SelectedIndices[0]].SubItems[1].Text.Trim(); //store selected supplier name
                }
                catch (Exception ex)
                {
                    throw ex;
                    //MessageBox.Show(ex.Message);
                }
            }
        }
       
        //Call add function
        private void btnSave_Click(object sender, EventArgs e)
        {
            int integer;

            if (txtSupplierID.Text == "")  //if no SupplierID is entered
            {
                //display error
                MessageBox.Show("Please fill in all fields.");
                txtSupplierID.Focus();
            }

            else if (txtSupName.Text == "") //if no Supplier name is entered
            {
                //display error message
                MessageBox.Show("Please fill in all fields.");
                txtSupName.Focus();
            }
            else if (!Int32.TryParse(txtSupplierID.Text, out integer))//validate that SupplierID is an integer
            {
                MessageBox.Show("Please enter a valid Supplier ID.");
                txtSupName.Focus();
            }
            else
            {   
                if (btnAdd.Text == "Add")
                {
                    txtSearch.Text = "";
                    Supplier supplier = new Supplier();
                    supplier.SupplierId = Convert.ToInt32(txtSupplierID.Text);
                    supplier.Name = txtSupName.Text;
                    try
                    {
                        if (SupplierDB.AddSupplier(supplier))
                        {
                            MessageBox.Show("Supplier added successfully.");
                            updateListView(SupplierDB.GetSuppliers());
                            clearForm();
                            pnlAddUpdate.Visible = false;
                        }
                        else
                        {
                            MessageBox.Show("Supplier not added successfully.");
                        }
                    }
                    catch (SqlException ex)
                    {
                        if (ex.Message.StartsWith("Violation of PRIMARY KEY"))
                        {
                            MessageBox.Show("Supplier with this ID already exists. Enter unique ID.");
                            txtSupplierID.Focus();
                        }
                        else
                        {
                            MessageBox.Show(ex.Message);
                        }
                    }
                }

                else if (btnAdd.Text == "Update")
                {                    
                    if (UpdateSupplier(Convert.ToInt32(selectedSupplierID)))
                    {
                        MessageBox.Show("Record updated successfully.");
                        clearForm();
                        selectedSupName = "";
                        selectedSupplierID = "";
                    }
                    else
                    {
                        MessageBox.Show("Record was not updated.");
                    }
                }
            }
        }

        private void btnAddNewSupplier_Click(object sender, EventArgs e)
        {
            txtSupplierID.Enabled = true;
            txtSearch.Text = "";
            clearForm();
            pnlAddUpdate.Visible = true;
            btnAdd.Text = "Add";
            this.lstSuppliers.SelectedIndices.Clear();
            selectedSupName = "";
            selectedSupplierID = "";
            txtSupplierID.Focus();
        }

        private void btnDeleteSelected_Click(object sender, EventArgs e)
        {
            clearForm();
            if (lstSuppliers.SelectedItems.Count == 1)
            {
                selectedSupplierID = lstSuppliers.Items[lstSuppliers.SelectedIndices[0]].Text.Trim(); //store selected supplier id                

                if (SupplierDB.CheckDependency(Convert.ToInt32(selectedSupplierID)))
                {
                    MessageBox.Show("Cannot delete.  SupplierID exists in table Products_Suppliers");
                }
                else
                {
                    //confirm that user wants to delete
                    DialogResult result = MessageBox.Show("Are you sure you want to delete this record?" + "\n\nSupplier ID: " + selectedSupplierID + "\nSupplier Name: " + selectedSupName, "Confirmation", MessageBoxButtons.YesNo);
                    if (result == DialogResult.Yes)
                    {
                        if (SupplierDB.DeleteSupplier(Convert.ToInt32(selectedSupplierID)))
                        {
                            //if delete is successful, display message and update list view
                            MessageBox.Show("Delete successful!");
                            updateListView(SupplierDB.GetSuppliers());
                            clearForm();
                            this.lstSuppliers.SelectedIndices.Clear();
                            selectedSupName = "";
                            selectedSupplierID = "";
                        }
                        else
                        {
                            //delete failed, display message
                            MessageBox.Show("Delete was not successful.");
                        }
                    }
                    else if (result == DialogResult.No) //if user confirms they do not want to delete, display cancel message
                    {
                        MessageBox.Show("Delete cancelled");
                        this.lstSuppliers.SelectedIndices.Clear();
                        selectedSupName = "";
                        selectedSupplierID = "";

                        clearForm();
                    }
                }
            }
            else
            {
                MessageBox.Show("Please select item to delete");
                lstSuppliers.Focus();
            }
        }//END OF DELETE BUTTON CLICK
        #endregion

        #region Methods
        public void clearForm()
        {

            txtSupplierID.Text = "";
            txtSupName.Text = "";
        }

        public bool UpdateSupplier(int supplierID) //refreshes supplier list with updated supplier
        {
            //validate on the form
            //string connectionString = "Data Source=localhost\\SAIT;Initial Catalog=TravelExperts;Integrated Security=True";
            //SqlConnection connection = new SqlConnection(connectionString);
            SqlConnection connection = TravelExpertsDB.GetConnection();

            string updateStatement = "UPDATE Suppliers " +
                                     "SET SupplierID = @NewSupplierID, " +
                                     "       SupName = @NewSupName " +
                                     "WHERE SupplierID = @OldSupplierID";
            SqlCommand updateCommand = new SqlCommand(updateStatement, connection);
            updateCommand.Parameters.AddWithValue("@NewSupplierID", txtSupplierID.Text);
            updateCommand.Parameters.AddWithValue("@NewSupName", txtSupName.Text);
            updateCommand.Parameters.AddWithValue("@OldSupplierID", selectedSupplierID);

            try
            {
                connection.Open();
                int count = updateCommand.ExecuteNonQuery(); //count how many rows are affected
                if (count > 0) //if update was successful
                {
                    List<Supplier> suppliersList = SupplierDB.GetSuppliers();
                    updateListView(suppliersList);
                    pnlAddUpdate.Visible = false;
                    return true;
                }
                else
                {                   
                    return false;
                }
            }
            catch(SqlException ex)
            {
                MessageBox.Show(ex.ToString());
                MessageBox.Show("There was an error. Please try again.");
            }
            finally
            {
                connection.Close();
            }
            return false;
        }//END OF UpdateSupplier()

        public void updateListView(List<Supplier> suppliersList) //populate list view with list of products
        {
            lstSuppliers.Items.Clear();
            int i = 0;
            foreach (Supplier supplier in suppliersList)
            {
                lstSuppliers.Items.Add(supplier.SupplierId.ToString());
                lstSuppliers.Items[i].SubItems.Add(supplier.Name);
                i++;
            }
        }
        #endregion

        private void btnCancel_Click(object sender, EventArgs e)
        {
            clearForm();
            this.lstSuppliers.SelectedIndices.Clear();
            pnlAddUpdate.Visible = false;
            selectedSupplierID = "";
            //selectedSupName = "";
        }

        private void btnUpdateSelected_Click(object sender, EventArgs e)
        {
            txtSupplierID.Enabled = false;
            if (selectedSupplierID=="")// check that user selected supplier
            {
                MessageBox.Show("Please select a suppiler");
                lstSuppliers.Focus();
            }
            else
            {
                //show and populate panel
                pnlAddUpdate.Visible = true;
                btnAdd.Text = "Update";
                clearForm();
                txtSupplierID.Text = selectedSupplierID;
                txtSupName.Text = selectedSupName;
                txtSupName.Focus();
            }
        }

        private void txtSearch_Click(object sender, EventArgs e)
        {
            this.lstSuppliers.SelectedIndices.Clear();
            selectedSupplierID = "";
            selectedSupName = "";

        }

        private void txtSupplierID_Click(object sender, EventArgs e)
        {
            this.lstSuppliers.SelectedIndices.Clear();
            selectedSupplierID = "";
            selectedSupName = "";
        }
    }//END OF FORM 
}//END OF NAMESPACE




