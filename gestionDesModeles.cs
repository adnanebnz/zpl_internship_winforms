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
                List<XmlToZpl.Models.Label> labels = dbHelper.FetchLabelsFromDb();

                // Clear any existing data bindings
                labelBindingSource.Clear();

                foreach (var item in labels)
                {
                    labelBindingSource.Add(item);
                }
                dataGridView1.CellClick += dataGridView1_CellClick;
                dataGridView1.UserDeletingRow += deleteButton_Click;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
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
