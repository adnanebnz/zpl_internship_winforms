﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using XmlToZpl.DbHelper;
using XmlToZpl.Implementations;
using XmlToZpl.Interfaces;
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
        private string connectionString = "server=localhost\\SQLEXPRESS;database=Inventaire BDD;Trusted_Connection=True;";
        private string labelName = "";
        private List<string> bddValues = new List<string> { };
        private readonly DatabaseHelper dbHelper;
        private readonly ZplPrinterBase printerBase;
        private readonly ZplConfigBase configBase;
        private readonly ZplMappingBase mappingBase;
        private readonly ZplConversionBase conversionBase;

        public Form1()
        {
            InitializeComponent();
            label4.Visible = false;
            label5.Visible = false;
            button2.Enabled = false;
            label2.Visible = false;
            button4.Visible = false;
            textBox2.Visible = false;
            instance = this;
            textBox1.Text = "bien";
            textBox1.Visible = false;
            button5.Visible = false;
            label3.Visible = false;
            dbHelper = new DatabaseHelper(connectionString);
            printerBase = new ZplPrinterImpl(203);
            mappingBase = new ZplMappingImpl();
            configBase = new ZplConfigImpl();
            conversionBase = new ZplCovnversionImpl(203);
            this.StartPosition = FormStartPosition.CenterScreen;
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

            // WE GET THE ZPL CODE WWITH DYNAMIC VARIABLES TOOK FROM THE NAME ATTRIBUTE (before mapping)
            string zplRes = conversionBase.GetZplCode(this.xmlFilePath);
            // MAPPING AND CHANGING THE ZPL VARIABLE WITH THE ONES IN THE DICT
            string finalZplRes = mappingBase.MapZplTemplate(zplRes, mappingDictionary);
            // MODIFYING EACH DYNAMIC ELEMENT BY ADDING DbColumnName attribute to the actual value from the mapping
            bool res = mappingBase.SetDbColsToXml(this.xmlFilePath, this.mappingDictionary);
            // SAVING THE CONFIG
            string result = configBase.SaveConfig(xmlFilePath, finalZplRes, textBox3.Text);
            if (result == "Please insert your config name")
            {
                MessageBox.Show("Please insert your config name");
            }
            if (result == "Error saving the file")
            {
                MessageBox.Show("Error saving the file");
            }
            if (result == "Erreur, le nom de la config existe deja")
            {
                MessageBox.Show("Erreur, le nom de la config existe deja");
            }
            if (result == "success")
            {
                MessageBox.Show("Xml Config saved!");
            }
        }

        // LOAD XML BUTTON
        private void button3_Click(object sender, EventArgs e)
        {

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                if (Path.GetExtension(openFileDialog1.FileName).ToLower() == ".xml")
                {
                    string fileNamePath = openFileDialog1.FileName;
                    richTextBox1.Text = fileNamePath;
                    this.xmlFilePath = fileNamePath;
                    textBox1.Visible = true;
                    label3.Visible = true;
                    getColumnFromBDD();
                    if (XmlToZplConverter.CheckIfXmlHasImage(fileNamePath))
                    {
                        button4.Visible = true;
                        textBox2.Visible = true;
                        string imageFilePath = XmlToZplConverter.zplImagePath(fileNamePath);
                        textBox2.Text = imageFilePath;
                        if (!File.Exists(imageFilePath))
                        {
                            label2.Visible = true;
                        }
                        else
                        {
                            pictureBox1.Load(imageFilePath);
                        }
                    }
                    this.zplResult = XmlToZplConverter.ConvertDynamicXmlToZpl(this.xmlFilePath, 203);

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
                else
                {
                    MessageBox.Show("Veuillez insérer un fichier XML Valide");
                }
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
                this.zplResult = XmlToZplConverter.ConvertDynamicXmlToZpl(this.xmlFilePath, 203);
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
    }
}
