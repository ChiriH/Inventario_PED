using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace Inventario
{
    class InventarioModel
    {
        /*public int registro(Usuarios usuario)
        {
            MySqlConnection cone = ConexionDB.GetConnection();
            cone.Open();

            string sql = "INSERT INTO adminusers (nombre_usuaro, password, admin_id) VALUES @nombre_usuario, @password, @id)";

            MySqlCommand comando = new MySqlCommand(sql, cone);
            comando.Parameters.AddWithValue("@nombre_usuario", usuario.Usuario);
            comando.Parameters.AddWithValue("@password", usuario.Password);
            comando.Parameters.AddWithValue("@admin_id", 1);
        } */


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
    }
}