using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Inventario
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            Form1 form1 = new Form1();
            form1.Show();
            this.Close();

        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            Form3 form3 = new Form3();
            form3.Visible = true;
            this.Visible = false;
        }

        private void btnVer_Click(object sender, EventArgs e)
        {
            Form4 form4 = new Form4();
            form4.Visible = true;
            this.Visible = false;
        }
    }
}
