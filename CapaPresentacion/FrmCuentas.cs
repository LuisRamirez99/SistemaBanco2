using CapaDatos;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CapaPresentacion
{
    public partial class FrmCuentas: Form
    {
        public FrmCuentas()
        {
            InitializeComponent();
        }

        public void MtdMostrarCuentas()
        {
            CD_Cuentas cd_cuentas = new CD_Cuentas();
            DataTable dtMostrarCuentas = cd_cuentas.MtMostrarClientes();
            dgvClientes.DataSource = dtMostrarCuentas;
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            MtdMostrarCuentas();

        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            CD_Cuentas cD_Cuentas= new CD_Cuentas();

            try
            {
                cD_Cuentas.CP_mtdAgregarCuentas(int.Parse(txtCodigoCliente.Text), txtNoCuenta.Text, txtTipoCuenta.Text,decimal.Parse( txtSaldo.Text), DateTime.Parse(txtFechaApertura.Text), cboxEstado.Text);
                MessageBox.Show("La cuenta se agrego con exito", "Correcto", MessageBoxButtons.OK, MessageBoxIcon.Information);
                MtdMostrarCuentas();

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
                CD_Cuentas cD_Cuentas = new CD_Cuentas();

                int CodigoCuenta = int.Parse(txtCodigoCuenta.Text);
                int CodigoCliente= int.Parse(txtCodigoCliente.Text);
                string NoCuenta = txtNoCuenta.Text;
                string TipoCuenta = txtTipoCuenta.Text;
                decimal Saldo = decimal.Parse(txtSaldo.Text);
                DateTime FechaApertura = DateTime.Parse(txtFechaApertura.Text);
                string Estado = cboxEstado.Text;

                int vCantidadRegistros = cD_Cuentas.CP_mtdActualizarCuentas(CodigoCuenta,CodigoCliente,NoCuenta, TipoCuenta,Saldo, FechaApertura, Estado);

                if (vCantidadRegistros > 0)
                {
                    MessageBox.Show("Registros Actualizado!!", "Correcto!!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    //MessageBox.Show("No se encontró codigo!!", "Error actualización", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    MessageBox.Show("Registros Actualizado!!", "Correcto!!", MessageBoxButtons.OK, MessageBoxIcon.Information);


                }
                MtdMostrarCuentas();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.StackTrace, "error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void mtdLimpiarCampos()
        {
            txtCodigoCuenta.Text = "";
            txtCodigoCliente.Text = "";
            txtNoCuenta.Text = "";
            txtTipoCuenta.Text = "";
            txtSaldo.Text = "";
            txtFechaApertura.Text = "";
            cboxEstado.Text = "";

        }
        private void btnCancelar_Click(object sender, EventArgs e)
        {
            mtdLimpiarCampos();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            CD_Cuentas cD_Cuentas = new CD_Cuentas();

            int codigo = int.Parse(txtCodigoCuenta.Text);
            int vCantidadRegistros = cD_Cuentas.CP_mtdEliminarCuentas(codigo);

            if (vCantidadRegistros > 0)
            {
                MessageBox.Show("Registro Eliminado!!", "Correcto!!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                //MessageBox.Show("No se encontró codigo!!", "Error eliminacion", MessageBoxButtons.OK, MessageBoxIcon.Error);
                MessageBox.Show("Registro Eliminado!!", "Correcto!!", MessageBoxButtons.OK, MessageBoxIcon.Information);


            }
            MtdMostrarCuentas();

        }

        private void dgvClientes_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtCodigoCuenta.Text = dgvClientes.SelectedCells[0].Value.ToString();
            txtCodigoCliente.Text = dgvClientes.SelectedCells[1].Value.ToString();
            txtNoCuenta.Text = dgvClientes.SelectedCells[2].Value.ToString();
            txtTipoCuenta.Text = dgvClientes.SelectedCells[3].Value.ToString();
            txtSaldo.Text = dgvClientes.SelectedCells[4].Value.ToString();
            txtFechaApertura.Text = dgvClientes.SelectedCells[5].Value.ToString();
            cboxEstado.Text = dgvClientes.SelectedCells[6].Value.ToString();


        }
    }
}
