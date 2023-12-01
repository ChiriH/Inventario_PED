using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace Inventario
{
    class InventarioModel
    {

        public Usuarios loginUsuario(string usuario)
        {
            MySqlDataReader reader;
            MySqlConnection cone = ConexionDB.GetConnection();
            cone.Open();

            string sql = "SELECT id, nombre, pass FROM usuarios WHERE nombre LIKE @nombre";
            MySqlCommand comando = new MySqlCommand(sql, cone);
            comando.Parameters.AddWithValue("@nombre", usuario);

            reader = comando.ExecuteReader();

            Usuarios usr = null;

            while (reader.Read())
            {
                usr = new Usuarios();
                usr.Password = reader["pass"].ToString();
                usr.Usuario = reader["nombre"].ToString();
                usr.Id = int.Parse(reader["id"].ToString());
            }
            return usr;
        }

        public bool ExistenciaProducto(string nombreProducto)
        {
            // conexion 
            MySqlConnection cone = ConexionDB.GetConnection();
            cone.Open();

            string productoExistencia = "SELECT COUNT(*) FROM productos WHERE nombre = @nombre"; //existencia de producto a partir de la cantidad con mismo nombre
            MySqlCommand comandoExistencia = new MySqlCommand(productoExistencia, cone);
            comandoExistencia.Parameters.AddWithValue("@nombre", nombreProducto);//añadir el parametro a la consulta (evitar inyección SQL)

            int cantidadExistente = Convert.ToInt32(comandoExistencia.ExecuteScalar()); // cantidad de productos con el mismo nombre en la BDD 

            cone.Close();

            return cantidadExistente > 0; //si hay productos, retorna true. Si no hay productos, retorna false
        }
        public void InsertarProductos(string cantidadProducto, string precioProducto, string nombreProducto)
        {
            MySqlConnection cone = ConexionDB.GetConnection(); // conexion 
            cone.Open(); // abrir conexion

            string sql = "INSERT INTO productos (nombre, cantidad, precio) VALUES (@nombre, @cantidad, @precio)";
            MySqlCommand comando = new MySqlCommand(sql, cone);
            comando.Parameters.AddWithValue("@nombre", nombreProducto);
            comando.Parameters.AddWithValue("@cantidad", cantidadProducto);
            comando.Parameters.AddWithValue("@precio", precioProducto);

            comando.ExecuteNonQuery();

            cone.Close();
        }
        public void MostrarProductos(DataGridView tablaProductos)
        {
            try
            {
                MySqlConnection cone = ConexionDB.GetConnection();
                string sql = "select * from productos";
                tablaProductos.DataSource = null;
                MySqlDataAdapter adapter = new MySqlDataAdapter(sql, ConexionDB.GetConnection());
                DataTable dt = new DataTable();
                adapter.Fill(dt);
                tablaProductos.DataSource = dt;

                cone.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("No se mostraron los datos de la base de datos, error: " + ex.ToString());
            }
        }

        //Seleccionar productos a modificar del DataGridView
        public void SelectProductos(DataGridView tablaProductos, TextBox id, TextBox nombreProducto, TextBox precioProducto, TextBox cantidadProducto)
        {
            try
            {
                id.Text = tablaProductos.CurrentRow.Cells[0].Value.ToString();
                nombreProducto.Text = tablaProductos.CurrentRow.Cells[1].Value.ToString();
                precioProducto.Text = tablaProductos.CurrentRow.Cells[2].Value.ToString();
                cantidadProducto.Text = tablaProductos.CurrentRow.Cells[3].Value.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Productos no seleccionados, error: " + ex.ToString());
            }
        }
        //Modificar productos del DataGridView
        public void ModificarProductos(string idProducto, string cantidadProducto, string precioProducto, string nombreProducto)
        {
            MySqlConnection cone = ConexionDB.GetConnection();
            cone.Open();

            string sql = "UPDATE productos SET cantidad = @cantidad, precio = @precio, nombre = @nombre WHERE id = @id";
            MySqlCommand comando = new MySqlCommand(sql, cone);
            comando.Parameters.AddWithValue("@id", idProducto);
            comando.Parameters.AddWithValue("@nombre", nombreProducto);
            comando.Parameters.AddWithValue("@cantidad", cantidadProducto);
            comando.Parameters.AddWithValue("@precio", precioProducto);

            comando.ExecuteNonQuery();

            cone.Close();
        }

        public void EliminarProductos(string idProducto)
        {
            MySqlConnection cone = ConexionDB.GetConnection();
            cone.Open();

            string sql = "DELETE FROM productos WHERE id = @id";
            MySqlCommand comando = new MySqlCommand(sql, cone);
            comando.Parameters.AddWithValue("@id", idProducto);

            comando.ExecuteNonQuery();

            cone.Close();

        }
    }
}