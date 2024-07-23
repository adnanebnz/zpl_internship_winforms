namespace XmlToZpl
{
    partial class Form2
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.Load += new System.EventHandler(this.Form2_Load);
            this.components = new System.ComponentModel.Container();
            this.label6 = new System.Windows.Forms.Label();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.button3 = new System.Windows.Forms.Button();
            this.richTextBox2 = new System.Windows.Forms.RichTextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.openFileDialog2 = new System.Windows.Forms.OpenFileDialog();
            this.printDialog1 = new System.Windows.Forms.PrintDialog();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.bienBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.idBienDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.idCategorieBienDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.idBienSeqDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.desigBienDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dateAcquisitionBienDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.personneDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.prixDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.photoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ancienCodeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.idFournisseurDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.marqueDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.numSerieDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fournisseurDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.etatDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dateMiseServiceDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.natureBienDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.idUtilisateurDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.modelDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ancienCodeBarreDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dernierEmplacementDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.réetiqueterDataGridViewCheckBoxColumn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.idBienMobilDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.idEmployeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.idSocieteDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ficheImmobilisationDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.codeAmortissementDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.datecessionDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.datederniereaffectationDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bienBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(281, 18);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(126, 25);
            this.label6.TabIndex = 20;
            this.label6.Text = "Impression";
            // 
            // richTextBox1
            // 
            this.richTextBox1.Location = new System.Drawing.Point(162, 69);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(491, 27);
            this.richTextBox1.TabIndex = 19;
            this.richTextBox1.Text = "";
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(22, 66);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(113, 31);
            this.button3.TabIndex = 18;
            this.button3.Text = "ZPL";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // richTextBox2
            // 
            this.richTextBox2.Location = new System.Drawing.Point(162, 131);
            this.richTextBox2.Name = "richTextBox2";
            this.richTextBox2.Size = new System.Drawing.Size(491, 27);
            this.richTextBox2.TabIndex = 22;
            this.richTextBox2.Text = "";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(22, 128);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(113, 31);
            this.button1.TabIndex = 21;
            this.button1.Text = "JSON";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(286, 429);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(121, 42);
            this.button2.TabIndex = 23;
            this.button2.Text = "IMPRIMER";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // openFileDialog2
            // 
            this.openFileDialog2.FileName = "openFileDialog1";
            // 
            // printDialog1
            // 
            this.printDialog1.UseEXDialog = true;
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AutoGenerateColumns = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.idBienDataGridViewTextBoxColumn,
            this.idCategorieBienDataGridViewTextBoxColumn,
            this.idBienSeqDataGridViewTextBoxColumn,
            this.desigBienDataGridViewTextBoxColumn,
            this.dateAcquisitionBienDataGridViewTextBoxColumn,
            this.personneDataGridViewTextBoxColumn,
            this.prixDataGridViewTextBoxColumn,
            this.photoDataGridViewTextBoxColumn,
            this.ancienCodeDataGridViewTextBoxColumn,
            this.idFournisseurDataGridViewTextBoxColumn,
            this.marqueDataGridViewTextBoxColumn,
            this.numSerieDataGridViewTextBoxColumn,
            this.fournisseurDataGridViewTextBoxColumn,
            this.etatDataGridViewTextBoxColumn,
            this.dateMiseServiceDataGridViewTextBoxColumn,
            this.natureBienDataGridViewTextBoxColumn,
            this.idUtilisateurDataGridViewTextBoxColumn,
            this.modelDataGridViewTextBoxColumn,
            this.ancienCodeBarreDataGridViewTextBoxColumn,
            this.dernierEmplacementDataGridViewTextBoxColumn,
            this.réetiqueterDataGridViewCheckBoxColumn,
            this.idBienMobilDataGridViewTextBoxColumn,
            this.idEmployeDataGridViewTextBoxColumn,
            this.idSocieteDataGridViewTextBoxColumn,
            this.ficheImmobilisationDataGridViewTextBoxColumn,
            this.codeAmortissementDataGridViewTextBoxColumn,
            this.datecessionDataGridViewTextBoxColumn,
            this.datederniereaffectationDataGridViewTextBoxColumn});
            this.dataGridView1.DataSource = this.bienBindingSource;
            this.dataGridView1.Location = new System.Drawing.Point(9, 199);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.Size = new System.Drawing.Size(659, 208);
            this.dataGridView1.TabIndex = 24;
            // 
            // bienBindingSource
            // 
            this.bienBindingSource.DataSource = typeof(XmlToZpl.Models.Bien);
            // 
            // idBienDataGridViewTextBoxColumn
            // 
            this.idBienDataGridViewTextBoxColumn.DataPropertyName = "IdBien";
            this.idBienDataGridViewTextBoxColumn.HeaderText = "IdBien";
            this.idBienDataGridViewTextBoxColumn.Name = "idBienDataGridViewTextBoxColumn";
            this.idBienDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // idCategorieBienDataGridViewTextBoxColumn
            // 
            this.idCategorieBienDataGridViewTextBoxColumn.DataPropertyName = "IdCategorieBien";
            this.idCategorieBienDataGridViewTextBoxColumn.HeaderText = "IdCategorieBien";
            this.idCategorieBienDataGridViewTextBoxColumn.Name = "idCategorieBienDataGridViewTextBoxColumn";
            this.idCategorieBienDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // idBienSeqDataGridViewTextBoxColumn
            // 
            this.idBienSeqDataGridViewTextBoxColumn.DataPropertyName = "IdBienSeq";
            this.idBienSeqDataGridViewTextBoxColumn.HeaderText = "IdBienSeq";
            this.idBienSeqDataGridViewTextBoxColumn.Name = "idBienSeqDataGridViewTextBoxColumn";
            this.idBienSeqDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // desigBienDataGridViewTextBoxColumn
            // 
            this.desigBienDataGridViewTextBoxColumn.DataPropertyName = "DesigBien";
            this.desigBienDataGridViewTextBoxColumn.HeaderText = "DesigBien";
            this.desigBienDataGridViewTextBoxColumn.Name = "desigBienDataGridViewTextBoxColumn";
            this.desigBienDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // dateAcquisitionBienDataGridViewTextBoxColumn
            // 
            this.dateAcquisitionBienDataGridViewTextBoxColumn.DataPropertyName = "DateAcquisitionBien";
            this.dateAcquisitionBienDataGridViewTextBoxColumn.HeaderText = "DateAcquisitionBien";
            this.dateAcquisitionBienDataGridViewTextBoxColumn.Name = "dateAcquisitionBienDataGridViewTextBoxColumn";
            this.dateAcquisitionBienDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // personneDataGridViewTextBoxColumn
            // 
            this.personneDataGridViewTextBoxColumn.DataPropertyName = "personne";
            this.personneDataGridViewTextBoxColumn.HeaderText = "personne";
            this.personneDataGridViewTextBoxColumn.Name = "personneDataGridViewTextBoxColumn";
            this.personneDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // prixDataGridViewTextBoxColumn
            // 
            this.prixDataGridViewTextBoxColumn.DataPropertyName = "Prix";
            this.prixDataGridViewTextBoxColumn.HeaderText = "Prix";
            this.prixDataGridViewTextBoxColumn.Name = "prixDataGridViewTextBoxColumn";
            this.prixDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // photoDataGridViewTextBoxColumn
            // 
            this.photoDataGridViewTextBoxColumn.DataPropertyName = "Photo";
            this.photoDataGridViewTextBoxColumn.HeaderText = "Photo";
            this.photoDataGridViewTextBoxColumn.Name = "photoDataGridViewTextBoxColumn";
            this.photoDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // ancienCodeDataGridViewTextBoxColumn
            // 
            this.ancienCodeDataGridViewTextBoxColumn.DataPropertyName = "ancienCode";
            this.ancienCodeDataGridViewTextBoxColumn.HeaderText = "ancienCode";
            this.ancienCodeDataGridViewTextBoxColumn.Name = "ancienCodeDataGridViewTextBoxColumn";
            this.ancienCodeDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // idFournisseurDataGridViewTextBoxColumn
            // 
            this.idFournisseurDataGridViewTextBoxColumn.DataPropertyName = "idFournisseur";
            this.idFournisseurDataGridViewTextBoxColumn.HeaderText = "idFournisseur";
            this.idFournisseurDataGridViewTextBoxColumn.Name = "idFournisseurDataGridViewTextBoxColumn";
            this.idFournisseurDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // marqueDataGridViewTextBoxColumn
            // 
            this.marqueDataGridViewTextBoxColumn.DataPropertyName = "Marque";
            this.marqueDataGridViewTextBoxColumn.HeaderText = "Marque";
            this.marqueDataGridViewTextBoxColumn.Name = "marqueDataGridViewTextBoxColumn";
            this.marqueDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // numSerieDataGridViewTextBoxColumn
            // 
            this.numSerieDataGridViewTextBoxColumn.DataPropertyName = "numSerie";
            this.numSerieDataGridViewTextBoxColumn.HeaderText = "numSerie";
            this.numSerieDataGridViewTextBoxColumn.Name = "numSerieDataGridViewTextBoxColumn";
            this.numSerieDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // fournisseurDataGridViewTextBoxColumn
            // 
            this.fournisseurDataGridViewTextBoxColumn.DataPropertyName = "Fournisseur";
            this.fournisseurDataGridViewTextBoxColumn.HeaderText = "Fournisseur";
            this.fournisseurDataGridViewTextBoxColumn.Name = "fournisseurDataGridViewTextBoxColumn";
            this.fournisseurDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // etatDataGridViewTextBoxColumn
            // 
            this.etatDataGridViewTextBoxColumn.DataPropertyName = "etat";
            this.etatDataGridViewTextBoxColumn.HeaderText = "etat";
            this.etatDataGridViewTextBoxColumn.Name = "etatDataGridViewTextBoxColumn";
            this.etatDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // dateMiseServiceDataGridViewTextBoxColumn
            // 
            this.dateMiseServiceDataGridViewTextBoxColumn.DataPropertyName = "DateMiseService";
            this.dateMiseServiceDataGridViewTextBoxColumn.HeaderText = "DateMiseService";
            this.dateMiseServiceDataGridViewTextBoxColumn.Name = "dateMiseServiceDataGridViewTextBoxColumn";
            this.dateMiseServiceDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // natureBienDataGridViewTextBoxColumn
            // 
            this.natureBienDataGridViewTextBoxColumn.DataPropertyName = "natureBien";
            this.natureBienDataGridViewTextBoxColumn.HeaderText = "natureBien";
            this.natureBienDataGridViewTextBoxColumn.Name = "natureBienDataGridViewTextBoxColumn";
            this.natureBienDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // idUtilisateurDataGridViewTextBoxColumn
            // 
            this.idUtilisateurDataGridViewTextBoxColumn.DataPropertyName = "idUtilisateur";
            this.idUtilisateurDataGridViewTextBoxColumn.HeaderText = "idUtilisateur";
            this.idUtilisateurDataGridViewTextBoxColumn.Name = "idUtilisateurDataGridViewTextBoxColumn";
            this.idUtilisateurDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // modelDataGridViewTextBoxColumn
            // 
            this.modelDataGridViewTextBoxColumn.DataPropertyName = "Model";
            this.modelDataGridViewTextBoxColumn.HeaderText = "Model";
            this.modelDataGridViewTextBoxColumn.Name = "modelDataGridViewTextBoxColumn";
            this.modelDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // ancienCodeBarreDataGridViewTextBoxColumn
            // 
            this.ancienCodeBarreDataGridViewTextBoxColumn.DataPropertyName = "ancienCodeBarre";
            this.ancienCodeBarreDataGridViewTextBoxColumn.HeaderText = "ancienCodeBarre";
            this.ancienCodeBarreDataGridViewTextBoxColumn.Name = "ancienCodeBarreDataGridViewTextBoxColumn";
            this.ancienCodeBarreDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // dernierEmplacementDataGridViewTextBoxColumn
            // 
            this.dernierEmplacementDataGridViewTextBoxColumn.DataPropertyName = "dernierEmplacement";
            this.dernierEmplacementDataGridViewTextBoxColumn.HeaderText = "dernierEmplacement";
            this.dernierEmplacementDataGridViewTextBoxColumn.Name = "dernierEmplacementDataGridViewTextBoxColumn";
            this.dernierEmplacementDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // réetiqueterDataGridViewCheckBoxColumn
            // 
            this.réetiqueterDataGridViewCheckBoxColumn.DataPropertyName = "réetiqueter";
            this.réetiqueterDataGridViewCheckBoxColumn.HeaderText = "réetiqueter";
            this.réetiqueterDataGridViewCheckBoxColumn.Name = "réetiqueterDataGridViewCheckBoxColumn";
            this.réetiqueterDataGridViewCheckBoxColumn.ReadOnly = true;
            // 
            // idBienMobilDataGridViewTextBoxColumn
            // 
            this.idBienMobilDataGridViewTextBoxColumn.DataPropertyName = "idBienMobil";
            this.idBienMobilDataGridViewTextBoxColumn.HeaderText = "idBienMobil";
            this.idBienMobilDataGridViewTextBoxColumn.Name = "idBienMobilDataGridViewTextBoxColumn";
            this.idBienMobilDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // idEmployeDataGridViewTextBoxColumn
            // 
            this.idEmployeDataGridViewTextBoxColumn.DataPropertyName = "idEmploye";
            this.idEmployeDataGridViewTextBoxColumn.HeaderText = "idEmploye";
            this.idEmployeDataGridViewTextBoxColumn.Name = "idEmployeDataGridViewTextBoxColumn";
            this.idEmployeDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // idSocieteDataGridViewTextBoxColumn
            // 
            this.idSocieteDataGridViewTextBoxColumn.DataPropertyName = "idSociete";
            this.idSocieteDataGridViewTextBoxColumn.HeaderText = "idSociete";
            this.idSocieteDataGridViewTextBoxColumn.Name = "idSocieteDataGridViewTextBoxColumn";
            this.idSocieteDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // ficheImmobilisationDataGridViewTextBoxColumn
            // 
            this.ficheImmobilisationDataGridViewTextBoxColumn.DataPropertyName = "ficheImmobilisation";
            this.ficheImmobilisationDataGridViewTextBoxColumn.HeaderText = "ficheImmobilisation";
            this.ficheImmobilisationDataGridViewTextBoxColumn.Name = "ficheImmobilisationDataGridViewTextBoxColumn";
            this.ficheImmobilisationDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // codeAmortissementDataGridViewTextBoxColumn
            // 
            this.codeAmortissementDataGridViewTextBoxColumn.DataPropertyName = "codeAmortissement";
            this.codeAmortissementDataGridViewTextBoxColumn.HeaderText = "codeAmortissement";
            this.codeAmortissementDataGridViewTextBoxColumn.Name = "codeAmortissementDataGridViewTextBoxColumn";
            this.codeAmortissementDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // datecessionDataGridViewTextBoxColumn
            // 
            this.datecessionDataGridViewTextBoxColumn.DataPropertyName = "datecession";
            this.datecessionDataGridViewTextBoxColumn.HeaderText = "datecession";
            this.datecessionDataGridViewTextBoxColumn.Name = "datecessionDataGridViewTextBoxColumn";
            this.datecessionDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // datederniereaffectationDataGridViewTextBoxColumn
            // 
            this.datederniereaffectationDataGridViewTextBoxColumn.DataPropertyName = "datederniereaffectation";
            this.datederniereaffectationDataGridViewTextBoxColumn.HeaderText = "datederniereaffectation";
            this.datederniereaffectationDataGridViewTextBoxColumn.Name = "datederniereaffectationDataGridViewTextBoxColumn";
            this.datederniereaffectationDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(683, 483);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.richTextBox2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.richTextBox1);
            this.Controls.Add(this.button3);
            this.Name = "Form2";
            this.Text = "Impression";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bienBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.RichTextBox richTextBox2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.OpenFileDialog openFileDialog2;
        private System.Windows.Forms.PrintDialog printDialog1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn idBienDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn idCategorieBienDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn idBienSeqDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn desigBienDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn dateAcquisitionBienDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn personneDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn prixDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn photoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn ancienCodeDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn idFournisseurDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn marqueDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn numSerieDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn fournisseurDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn etatDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn dateMiseServiceDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn natureBienDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn idUtilisateurDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn modelDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn ancienCodeBarreDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn dernierEmplacementDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewCheckBoxColumn réetiqueterDataGridViewCheckBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn idBienMobilDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn idEmployeDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn idSocieteDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn ficheImmobilisationDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn codeAmortissementDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn datecessionDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn datederniereaffectationDataGridViewTextBoxColumn;
        private System.Windows.Forms.BindingSource bienBindingSource;
    }
}