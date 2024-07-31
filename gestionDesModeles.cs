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
            Console.WriteLine(selectedLabelFile);
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
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex == 0)
            {


                    dataGridView1.Rows[e.RowIndex].Selected = true;

                XmlToZpl.Models.Label selectedlabel = dataGridView1.Rows[e.RowIndex].DataBoundItem as XmlToZpl.Models.Label;

               this.selectedLabelFile = selectedlabel.CheminLabel;

                    }
            }
        }
    }
