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
    public partial class Form5 : Form
    {
        public Form5()
        {
            InitializeComponent();
            InventarioModel productos = new InventarioModel();
            productos.MostrarProductos(dgProductos);
        }

        private void dgProductos_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            string idProducto = txtID.Text;
            string nombreProducto = txtProducto.Text;
            string precioProducto = txtPrecio.Text;
            string cantidadProducto = txtCantidad.Text;

            InventarioModel productos = new InventarioModel();
            productos.SelectProductos(dgProductos, txtID, txtProducto, txtPrecio, txtCantidad);
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            string idProducto = txtID.Text;
            string nombreProducto = txtProducto.Text;
            string cantidadProducto = txtCantidad.Text;
            string precioProducto = txtPrecio.Text;

            InventarioControl ctrl = new InventarioControl();
            string respuesta = ctrl.ctrlProductos2(idProducto, cantidadProducto, precioProducto, nombreProducto);  // Pasar ID para poder editar

            MessageBox.Show(respuesta);

            //Actualizar tabla
            InventarioModel productos = new InventarioModel();
            productos.MostrarProductos(dgProductos);
            txtProducto.Clear();
            txtCantidad.Clear();
            txtPrecio.Clear();
        }



        private void btnEliminar_Click(object sender, EventArgs e)
        {
            string idProducto = txtID.Text;

            InventarioControl ctrl = new InventarioControl();
            string respuesta = ctrl.ctrlProductos3(idProducto);

            MessageBox.Show(respuesta);

            // cargar tabla tras borrar un producto
            InventarioModel productos = new InventarioModel();
            productos.MostrarProductos(dgProductos);

            txtProducto.Clear();
            txtCantidad.Clear();
            txtPrecio.Clear();
        }
    }
}
