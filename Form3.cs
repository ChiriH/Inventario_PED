using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Inventario
{
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            Form2 form2 = new Form2();
            form2.Show();
            this.Close();

        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            string producto = txtProducto.Text;
            string cantidadTexto = txtCantidad.Text;
            string precioTexto = txtPrecio.Text;


            if (string.IsNullOrEmpty(producto) || string.IsNullOrEmpty(cantidadTexto) || string.IsNullOrEmpty(precioTexto))
            {
                MessageBox.Show("Debe llenar todos los campos", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else if(!int.TryParse(cantidadTexto, out int cantidad))
            {
                // Convertir cantidad y precio a tipos numéricos
                
                
                    MessageBox.Show("La cantidad debe ser un número válido.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else if (!float.TryParse(precioTexto, out float precio))
                {
                    MessageBox.Show("El precio debe ser un número válido.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information); ;
                }
                else
                {
                
                MessageBox.Show("Los campos se han completado correctamente.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information); ;
                }
            }
        }
    }

