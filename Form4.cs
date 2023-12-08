using MySql.Data.MySqlClient;
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
    public partial class Form4 : Form
    {
        public Form4()
        {
            InitializeComponent();
        }


        private void Form4_Load(object sender, EventArgs e)
        {
            try
            {
                InventarioModel vistaProd = new InventarioModel();
                List<Producto> productos = vistaProd.VistaProductos();

                // Establece el origen de datos del DataGridView
                dataGridView1.DataSource = productos;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar los datos: {ex.Message}");
            }
        }
        private void btnCerrar_Click(object sender, EventArgs e)
        {
            Form2 form2 = new Form2();
            form2.Show();
            this.Close();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            string productoBuscar = txtBuscar.Text;

            InventarioModel buscarProd = new InventarioModel();
            List<Producto> productosEncontrados = buscarProd.BuscarProducto(productoBuscar);

            if (productosEncontrados.Count > 0)
            {
                // Producto encontrado
                MessageBox.Show($"Producto encontrado: {productosEncontrados[0].Nombre}");

                // Actualizar el DataGridView solo con el producto encontrado
                dataGridView1.DataSource = productosEncontrados;
            }
            else
            {
                // Producto no encontrado
                MessageBox.Show("¡Ups! El producto no fue encontrado :(");
            }
        }

        private void btnRefrescar_Click(object sender, EventArgs e)
        {
            try
            {
                InventarioModel vistaProd = new InventarioModel();
                List<Producto> productos = vistaProd.VistaProductos();
                dataGridView1.DataSource = productos;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar los datos: {ex.Message}");
            }
        }
    }
}
