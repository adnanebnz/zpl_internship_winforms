using System;
using System.Collections.Generic;
using System.Windows.Forms;
using XmlToZpl.DbHelper;
using XmlToZpl.Models;

namespace XmlToZpl
{
    public partial class gestionDesModeles : Form
    {
        private DatabaseHelper dbHelper;
        private string connectionString = "server=localhost\\SQLEXPRESS;database=Inventaire BDD;Trusted_Connection=True;";
        private Form1 formInstance;
        private string selectedLabelFile;
        public gestionDesModeles()
        {
            InitializeComponent();
            dbHelper = new DatabaseHelper(connectionString);
            this.StartPosition = FormStartPosition.CenterScreen;
            formInstance = new Form1();
        }
        //Ajouter
        private void button2_Click(object sender, EventArgs e)
        {

        }
        //Modifier
        private void button1_Click(object sender, EventArgs e)
        {

        }
        //Supprimer
        private void button3_Click(object sender, EventArgs e)
        {

        }

        private void bindingSource1_CurrentChanged_1(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {
                DataGridViewRow selectedRow = dataGridView1.Rows[e.RowIndex];

                selectedLabelFile = selectedRow.Cells["CheminLabel"].Value.ToString();

                Console.WriteLine("Selected Label: " + selectedLabelFile);
            }
        }

        private void gestionDesModeles_Load(object sender, EventArgs e)
        {
            formLoad();
        }

        public void formLoad()
        {
            try
            {
                var labels = dbHelper.FetchLabelsFromDb();

                // Clear any existing data bindings
                labelBindingSource.Clear();

                foreach (var item in labels)
                {
                    labelBindingSource.Add(item);
                }

            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}
