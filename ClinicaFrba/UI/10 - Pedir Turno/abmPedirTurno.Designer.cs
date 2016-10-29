﻿namespace ClinicaFrba.Pedir_Turno
{
    partial class PedirTurno
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
            this.monthCalendar1 = new System.Windows.Forms.MonthCalendar();
            this.btnBuscarTurnos = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.cmbBoxListadoEspecialidades = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.tbAfiliado = new System.Windows.Forms.TextBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.cmbMedicos = new System.Windows.Forms.ComboBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // monthCalendar1
            // 
            this.monthCalendar1.Location = new System.Drawing.Point(29, 141);
            this.monthCalendar1.Margin = new System.Windows.Forms.Padding(5);
            this.monthCalendar1.Name = "monthCalendar1";
            this.monthCalendar1.TabIndex = 1;
            this.monthCalendar1.DateChanged += new System.Windows.Forms.DateRangeEventHandler(this.monthCalendar1_DateChanged);
            // 
            // btnBuscarTurnos
            // 
            this.btnBuscarTurnos.Location = new System.Drawing.Point(272, 277);
            this.btnBuscarTurnos.Name = "btnBuscarTurnos";
            this.btnBuscarTurnos.Size = new System.Drawing.Size(85, 23);
            this.btnBuscarTurnos.TabIndex = 2;
            this.btnBuscarTurnos.Text = "BuscarTurno";
            this.btnBuscarTurnos.UseVisualStyleBackColor = true;
            this.btnBuscarTurnos.Click += new System.EventHandler(this.button1_Click);
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(25, 113);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(317, 23);
            this.label2.TabIndex = 8;
            this.label2.Text = "Seleccione un día en el calendario y presione \"Buscar Turnos\"";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // cmbBoxListadoEspecialidades
            // 
            this.cmbBoxListadoEspecialidades.Location = new System.Drawing.Point(194, 21);
            this.cmbBoxListadoEspecialidades.Name = "cmbBoxListadoEspecialidades";
            this.cmbBoxListadoEspecialidades.Size = new System.Drawing.Size(162, 21);
            this.cmbBoxListadoEspecialidades.TabIndex = 17;
            this.cmbBoxListadoEspecialidades.SelectedIndexChanged += new System.EventHandler(this.cmbBoxListadoEspecialidades_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(26, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(133, 26);
            this.label1.TabIndex = 10;
            this.label1.Text = "Seleccione especialidad";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(26, 65);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(133, 26);
            this.label3.TabIndex = 11;
            this.label3.Text = "Seleccione medico";
            this.label3.Click += new System.EventHandler(this.label3_Click);
            // 
            // tbAfiliado
            // 
            this.tbAfiliado.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbAfiliado.Location = new System.Drawing.Point(15, 10);
            this.tbAfiliado.Multiline = true;
            this.tbAfiliado.Name = "tbAfiliado";
            this.tbAfiliado.ReadOnly = true;
            this.tbAfiliado.Size = new System.Drawing.Size(348, 38);
            this.tbAfiliado.TabIndex = 0;
            this.tbAfiliado.TextChanged += new System.EventHandler(this.tbAfiliado_TextChanged);
            // 
            // textBox1
            // 
            this.textBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox1.Location = new System.Drawing.Point(15, 56);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.ReadOnly = true;
            this.textBox1.Size = new System.Drawing.Size(348, 38);
            this.textBox1.TabIndex = 13;
            // 
            // cmbMedicos
            // 
            this.cmbMedicos.FormattingEnabled = true;
            this.cmbMedicos.Location = new System.Drawing.Point(194, 65);
            this.cmbMedicos.Name = "cmbMedicos";
            this.cmbMedicos.Size = new System.Drawing.Size(164, 21);
            this.cmbMedicos.TabIndex = 14;
            // 
            // textBox2
            // 
            this.textBox2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox2.Location = new System.Drawing.Point(15, 103);
            this.textBox2.Multiline = true;
            this.textBox2.Name = "textBox2";
            this.textBox2.ReadOnly = true;
            this.textBox2.Size = new System.Drawing.Size(348, 213);
            this.textBox2.TabIndex = 15;
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(28, 332);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.Size = new System.Drawing.Size(328, 150);
            this.dataGridView1.TabIndex = 16;
            // 
            // PedirTurno
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(375, 523);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.monthCalendar1);
            this.Controls.Add(this.cmbMedicos);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btnBuscarTurnos);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cmbBoxListadoEspecialidades);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.tbAfiliado);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.textBox2);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "PedirTurno";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MonthCalendar monthCalendar1;
        private System.Windows.Forms.Button btnBuscarTurnos;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cmbBoxListadoEspecialidades;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox tbAfiliado;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.ComboBox cmbMedicos;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.DataGridView dataGridView1;
    }
}