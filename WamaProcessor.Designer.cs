using System;
namespace WamaProcessor
{
    partial class Form1
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
            this._item.ExportData();
            if (disposing && this.components != null)
                this.components.Dispose();
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabCubatur = new System.Windows.Forms.TabPage();
            this.label1 = new System.Windows.Forms.Label();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.button3 = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.dates = new System.Windows.Forms.Button();
            this.Procesar = new System.Windows.Forms.Button();
            this.IsOffer = new System.Windows.Forms.RadioButton();
            this.IsUpdate = new System.Windows.Forms.RadioButton();
            this.IsNew = new System.Windows.Forms.RadioButton();
            this.tabIslazul = new System.Windows.Forms.TabPage();
            this.label2 = new System.Windows.Forms.Label();
            this.comboBox2 = new System.Windows.Forms.ComboBox();
            this.button1 = new System.Windows.Forms.Button();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.button2 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.radioButton1 = new System.Windows.Forms.RadioButton();
            this.radioButton2 = new System.Windows.Forms.RadioButton();
            this.radioButton3 = new System.Windows.Forms.RadioButton();
            this.abrirxlsx = new System.Windows.Forms.OpenFileDialog();
            this.guardarxlsx = new System.Windows.Forms.SaveFileDialog();
            this.tabControl1.SuspendLayout();
            this.tabCubatur.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.tabIslazul.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabCubatur);
            this.tabControl1.Controls.Add(this.tabIslazul);
            this.tabControl1.Location = new System.Drawing.Point(0, 12);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(549, 292);
            this.tabControl1.TabIndex = 0;
            // 
            // tabCubatur
            // 
            this.tabCubatur.BackColor = System.Drawing.Color.AliceBlue;
            this.tabCubatur.Controls.Add(this.label1);
            this.tabCubatur.Controls.Add(this.comboBox1);
            this.tabCubatur.Controls.Add(this.button3);
            this.tabCubatur.Controls.Add(this.pictureBox1);
            this.tabCubatur.Controls.Add(this.dates);
            this.tabCubatur.Controls.Add(this.Procesar);
            this.tabCubatur.Controls.Add(this.IsOffer);
            this.tabCubatur.Controls.Add(this.IsUpdate);
            this.tabCubatur.Controls.Add(this.IsNew);
            this.tabCubatur.Location = new System.Drawing.Point(4, 25);
            this.tabCubatur.Name = "tabCubatur";
            this.tabCubatur.Padding = new System.Windows.Forms.Padding(3);
            this.tabCubatur.Size = new System.Drawing.Size(541, 263);
            this.tabCubatur.TabIndex = 0;
            this.tabCubatur.Text = "Cubatur";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(37, 230);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(0, 17);
            this.label1.TabIndex = 8;
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "Hoteles",
            "Autos",
            "Transfer",
            "Vuelos"});
            this.comboBox1.Location = new System.Drawing.Point(287, 30);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(205, 24);
            this.comboBox1.TabIndex = 7;
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(287, 74);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(205, 31);
            this.button3.TabIndex = 6;
            this.button3.Text = "Abrir";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pictureBox1.BackgroundImage")));
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pictureBox1.InitialImage = null;
            this.pictureBox1.Location = new System.Drawing.Point(34, 74);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(176, 125);
            this.pictureBox1.TabIndex = 5;
            this.pictureBox1.TabStop = false;
            // 
            // dates
            // 
            this.dates.Location = new System.Drawing.Point(287, 176);
            this.dates.Name = "dates";
            this.dates.Size = new System.Drawing.Size(205, 31);
            this.dates.TabIndex = 4;
            this.dates.Text = "Arreglar Fechas";
            this.dates.UseVisualStyleBackColor = true;
            this.dates.Click += new System.EventHandler(this.dates_Click);
            // 
            // Procesar
            // 
            this.Procesar.Location = new System.Drawing.Point(287, 125);
            this.Procesar.Name = "Procesar";
            this.Procesar.Size = new System.Drawing.Size(205, 31);
            this.Procesar.TabIndex = 3;
            this.Procesar.Text = "Procesar";
            this.Procesar.UseVisualStyleBackColor = true;
            this.Procesar.Click += new System.EventHandler(this.Procesar_Click);
            // 
            // IsOffer
            // 
            this.IsOffer.AutoSize = true;
            this.IsOffer.Location = new System.Drawing.Point(110, 29);
            this.IsOffer.Name = "IsOffer";
            this.IsOffer.Size = new System.Drawing.Size(69, 21);
            this.IsOffer.TabIndex = 2;
            this.IsOffer.Text = "Oferta";
            this.IsOffer.UseVisualStyleBackColor = true;
            // 
            // IsUpdate
            // 
            this.IsUpdate.AutoSize = true;
            this.IsUpdate.Location = new System.Drawing.Point(185, 29);
            this.IsUpdate.Name = "IsUpdate";
            this.IsUpdate.Size = new System.Drawing.Size(75, 21);
            this.IsUpdate.TabIndex = 1;
            this.IsUpdate.Text = "Update";
            this.IsUpdate.UseVisualStyleBackColor = true;
            // 
            // IsNew
            // 
            this.IsNew.AutoSize = true;
            this.IsNew.Checked = true;
            this.IsNew.Location = new System.Drawing.Point(34, 29);
            this.IsNew.Name = "IsNew";
            this.IsNew.Size = new System.Drawing.Size(70, 21);
            this.IsNew.TabIndex = 0;
            this.IsNew.TabStop = true;
            this.IsNew.Text = "Nuevo";
            this.IsNew.UseVisualStyleBackColor = true;
            // 
            // tabIslazul
            // 
            this.tabIslazul.BackColor = System.Drawing.Color.AliceBlue;
            this.tabIslazul.Controls.Add(this.label2);
            this.tabIslazul.Controls.Add(this.comboBox2);
            this.tabIslazul.Controls.Add(this.button1);
            this.tabIslazul.Controls.Add(this.pictureBox2);
            this.tabIslazul.Controls.Add(this.button2);
            this.tabIslazul.Controls.Add(this.button4);
            this.tabIslazul.Controls.Add(this.radioButton1);
            this.tabIslazul.Controls.Add(this.radioButton2);
            this.tabIslazul.Controls.Add(this.radioButton3);
            this.tabIslazul.Location = new System.Drawing.Point(4, 25);
            this.tabIslazul.Name = "tabIslazul";
            this.tabIslazul.Padding = new System.Windows.Forms.Padding(3);
            this.tabIslazul.Size = new System.Drawing.Size(541, 263);
            this.tabIslazul.TabIndex = 1;
            this.tabIslazul.Text = "Islazul";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(36, 228);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(0, 17);
            this.label2.TabIndex = 10;
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // comboBox2
            // 
            this.comboBox2.FormattingEnabled = true;
            this.comboBox2.Items.AddRange(new object[] {
            "Hoteles"});
            this.comboBox2.Location = new System.Drawing.Point(287, 33);
            this.comboBox2.Name = "comboBox2";
            this.comboBox2.Size = new System.Drawing.Size(205, 24);
            this.comboBox2.TabIndex = 15;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(287, 77);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(205, 31);
            this.button1.TabIndex = 14;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // pictureBox2
            // 
            this.pictureBox2.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pictureBox2.BackgroundImage")));
            this.pictureBox2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pictureBox2.InitialImage = null;
            this.pictureBox2.Location = new System.Drawing.Point(34, 86);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(176, 125);
            this.pictureBox2.TabIndex = 13;
            this.pictureBox2.TabStop = false;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(287, 179);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(205, 31);
            this.button2.TabIndex = 12;
            this.button2.Text = "Arreglar Fechas";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(287, 128);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(205, 31);
            this.button4.TabIndex = 11;
            this.button4.Text = "button4";
            this.button4.UseVisualStyleBackColor = true;
            // 
            // radioButton1
            // 
            this.radioButton1.AutoSize = true;
            this.radioButton1.Location = new System.Drawing.Point(110, 32);
            this.radioButton1.Name = "radioButton1";
            this.radioButton1.Size = new System.Drawing.Size(69, 21);
            this.radioButton1.TabIndex = 10;
            this.radioButton1.Text = "Oferta";
            this.radioButton1.UseVisualStyleBackColor = true;
            // 
            // radioButton2
            // 
            this.radioButton2.AutoSize = true;
            this.radioButton2.Location = new System.Drawing.Point(185, 32);
            this.radioButton2.Name = "radioButton2";
            this.radioButton2.Size = new System.Drawing.Size(75, 21);
            this.radioButton2.TabIndex = 9;
            this.radioButton2.Text = "Update";
            this.radioButton2.UseVisualStyleBackColor = true;
            // 
            // radioButton3
            // 
            this.radioButton3.AutoSize = true;
            this.radioButton3.Checked = true;
            this.radioButton3.Location = new System.Drawing.Point(34, 32);
            this.radioButton3.Name = "radioButton3";
            this.radioButton3.Size = new System.Drawing.Size(70, 21);
            this.radioButton3.TabIndex = 8;
            this.radioButton3.TabStop = true;
            this.radioButton3.Text = "Nuevo";
            this.radioButton3.UseVisualStyleBackColor = true;
            // 
            // abrirxlsx
            // 
            this.abrirxlsx.FileName = "openFileDialog1";
            this.abrirxlsx.Filter = "XLSX | *.xlsx";
            // 
            // guardarxlsx
            // 
            this.guardarxlsx.Filter = "XLSX|*.xlsx";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.ClientSize = new System.Drawing.Size(547, 302);
            this.Controls.Add(this.tabControl1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.Text = "WamaProcessor";
            this.tabControl1.ResumeLayout(false);
            this.tabCubatur.ResumeLayout(false);
            this.tabCubatur.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.tabIslazul.ResumeLayout(false);
            this.tabIslazul.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabCubatur;
        private System.Windows.Forms.TabPage tabIslazul;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button dates;
        private System.Windows.Forms.Button Procesar;
        private System.Windows.Forms.RadioButton IsOffer;
        private System.Windows.Forms.RadioButton IsUpdate;
        private System.Windows.Forms.RadioButton IsNew;
        private System.Windows.Forms.OpenFileDialog abrirxlsx;
        private System.Windows.Forms.SaveFileDialog guardarxlsx;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox comboBox2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.RadioButton radioButton1;
        private System.Windows.Forms.RadioButton radioButton2;
        private System.Windows.Forms.RadioButton radioButton3;
        private System.Windows.Forms.Label label2;
    }
}

