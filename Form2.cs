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
        private string zplFilePath;
        private string jsonFilePath;
        private string zplResult;
        private DatabaseHelper dbHelper;
        private string connectionString = "server=localhost\\SQLEXPRESS;database=Inventaire BDD;Trusted_Connection=True;";
        private List<Bien> listeBiensAImprimer = new List<Bien>();
        private List<Dictionary<string, string>> replacementsList = new List<Dictionary<string, string>>();
        public Form2()
        {
            InitializeComponent();
            button2.Enabled = false;
            dbHelper = new DatabaseHelper(connectionString);
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
                foreach (var item in biens)
                {
                    bienBindingSource.Add(item);
                }
                dataGridView1.AllowUserToAddRows = false;
                dataGridView1.SelectionChanged += DataGridView1_SelectionChanged;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
        private void DataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            listeBiensAImprimer.Clear();


            foreach (DataGridViewRow row in dataGridView1.SelectedRows)
            {
                Bien bien = row.DataBoundItem as Bien;
                if (bien != null)
                {
                    listeBiensAImprimer.Add(bien);
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
                    ZplTemplateProcessor.ProcessAndPrintZplFile(zplFilePath, replacementsList, printDialog1.PrinterSettings.PrinterName);
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
