using MySql.Data.MySqlClient;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
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
                    if(cantidad <= 0 || precio <= 0)
                    {

                        respuesta = "¡Cantidad y precio deben ser mayor a 0!";
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


            }


            return respuesta;

        }

        //Controlador MODIFICAR
        public string ctrlProductos2(string idProducto, string cantidadProducto, string precioProducto, string nombreProducto)
        {
            InventarioModel modelo = new InventarioModel();

            string respuesta = "";

            if (string.IsNullOrEmpty(idProducto))
            {
                respuesta = "Selecciona un producto, por favor";
            }
            else
            {
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
                       if(cantidad <= 0 || precio <= 0)
                        {
                            respuesta = "Debe ingresar valores superiores a 0";
                        }
                        else
                        {
                            try
                            {
                                modelo.ModificarProductos(idProducto, cantidadProducto, precioProducto, nombreProducto);
                                respuesta = "Producto modificado!";
                                // Después de modificar, vuelve a cargar los productos en el DataGridView

                            }
                            catch (MySqlException ex)
                            {
                                respuesta = "Error al modificar el producto: " + ex.Message + "[id producto: " + idProducto + ", cant: " + cantidadProducto
                                    + ", precio: " + precioProducto + ", nombre: " + nombreProducto + "]"; //Imprime el error junto a los valores guardados
                            }
                        }
                    }
                }

                
            }

            return respuesta;
        }

        public string ctrlProductos3(string idProducto)
        {
            InventarioModel modelo = new InventarioModel();
            string respuesta = "";
            if (string.IsNullOrEmpty(idProducto))
            {
                respuesta = "Por favor selecciona un producto para eliminarlo";
            }
            else
            {
                try
                {
                    modelo.EliminarProductos(idProducto);
                    respuesta = "Producto eliminado!";
                }
                catch (MySqlException ex)
                {
                    respuesta = "Error al eliminar el producto: " + ex.Message;
                }
            }
           

            return respuesta;
        }



    }

}
