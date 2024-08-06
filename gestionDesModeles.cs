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
        private string selectedLabelFile;
        private Models.Label selectedLabel;

        public gestionDesModeles()
        {
            InitializeComponent();
            dbHelper = new DatabaseHelper(connectionString);
            StartPosition = FormStartPosition.CenterScreen;
        }

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
                List<Models.Label> labels = dbHelper.FetchLabelsFromDb();

                labelBindingSource.Clear();

                foreach (var item in labels)
                {
                    labelBindingSource.Add(item);
                }

                dataGridView1.DataSource = labelBindingSource;

                SetupComboBoxColumn();

                foreach (DataGridViewRow row in dataGridView1.Rows)
                {
                    if (row.DataBoundItem is Models.Label label)
                    {
                        string cellValue = label.ModeleParDefaut == 1 ? "Oui" : "Non";
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
                MessageBox.Show($"Error loading data: {e.Message}");
            }
        }

        private void SetupComboBoxColumn()
        {
            if (dataGridView1.Columns["ChooseLabel"] == null)
            {
                DataGridViewComboBoxColumn comboBoxColumn = new DataGridViewComboBoxColumn
                {
                    Name = "ChooseLabel",
                    HeaderText = "Modéle par defaut?",
                    DataSource = new List<string> { "Oui", "Non" },
                    FlatStyle = FlatStyle.Flat,
                };

                dataGridView1.Columns.Add(comboBoxColumn);
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
            if (e.ColumnIndex == dataGridView1.Columns["ChooseLabel"].Index && e.RowIndex >= 0)
            {
                var newValue = dataGridView1[e.ColumnIndex, e.RowIndex].Value as string;

                if (newValue != null)
                {
                    int ouiCount = 0;
                    DataGridViewRow changedRow = dataGridView1.Rows[e.RowIndex];

                    foreach (DataGridViewRow row in dataGridView1.Rows)
                    {
                        var cellValue = row.Cells[e.ColumnIndex].Value as string;
                        if (cellValue == "Oui")
                        {
                            ouiCount++;
                        }
                    }

                    if (newValue == "Oui" && ouiCount > 1)
                    {
                        MessageBox.Show("Error: More than 1 row has 'Oui' selected.");
                        dataGridView1[e.ColumnIndex, e.RowIndex].Value = "Non";
                        return;
                    }

                    if (selectedLabel != null)
                    {
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
        }

        private void deleteButton_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                if (selectedLabel != null)
                {
                    DialogResult result = MessageBox.Show("Are you sure you want to delete this label?", "Confirm Deletion", MessageBoxButtons.YesNo);

                    if (result == DialogResult.Yes)
                    {
                        bool success = dbHelper.DeleteLabelFromDb(selectedLabel);

                        if (success)
                        {
                            MessageBox.Show("Label deleted successfully.");
                            formLoad();
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
            if (e.RowIndex >= 0 && e.RowIndex < dataGridView1.Rows.Count)
            {
                dataGridView1.Rows[e.RowIndex].Selected = true;

                if (dataGridView1.Rows[e.RowIndex].DataBoundItem is Models.Label label)
                {
                    selectedLabel = label;
                    selectedLabelFile = label.CheminLabel;
                }
            }
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            Form2 form2 = new Form2(selectedLabel.CheminZpl);
            form2.Show();
        }

        //Supprimer
        private void button2_Click(object sender, EventArgs e)
        {
            deleteButton_Click(sender, e);
        }
    }
}
