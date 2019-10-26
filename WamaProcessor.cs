using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WamaProcessor
{
    public partial class Form1 : Form
    {
        private string _saveaddress = "processed_file.xlsx";
        private Main _item;
        string _type;

        public Form1()
        {  
            this._item = new Main();
            this.InitializeComponent();
            this.label1.Text = "Property of Wamasol Tours®" + DateTime.Today.Year.ToString() + " All Rights Reserved";
            this.label2.Text = "Property of Wamasol Tours®" + DateTime.Today.Year.ToString() + " All Rights Reserved";
            this._item.ImportData();
        }

        private void Procesar_Click(object sender, EventArgs e)
        {
            GetTypeOfData();
            if (_type == null)
                return;

            if (this._item == null)
                return;
            this._item.Process(_type);
            this._item.GetInfo();
            if(MessageBox.Show("Desea Guardar los datos en un directorio específico?", string.Empty,MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                if (this.guardarxlsx.ShowDialog() != DialogResult.OK)
                    return;

                this._saveaddress = this.guardarxlsx.FileName;
            }

            this._item.PrintInfo(this._saveaddress);

            MessageBox.Show("Listo, guardado en " +this._saveaddress);
        }

        private void  GetTypeOfData()
        {
            if (IsNew.Checked)
                _type = "Nuevo";
            else if (IsOffer.Checked)
                _type = "Oferta";
            else if (IsUpdate.Checked)
                _type = "Update";
            else
            {
                _type = null;
                MessageBox.Show("Debe Especificar la clasificacion de estos datos");
            }
        }

        private void guardarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.guardarxlsx.ShowDialog() != DialogResult.OK)
                return;

            this._saveaddress = this.guardarxlsx.FileName;
        }

        private void dates_Click(object sender, EventArgs e)
        {
            // DO check id file exists

            Advanced.ReadData(this._saveaddress);
            Advanced.FixDate();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (this.abrirxlsx.ShowDialog() != DialogResult.OK)
                return;

            this._item = new Main(this.abrirxlsx.FileName);
        }
    }
}
