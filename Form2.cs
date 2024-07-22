using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;
using XmlToZpl.Processors;
using Newtonsoft.Json;

using XmlToZpl.Utils;

namespace XmlToZpl
{
    public partial class Form2 : Form
    {
        private string zplFilePath;
        private string jsonFilePath;
        private string zplResult;
        public Form2()
        {
            InitializeComponent();
            button2.Enabled = false;
        }

        private void button1_Click(object sender, EventArgs e) {
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
                }
                else
                {
                    MessageBox.Show("Please select a JSON file.");
                    richTextBox2.Clear();
                    button2.Enabled = false;
                }
            }
        }
        private void button2_Click(object sender, EventArgs e)
        {

            string jsonString = FileUtil.ReadFile(jsonFilePath);

            List<Dictionary<string, string>> replacementsList =
             JsonConvert.DeserializeObject<List<Dictionary<string, string>>>(jsonString);

            if (replacementsList != null)
            {
                foreach (var replacements in replacementsList)
                {
                    ZplTemplateProcessor.ProcessTemplate(zplFilePath, replacements);
                }
            }

            DialogResult result = printDialog1.ShowDialog();

            if (result == DialogResult.OK)
            {
                // Send ZPL file to selected printer
                RawPrinterHelper.SendFileToPrinter(printDialog1.PrinterSettings.PrinterName, zplFilePath);
            }

        }

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
