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

        private void MostrarDatos()
        {
            MySqlConnection cone = ConexionDB.GetConnection(); // conexion 
            cone.Open(); // abrir conexion
            string query = "SELECT * FROM productos";
            MySqlCommand cmd = new MySqlCommand(query, cone);
            MySqlDataReader reader = cmd.ExecuteReader();

            // Crear una lista para almacenar los datos
            List<(int, string, decimal)> listaProductos = new List<(int, string, decimal)>();

            while (reader.Read())
            {
                int id = reader.GetInt32(0);
                string nombre = reader.GetString(1);
                decimal precio = reader.GetDecimal(2);

                listaProductos.Add((id, nombre, precio));
            }

            // Enlazar la lista al DataGridView
            dataGridView1.DataSource = listaProductos;

            cone.Close();
        }

        private void Form4_Load(object sender, EventArgs e)
        {
            // Llamar a la función al cargar el formulario
            MostrarDatos();
        }
        private void btnCerrar_Click(object sender, EventArgs e)
        {
            Form2 form2 = new Form2();
            form2.Show();
            this.Close();
        }
    }
}
