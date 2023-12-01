using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Inventario
{
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            Form2 form2 = new Form2();
            form2.Show();
            this.Close();

        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            string nombreProducto = txtProducto.Text;
            string cantidadProducto = txtCantidad.Text;
            string precioProducto = txtPrecio.Text;

            InventarioControl ctrl = new InventarioControl();
            string respuesta = ctrl.ctrlProductos(cantidadProducto, precioProducto, nombreProducto);

            MessageBox.Show(respuesta);

            txtProducto.Clear();
            txtCantidad.Clear();
            txtPrecio.Clear();
        }
    }
}

