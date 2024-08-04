using System;
using System.Collections.Generic;
using System.Windows.Forms;
using XmlToZpl.DbHelper;

namespace XmlToZpl
{
    public partial class gestionDesModeles : Form
    {
        private DatabaseHelper dbHelper;
        private string connectionString = "server=localhost\\SQLEXPRESS;database=Inventaire BDD;Trusted_Connection=True;";
        private Form1 formInstance;
        private string selectedLabelFile;
        private XmlToZpl.Models.Label selectedLabel;
        public gestionDesModeles()
        {
            InitializeComponent();
            dbHelper = new DatabaseHelper(connectionString);
            this.StartPosition = FormStartPosition.CenterScreen;
            formInstance = new Form1();
        }
        //Utiliser
        private void button1_Click(object sender, EventArgs e)
        {
            Form2 form2 = new Form2();
            form2.Show();
        }
        // Ajouter un modéle
        private void button3_Click(object sender, EventArgs e)
        {
            Form1 form1 = new Form1();
            form1.Show();
        }

        private void gestionDesModeles_Load(object sender, EventArgs e)
        {
            formLoad();
        }

        public void formLoad()
        {
            try
            {
                // Fetch labels from the database
                List<Models.Label> labels = dbHelper.FetchLabelsFromDb();

                // Clear existing data bindings
                labelBindingSource.Clear();

                // Add fetched labels to the binding source
                foreach (var item in labels)
                {
                    labelBindingSource.Add(item);
                }

                // Assign the binding source to the DataGridView
                dataGridView1.DataSource = labelBindingSource;

                // Ensure the ComboBox column is set up correctly
                var comboBoxColumn = dataGridView1.Columns["ChooseLabel"] as DataGridViewComboBoxColumn;

                // Set the ComboBox cell values after the DataGridView has been populated
                foreach (DataGridViewRow row in dataGridView1.Rows)
                {
                    var label = row.DataBoundItem as Models.Label;
                    if (label != null)
                    {
                        // Determine the cell value based on the label's property
                        string cellValue = "Non";
                        if(label.ModeleParDefaut == 1 )
                        {
                            cellValue = "Oui";
                        }
                        row.Cells["ChooseLabel"].Value = cellValue;
                    }
                }

                // Event handlers
                dataGridView1.CellClick += dataGridView1_CellClick;
                dataGridView1.UserDeletingRow += deleteButton_Click;
                dataGridView1.CurrentCellDirtyStateChanged += dataGridView1_CurrentCellDirtyStateChanged;
                dataGridView1.CellValueChanged += dataGridView1_CellValueChanged;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }


        private void dataGridView1_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentCell is DataGridViewComboBoxCell)
            {
                dataGridView1.CommitEdit(DataGridViewDataErrorContexts.Commit);
            }
        }

        private void dataGridView1_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            // Ensure the event is triggered for valid columns and rows
            if (e.ColumnIndex == dataGridView1.Columns["ChooseLabel"].Index && e.RowIndex >= 0)
            {
                // Get the new value of the changed cell
                var newValue = dataGridView1[e.ColumnIndex, e.RowIndex].Value as string;

                if (newValue != null)
                {
                    // Handle the change
                    MessageBox.Show($"Value changed to: {newValue}");

                    // Check if "Oui" exists in any row of the ComboBox column
                    int counter = 0;
                    foreach (DataGridViewRow row in dataGridView1.Rows)
                    {
                        // Ensure that the cell value is of type string
                        var cellValue = row.Cells[e.ColumnIndex].Value as string;
                        if (cellValue == "Oui")
                        {
                            counter++;
                            if (counter >= 2)
                            {
                                break;
                            }
                        }
                    }

                    if (counter >= 2)
                    {
                        MessageBox.Show("Error: More than 1 row has 'Oui' selected.");
                        return;
                    }

                   
                    if (newValue == "Oui")
                    {
                        dbHelper.ModifyLabelStatus(1, selectedLabel.Id);
                    }
                    else
                    {
                        dbHelper.ModifyLabelStatus(0, selectedLabel.Id);
                    }
                }
            }
        }

        private void deleteButton_Click(object sender, EventArgs e)
        {
            // Ensure that a row is selected
            if (dataGridView1.SelectedRows.Count > 0)
            {

                if (this.selectedLabel != null)
                {
                    // Confirm deletion
                    DialogResult result = MessageBox.Show("Are you sure you want to delete this label?", "Confirm Deletion", MessageBoxButtons.YesNo);

                    if (result == DialogResult.Yes)
                    {
                        // Perform the deletion
                        bool success = dbHelper.DeleteLabelFromDb(this.selectedLabel);

                        if (success)
                        {
                            MessageBox.Show("Label deleted successfully.");
                        }
                        else
                        {
                            MessageBox.Show("Failed to delete label. Please try again.");
                        }
                    }
                }
                else
                {
                    MessageBox.Show("No label selected.");
                }
            }
            else
            {
                MessageBox.Show("Please select a row to delete.");
            }
        }


        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // Make sure the click is on a valid row index
            if (e.RowIndex >= 0 && e.RowIndex < dataGridView1.Rows.Count)
            {
                dataGridView1.Rows[e.RowIndex].Selected = true;

                XmlToZpl.Models.Label selectedLabel = dataGridView1.Rows[e.RowIndex].DataBoundItem as XmlToZpl.Models.Label;


                if (selectedLabel != null)
                    {
                    this.selectedLabel = selectedLabel;
                    this.selectedLabelFile = selectedLabel.CheminLabel;
                    }
                }
            }
        }
    }
