using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Enunciado2
{
    public partial class Form1 : Form
    {
        private List<Numero> numeros = new List<Numero>();
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void btnIngresar_Click(object sender, EventArgs e)
        {
            try
            {
                int valor = (int)nudNumeros.Value;
                if (valor == 0)
                {
                    nudNumeros.BackColor = Color.PaleVioletRed;
                    MessageBox.Show("El valor no puede ser 0.", "Error de entrada", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    LimpiarCampos();
                    return;                    
                }
                if (ExisteEnLista(valor))
                {
                    nudNumeros.BackColor = Color.PaleVioletRed;
                    MessageBox.Show("El número ya está en la lista.", "Error de entrada", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    LimpiarCampos();
                    return;                    
                }
                numeros.Add(new Numero(valor));
                nudNumeros.BackColor = Color.LightGreen;
                CargarLista();
                MessageBox.Show("Ingresado correctamente!", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                nudNumeros.Value = nudNumeros.Minimum;
                LimpiarCampos();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ocurrió un error al agregar el número: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                LimpiarCampos();
            }
        }

        private bool ExisteEnLista(int valor)
        {
            foreach (var numero in numeros)
            {
                if (numero.Valor == valor)
                {
                    return true;
                }
            }
            return false;
        }

        private void btnOrdenarAsc_Click(object sender, EventArgs e)
        {
            try
            {
                numeros = numeros.OrderBy(n => n.Valor).ToList();
                CargarLista();
                LimpiarCampos();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ocurrió un error al ordenar la lista: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                LimpiarCampos();
            }
        }

        private void btnOrdenarDesc_Click(object sender, EventArgs e)
        {
            try
            {
                numeros = numeros.OrderByDescending(n => n.Valor).ToList();
                CargarLista();
                LimpiarCampos();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ocurrió un error al ordenar la lista: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                LimpiarCampos();
            }
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            try
            {
                int valor = (int)nudBuscar.Value;
                if (valor == 0)
                {
                    nudBuscar.BackColor = Color.PaleVioletRed;
                    MessageBox.Show("El valor no puede ser 0.", "Error de entrada", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    LimpiarCampos();
                    return;
                }

                // Creamos un int llamado indice y lo inicializamos en -1
                int indice = -1;
                // Creamos un ciclo tipo for para recorrer la lista de numeros y revisar si encontramos el valor ingresado dentro de la lista de num
                for (int i = 0; i < numeros.Count; i++)
                {
                    if (numeros[i].Valor == valor)
                    {
                        indice = i;
                        break;
                    }
                }

                if (indice != -1)
                {
                    nudBuscar.BackColor = Color.LightGreen;
                    MessageBox.Show($"Número encontrado en la posición {indice+1}.", "Búsqueda exitosa", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LimpiarCampos();
                }
                else
                {
                    nudBuscar.BackColor = Color.PaleVioletRed;
                    MessageBox.Show("Número no encontrado en la lista.", "Búsqueda fallida", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LimpiarCampos();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ocurrió un error al buscar el número: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                LimpiarCampos();
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                int valor = (int)nudEliminar.Value;

                if (valor == 0)
                {
                    nudEliminar.BackColor = Color.PaleVioletRed;
                    MessageBox.Show("El valor no puede ser 0.", "Error de entrada", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    LimpiarCampos();
                    return;
                }

                Numero numeroAEliminar = numeros.FirstOrDefault(n => n.Valor == valor);
                if (numeroAEliminar != null)
                {
                    numeros.Remove(numeroAEliminar);
                    nudEliminar.BackColor = Color.LightGreen;
                    MessageBox.Show("Número eliminado de la lista.", "Eliminación exitosa", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    CargarLista();
                    LimpiarCampos();
            
                }
                else
                {
                    nudEliminar.BackColor = Color.PaleVioletRed;
                    MessageBox.Show("Número no encontrado en la lista.", "Eliminación fallida", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LimpiarCampos();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ocurrió un error al eliminar el número: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                LimpiarCampos();
            }
        }

        private void CargarLista()
        {
            try
            {
                lstNumeros.Items.Clear();
                foreach (Numero numero in numeros)
                {
                    lstNumeros.Items.Add(numero);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ocurrió un error al mostrar la lista: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LimpiarCampos()
        {
            nudNumeros.Value = 0;
            nudEliminar.Value = 0;
            nudBuscar.Value = 0;
            nudNumeros.BackColor = Color.White;
            nudEliminar.BackColor = Color.White;
            nudBuscar.BackColor = Color.White;
        }
    }
}
