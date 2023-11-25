using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventario
{
    class InventarioControl
    {
        public string ctrlLogin(string usuario, string password)
        {
            InventarioModel modelo = new InventarioModel();
            string respuesta = "";
            Usuarios datoUsuario = null;
            if(string.IsNullOrEmpty(password) || string.IsNullOrEmpty(usuario))
            {
                respuesta = "Debe llenar todos los campos";
            }
            else
            {
                datoUsuario = modelo.loginUsuario(usuario);
                if(datoUsuario == null)
                {
                    respuesta = "El usuario no existe";
                }
                else
                {
                    if (datoUsuario.Password != password)
                    {
                        respuesta = "El usuario y/o contraseña no coincide";
                    }
                }
            }
            return respuesta;
        }
    }
}
