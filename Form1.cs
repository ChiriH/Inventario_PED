using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace Inventario
{
    public partial class Form1 : Form
    {
        
        public Form1()
        {
            InitializeComponent();
            
        }

        private void btnIniciar_Click(object sender, EventArgs e)
        {
            string usuario = txtUser.Text;
            string password = txtPassword.Text;

            try
            {
                InventarioControl ctrl = new InventarioControl();
                string respuesta = ctrl.ctrlLogin(usuario, password);
                if (respuesta.Length > 0)
                {
                    MessageBox.Show(respuesta, "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    
                }
                else
                {
                    Form2 form2 = new Form2();
                    form2.Visible = true;
                    this.Visible = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void txtSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
