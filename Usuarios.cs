using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace Inventario
{
    class Usuarios
    {
        int id;
        string usuario, password;

        public string Usuario { get => usuario; set => usuario = value; }
        public int Id { get => id; set=> id = value; }
        public string Password { get => password; set => password = value; }

    }
}
