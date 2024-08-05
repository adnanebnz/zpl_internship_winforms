using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;
using XmlToZpl.Processors;
using Newtonsoft.Json;
using XmlToZpl.DbHelper;

using XmlToZpl.Utils;
using XmlToZpl.Models;

namespace XmlToZpl
{
    public partial class Form2 : Form
    {
        public string zplFilePath;
        private string jsonFilePath;
        private string zplResult;
        private DatabaseHelper dbHelper;
        private string connectionString = "server=localhost\\SQLEXPRESS;database=Inventaire BDD;Trusted_Connection=True;";
        private List<Bien> listeBiensAImprimer = new List<Bien>();
        private List<Dictionary<string, string>> replacementsList = new List<Dictionary<string, string>>();
        public static Form2 instance;

        public Form2(string zplFilePath = "")
        {
            InitializeComponent();
            this.zplFilePath = zplFilePath;
            dbHelper = new DatabaseHelper(connectionString);
            StartPosition = FormStartPosition.CenterScreen;
            richTextBox1.Text = zplFilePath;
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            formLoad();
        }
        public void formLoad()
        {
            try
            {
                List<Bien> biens = dbHelper.FetchBienDataFromDb();

                // Clear any existing data bindings
                bienBindingSource.Clear();

                foreach (var item in biens)
                {
                    bienBindingSource.Add(item);
                }

                // Add a checkbox column for selection
                DataGridViewCheckBoxColumn checkboxColumn = new DataGridViewCheckBoxColumn();
                checkboxColumn.HeaderText = "Select";
                checkboxColumn.Name = "selectColumn";
                dataGridView1.Columns.Insert(0, checkboxColumn);
                dataGridView1.DataSource = bienBindingSource;
                dataGridView1.AllowUserToAddRows = false;
                dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                dataGridView1.CellClick += DataGridView1_CellClick;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        private void DataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex == 0) 
            {
                DataGridViewCheckBoxCell checkbox = dataGridView1.Rows[e.RowIndex].Cells[0] as DataGridViewCheckBoxCell;

                if (checkbox != null && e.ColumnIndex == checkbox.ColumnIndex)
                {
                    bool isChecked = (bool)(checkbox.Value ?? false); 
                    checkbox.Value = !isChecked;

                    dataGridView1.Rows[e.RowIndex].Selected = true;

                    Bien selectedBien = dataGridView1.Rows[e.RowIndex].DataBoundItem as Bien;

                    if ((bool)checkbox.Value)
                    {
                        listeBiensAImprimer.Add(selectedBien);
                    }
                    else
                    {
                        listeBiensAImprimer.Remove(selectedBien);
                    }
                }
            }
        }



        // SELECT JSON FILE BUTTON
        private void button1_Click(object sender, EventArgs e)
        {
            if (openFileDialog2.ShowDialog() == DialogResult.OK)
            {
                string fileNamePath = openFileDialog2.FileName;
                jsonFilePath = fileNamePath;

                // Check if the selected file is JSON
                string fileExtension = Path.GetExtension(jsonFilePath).ToLower();

                if (fileExtension == ".json")
                {
                    richTextBox2.Text = jsonFilePath;
                    button2.Enabled = true;

                    string jsonString = FileUtil.ReadFile(jsonFilePath);

                    replacementsList = JsonConvert.DeserializeObject<List<Dictionary<string, string>>>(jsonString);
                }
                else
                {
                    MessageBox.Show("Please select a JSON file.");
                    richTextBox2.Clear();
                    button2.Enabled = false;
                }

            }
        }
        // PRINT BUTTON
        private void button2_Click(object sender, EventArgs e)
        {
            if (listeBiensAImprimer.Count > 0)
            {
                string resJson = JsonConvert.SerializeObject(listeBiensAImprimer);

                replacementsList = JsonConvert.DeserializeObject<List<Dictionary<string, string>>>(resJson);
            }

            DialogResult result = printDialog1.ShowDialog();
            if (result == DialogResult.OK)
            {
                if (replacementsList != null)
                {
                    if(replacementsList.Count == 0)
                    {
                        MessageBox.Show("Nothing to print!");
                    }
                    else
                    {
                        ZplTemplateProcessor.ProcessAndPrintZplFile(zplFilePath, replacementsList, printDialog1.PrinterSettings.PrinterName);
                        MessageBox.Show("Printed " + replacementsList.Count + " labels!");
                    }
                }
            }

        }
        // SELECT ZPL FILE BUTTON
        private void button3_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                string fileNamePath = openFileDialog1.FileName;
                zplFilePath = fileNamePath;

                // Check if the selected file is ZPL
                string fileExtension = Path.GetExtension(zplFilePath).ToLower();

                if (fileExtension == ".zpl")
                {
                    richTextBox1.Text = zplFilePath;
                    button2.Enabled = true;

                }
                else
                {
                    MessageBox.Show("Please select a ZPL file.");
                    richTextBox1.Clear();
                }
            }
        }
    }
}
