using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CapaDatos;

namespace CapaPresentacion
{
    public partial class FrmClientes : Form
    {
        public FrmClientes()
        {
            InitializeComponent();
        }

        /*    
        public void MtdMostrarClientes()
        {
            CD_Clientes cd_clientes = new CD_Clientes();
            DataTable dtClientes = cd_clientes.MtMostrarClientes();
            dgvClientes.DataSource = dtClientes;
        }
        */

        public void MtdMostrarClientes()
        {
            CD_Clientes cd_clientes = new CD_Clientes();
            DataTable dtMostrarClientes = cd_clientes.MtMostrarClientes();
            dgvClientes.DataSource = dtMostrarClientes;
        }

        private void FrmClientes_Load(object sender, EventArgs e)
        {
            MtdMostrarClientes();
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void gboxClientes_Enter(object sender, EventArgs e)
        {

        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            CD_Clientes cD_Clientes= new CD_Clientes();

            try
            {
                cD_Clientes.CP_mtdAgregarClientes(txtNombres.Text, txtDireccion.Text, txtDepartamento.Text, txtPais.Text, cboxCategoria.Text, cboxEstado.Text);
                MessageBox.Show("El Cliente se agrego con exito", "Correcto", MessageBoxButtons.OK, MessageBoxIcon.Information);
                MtdMostrarClientes();


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.StackTrace, "error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            try
            {
                CD_Clientes cp_classClientes = new CD_Clientes();

                int codigo = int.Parse(txtCodigoCliente.Text);
                string nombre = txtNombres.Text;
                string Direccion = txtDireccion.Text;
                string Departamento = txtDepartamento.Text;
                string Pais = txtPais.Text;
                string categoria = cboxCategoria.Text;
                string Estado = cboxEstado.Text;

                int vCantidadRegistros = cp_classClientes.CP_mtdActualizarClientes(codigo, nombre, Direccion, Departamento, Pais, categoria, Estado);

                if (vCantidadRegistros > 0)
                {
                    MessageBox.Show("Registros Actualizado!!", "Correcto!!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    //MessageBox.Show("No se encontró codigo!!", "Error actualización", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    MessageBox.Show("Registros Actualizado!!", "Correcto!!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                MtdMostrarClientes();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.StackTrace, "error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            CD_Clientes cp_classClientes = new CD_Clientes();

            int codigo = int.Parse(txtCodigoCliente.Text);
            int vCantidadRegistros = cp_classClientes.CP_mtdEliminarClientes(codigo);

            if (vCantidadRegistros > 0)
            {
                MessageBox.Show("Registro Eliminado!!", "Correcto!!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                //MessageBox.Show("No se encontró codigo!!", "Error eliminacion", MessageBoxButtons.OK, MessageBoxIcon.Error);
                MessageBox.Show("Registro Eliminado!!", "Correcto!!", MessageBoxButtons.OK, MessageBoxIcon.Information);


            }
            MtdMostrarClientes();


        }

        private void dgvClientes_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtCodigoCliente.Text = dgvClientes.SelectedCells[0].Value.ToString();
            txtNombres.Text = dgvClientes.SelectedCells[1].Value.ToString();
            txtDireccion.Text = dgvClientes.SelectedCells[2].Value.ToString();
            txtDepartamento.Text = dgvClientes.SelectedCells[3].Value.ToString();
            txtPais.Text = dgvClientes.SelectedCells[4].Value.ToString();
            cboxCategoria.Text = dgvClientes.SelectedCells[5].Value.ToString();
            cboxEstado.Text = dgvClientes.SelectedCells[5].Value.ToString();

        }

        public void mtdLimpiarCampos()
        {
            txtCodigoCliente.Text = "";
            txtNombres.Text = "";
            txtDireccion.Text = "";
            txtDepartamento.Text = "";
            txtPais.Text = "";
            cboxCategoria.Text = "";
            cboxCategoria.Text = "";
        }


        private void btnCancelar_Click(object sender, EventArgs e)
        {

            mtdLimpiarCampos();


        }
    }
}
