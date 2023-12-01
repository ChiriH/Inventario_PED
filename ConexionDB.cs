using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Windows.Forms;

namespace Inventario
{
    class ConexionDB
    {
        public static MySqlConnection GetConnection()
        {
            // MySqlConnection cone = new MySqlConnection();

            string servidor = "localhost";
            string bd = "inventario";
            string usuario = "root";
            string password = "base0326";
            //string password = "root1234"; contraseña william
            string puerto = "3306";

            string cadenaCone = "server=" + servidor + ";" + "port=" + puerto + ";" + "user id=" + usuario + ";" + "password=" + password + ";" + "database=" + bd + ";";


            try
            {
                MySqlConnection cone = new MySqlConnection(cadenaCone);
                return cone;
            }
            catch (MySqlException ex)
            {
                Console.WriteLine("Error: " + ex.Message);
                return null;
            }
        }
    }
}
