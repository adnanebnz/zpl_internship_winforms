﻿namespace XmlToZpl
{
    partial class gestionDesModeles
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
            this.components = new System.ComponentModel.Container();
            this.button3 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.labelBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.nomLabelDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cheminLabelDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CheminZpl = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ChooseLabel = new System.Windows.Forms.DataGridViewComboBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.labelBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(259, 67);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(282, 50);
            this.button3.TabIndex = 2;
            this.button3.Text = "Ajouter";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft YaHei", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(259, 19);
            this.label1.Name = "label1";
            this.label1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label1.Size = new System.Drawing.Size(286, 22);
            this.label1.TabIndex = 5;
            this.label1.Text = "Géstion Des Modéles D\'étiquettes";
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AutoGenerateColumns = false;
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.nomLabelDataGridViewTextBoxColumn,
            this.cheminLabelDataGridViewTextBoxColumn,
            this.CheminZpl,
            this.ChooseLabel});
            this.dataGridView1.DataSource = this.labelBindingSource;
            this.dataGridView1.Location = new System.Drawing.Point(12, 139);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.dataGridView1.Size = new System.Drawing.Size(776, 299);
            this.dataGridView1.TabIndex = 6;
            // 
            // labelBindingSource
            // 
            this.labelBindingSource.DataSource = typeof(XmlToZpl.Models.Label);
            // 
            // nomLabelDataGridViewTextBoxColumn
            // 
            this.nomLabelDataGridViewTextBoxColumn.DataPropertyName = "NomLabel";
            this.nomLabelDataGridViewTextBoxColumn.HeaderText = "Nom du modéle";
            this.nomLabelDataGridViewTextBoxColumn.Name = "nomLabelDataGridViewTextBoxColumn";
            this.nomLabelDataGridViewTextBoxColumn.ToolTipText = "Nom du label";
            // 
            // cheminLabelDataGridViewTextBoxColumn
            // 
            this.cheminLabelDataGridViewTextBoxColumn.DataPropertyName = "CheminLabel";
            this.cheminLabelDataGridViewTextBoxColumn.HeaderText = "Chemin du modéle";
            this.cheminLabelDataGridViewTextBoxColumn.Name = "cheminLabelDataGridViewTextBoxColumn";
            this.cheminLabelDataGridViewTextBoxColumn.ToolTipText = "Chemin du fichier du label";
            // 
            // CheminZpl
            // 
            this.CheminZpl.DataPropertyName = "CheminZpl";
            this.CheminZpl.HeaderText = "Chemin ZPL";
            this.CheminZpl.Name = "CheminZpl";
            // 
            // ChooseLabel
            // 
            this.ChooseLabel.DataSource = this.labelBindingSource;
            this.ChooseLabel.HeaderText = "modéle par defaut";
            this.ChooseLabel.Name = "ChooseLabel";
            this.ChooseLabel.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            // 
            // gestionDesModeles
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button3);
            this.Name = "gestionDesModeles";
            this.Text = "gestionDesModeles";
            this.Load += new System.EventHandler(this.gestionDesModeles_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.labelBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.BindingSource labelBindingSource;
        private System.Windows.Forms.DataGridViewTextBoxColumn nomLabelDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn cheminLabelDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn CheminZpl;
        private System.Windows.Forms.DataGridViewComboBoxColumn ChooseLabel;
    }
}