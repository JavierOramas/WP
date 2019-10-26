using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace WamaProcessor
{
  
    public partial class Fix : Form
    {
        string _texto;
        string output;

        public Fix(string value, IEnumerable<string> values)
        {
            this.InitializeComponent();
            foreach (string str in values)
                this.comboBox1.Items.AddRange(new object[1]
                {
                    (object) str
                });
            this.valorCabezal.Text = value;
            this._texto = value;
            this.newValue.Text = value;
        }

        private void ComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            object obj = this.comboBox1.Items[this.comboBox1.SelectedIndex];
            StreamWriter streamWriter = new StreamWriter("data\\pairs.txt");
            streamWriter.WriteLine(this._texto + " |&| " + obj);
            streamWriter.Close();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            StreamWriter streamWriter = new StreamWriter("data\\pairs.txt");
            streamWriter.WriteLine("-1 " + this._texto);
            streamWriter.Close();
            this.Close();
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            StreamWriter streamWriter = new StreamWriter("data\\pairs.txt");
            streamWriter.WriteLine(this.newValue.Text + " |&| " + this._texto);
            streamWriter.Close();
        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }

        
    }
}
