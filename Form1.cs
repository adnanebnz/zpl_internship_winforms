using System;
using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using XmlToZpl.DbHelper;
using XmlToZpl.Processors;
using XmlToZpl.Utils;


namespace XmlToZpl
{
    public partial class Form1 : Form
    {
        public static Form1 instance;

        private string xmlFilePath;
        private Dictionary<string, string> mappingDictionary = new Dictionary<string, string>();
        private List<string> dbCols = new List<string>();
        private List<ComboBox> comboBoxes = new List<ComboBox>();
        public string zplResult;
        private string newImageFilePath;
        private DatabaseHelper dbHelper;
        private string connectionString = "server=localhost\\SQLEXPRESS;database=Inventaire BDD;Trusted_Connection=True;";

        private List<string> bddValues = new List<string>  { };

        public Form1()
        {
            InitializeComponent();
            label4.Visible = false;
            label5.Visible = false;
            button2.Enabled = false;
            label2.Visible = false;
            button5.Visible = false;
            button4.Visible = false;
            textBox2.Visible = false;
            instance = this;
            textBox1.Text = "bien";
            dbHelper = new DatabaseHelper(connectionString);
        }

        // GENERATE DYNAMIC ZPL BUTTON
        private void button2_Click(object sender, EventArgs e)
        {
            // Iterate through stored ComboBoxes
            foreach (ComboBox comboBox in comboBoxes)
            {
                string variableName = comboBox.Tag?.ToString();
                string selectedColumn = comboBox.SelectedItem?.ToString();

                if (!string.IsNullOrEmpty(variableName) && !string.IsNullOrEmpty(selectedColumn))
                {
                    if (mappingDictionary.ContainsKey(variableName))
                    {
                        mappingDictionary[variableName] = selectedColumn;
                    }
                    else
                    {
                        mappingDictionary.Add(variableName, selectedColumn);
                    }
                }
            }

            
            string result = ZplTemplateProcessor.MapTemplate(this.zplResult, this.mappingDictionary);
            Console.WriteLine(result);
            FileUtil.WriteInFile("./dynamicZpl.zpl", result);
            Console.WriteLine("SAVED FILE");
        }

        // LOAD XML BUTTON
        private void button3_Click(object sender, EventArgs e)
        {
            getColumnFromBDD();
            openFileDialog1.ShowDialog();

            string fileNamePath = openFileDialog1.FileName;
            richTextBox1.Text = fileNamePath;
            this.xmlFilePath = fileNamePath;
            if (XmlToZplConverter.CheckIfXmlHasImage(fileNamePath))
            {
                button4.Visible = true;
                textBox2.Visible = true;
                string imageFilePath = XmlToZplConverter.zplImagePath(fileNamePath);
                textBox2.Text = imageFilePath;
                if (!File.Exists(imageFilePath)) {
                    label2.Visible = true;
                }
                else
                {
                    pictureBox1.Load(imageFilePath);
                }
            }
            //TODO MAKE CONVERT BUTTON
            this.zplResult = XmlToZplConverter.ConvertDynamicXmlToZpl(this.xmlFilePath);

            Console.WriteLine(zplResult);

            string pattern = @"@([^@]+)@";
            int labelTop = 20;

            label4.Visible = true;
            label5.Visible = true;
            button2.Enabled = true;
            label1.Visible = false;
            label3.Visible = true;
            textBox1.Visible = true;
            button5.Visible = true;

            MatchCollection matches = Regex.Matches(zplResult, pattern);

            tableLayoutPanel1.Controls.Clear();

            int rowCount = 0;

            foreach (Match match in matches)
            {
                string variableName = match.Groups[1].Value;

                Label newLabel = new Label
                {
                    Text = variableName,
                    AutoSize = true
                };

                ComboBox comboBox = new ComboBox
                {
                    Tag = variableName,
                    DropDownStyle = ComboBoxStyle.DropDownList
                };

                foreach (var value in bddValues)
                {
                    comboBox.Items.Add(value);
                }
                comboBoxes.Add(comboBox);
                tableLayoutPanel1.RowCount = rowCount + 1;
                tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.AutoSize));

                tableLayoutPanel1.Controls.Add(newLabel, 0, rowCount);
                tableLayoutPanel1.Controls.Add(comboBox, 1, rowCount);

                tableLayoutPanel1.SetCellPosition(newLabel, new TableLayoutPanelCellPosition(0, rowCount));
                tableLayoutPanel1.SetCellPosition(comboBox, new TableLayoutPanelCellPosition(1, rowCount));

                labelTop += 30;
                rowCount++;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form2 form2 = new Form2();
            form2.Show();
        }
        private void getColumnFromBDD()
        {
            string tableName = textBox1.Text.Trim();

            if (!string.IsNullOrEmpty(tableName))
            {
                bddValues = dbHelper.GetTableColumnNames(tableName);
            }
            else
            {
                MessageBox.Show("Please enter a table name.");
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (openFileDialog3.ShowDialog() == DialogResult.OK)
            {
                string imageFilePath = openFileDialog3.FileName;
                newImageFilePath = imageFilePath;
                textBox2.Text = newImageFilePath;
                label2.Visible = false;
                XmlToZplConverter.ModifyImagePath(this.xmlFilePath, newImageFilePath);
                pictureBox1.Load(newImageFilePath);
                this.zplResult = XmlToZplConverter.ConvertDynamicXmlToZpl(this.xmlFilePath);
                Console.WriteLine(zplResult);
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            getColumnFromBDD();
            foreach (ComboBox comboBox in comboBoxes)
            {
                string variableName = comboBox.Tag?.ToString();

                comboBox.Items.Clear();
                foreach (var value in bddValues)
                {
                    comboBox.Items.Add(value);
                }
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
    }
}
