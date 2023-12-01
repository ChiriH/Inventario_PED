using MySql.Data.MySqlClient;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Inventario
{
    class InventarioControl
    {
        public string ctrlLogin(string usuario, string password)
        {
            InventarioModel modelo = new InventarioModel();
            string respuesta = "";
            Usuarios datoUsuario = null;
            if (string.IsNullOrEmpty(password) || string.IsNullOrEmpty(usuario))
            {
                respuesta = "Debe llenar todos los campos";
            }
            else
            {
                datoUsuario = modelo.loginUsuario(usuario);
                if (datoUsuario == null)
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

        public string ctrlProductos(string cantidadProducto, string precioProducto, string nombreProducto)
        {
            InventarioModel modelo = new InventarioModel();
            string respuesta = "";

            if (string.IsNullOrEmpty(nombreProducto) || string.IsNullOrEmpty(cantidadProducto) || string.IsNullOrEmpty(precioProducto))
            {
                respuesta = "Debe llenar todos los campos";
            }
            else
            {
                int cantidad;
                decimal precio;

                if (!int.TryParse(cantidadProducto, out cantidad) || !decimal.TryParse(precioProducto, out precio))
                {
                    respuesta = "Cantidad o precio no válido";
                }
                else
                {
                    try
                    {
                        if (modelo.ExistenciaProducto(nombreProducto))
                        {
                            respuesta = "El producto ya existe. No se puede añadir duplicados.";
                        }
                        else
                        {
                            modelo.InsertarProductos(cantidadProducto, precioProducto, nombreProducto);
                            respuesta = "Producto añadido!";
                        }
                    }
                    catch (MySqlException ex)
                    {
                        respuesta = "Error al guardar el producto: " + ex.Message;
                    }
                }


            }


            return respuesta;

        }
    }
}
