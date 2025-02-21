using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDatos
{
    public class CD_Cuentas
    {

        CD_Conexion db_conexion = new CD_Conexion();

        public DataTable MtMostrarClientes()
        {
            string QryMostrarCuentas = "usp_cuentas_mostrar";
            SqlDataAdapter adapter = new SqlDataAdapter(QryMostrarCuentas, db_conexion.MtdAbrirConexion());
            DataTable dtMostrarCuentas = new DataTable();
            adapter.Fill(dtMostrarCuentas);
            db_conexion.MtdCerrarConexion();
            return dtMostrarCuentas;
        }

        // Capa datos
        public void CP_mtdAgregarCuentas(int CodigoCliente, string NumeroCuenta, string TipoCuenta, decimal Saldo, DateTime FechaApertura, string Estado)
        {

            string Usp_crear = "usp_cuentas_crear";
            SqlCommand cmd_InsertarCuentas = new SqlCommand(Usp_crear, db_conexion.MtdAbrirConexion());
            cmd_InsertarCuentas.CommandType = CommandType.StoredProcedure;

            cmd_InsertarCuentas.Parameters.AddWithValue("@CodigoCliente", CodigoCliente);
            cmd_InsertarCuentas.Parameters.AddWithValue("@NumeroCuenta", NumeroCuenta);
            cmd_InsertarCuentas.Parameters.AddWithValue("@TipoCuenta", TipoCuenta);
            cmd_InsertarCuentas.Parameters.AddWithValue("@Saldo", Saldo);
            cmd_InsertarCuentas.Parameters.AddWithValue("@FechaApertura", FechaApertura);
            cmd_InsertarCuentas.Parameters.AddWithValue("@Estado", Estado);
            cmd_InsertarCuentas.ExecuteNonQuery();
        }
        public int CP_mtdActualizarCuentas(int CodigoCuenta, int CodigoCliente, string NumeroCuenta, string TipoCuenta, decimal Saldo, DateTime FechaApertura, string Estado)
        {
            int vContarRegistrosAfectados = 0;

            string vUspActualizarCuentas = "usp_cuentas_editar";
            SqlCommand commActualizarCuentas = new SqlCommand(vUspActualizarCuentas, db_conexion.MtdAbrirConexion());
            commActualizarCuentas.CommandType = CommandType.StoredProcedure;

            commActualizarCuentas.Parameters.AddWithValue("@CodigoCuenta", CodigoCuenta);
            commActualizarCuentas.Parameters.AddWithValue("@CodigoCliente", CodigoCliente);
            commActualizarCuentas.Parameters.AddWithValue("@NumeroCuenta", NumeroCuenta);
            commActualizarCuentas.Parameters.AddWithValue("@TipoCuenta", TipoCuenta);
            commActualizarCuentas.Parameters.AddWithValue("@Saldo", Saldo);
            commActualizarCuentas.Parameters.AddWithValue("@FechaApertura", FechaApertura);
            commActualizarCuentas.Parameters.AddWithValue("@Estado", Estado);

            vContarRegistrosAfectados = commActualizarCuentas.ExecuteNonQuery();
            return vContarRegistrosAfectados;
        }

        //public int CP_mtdActualizarClientes(int Codigo, string Nombre, string Direccion, string Departamento, string Pais, string Categoria, string Estado)
        //{
        //    int filasAfectadas = 0;

        //    using (SqlConnection conexion = db_conexion.MtdAbrirConexion())
        //    {
        //        using (SqlCommand cmd = new SqlCommand("usp_clientes_editar", conexion))
        //        {
        //            cmd.CommandType = CommandType.StoredProcedure;
        //            cmd.Parameters.AddWithValue("@Codigo", Codigo);
        //            cmd.Parameters.AddWithValue("@Nombre", Nombre);
        //            cmd.Parameters.AddWithValue("@Direccion", Direccion);
        //            cmd.Parameters.AddWithValue("@Departamento", Departamento);
        //            cmd.Parameters.AddWithValue("@Pais", Pais);
        //            cmd.Parameters.AddWithValue("@Categoria", Categoria);
        //            cmd.Parameters.AddWithValue("@Estado", Estado);

        //            filasAfectadas = cmd.ExecuteNonQuery();
        //        }
        //    }

        //    return filasAfectadas;
        //}

        public int CP_mtdEliminarCuentas(int Codigo)
        {
            int vCantidadRegistrosEliminados = 0;

            string vUspEliminarCuentas = "usp_cuentas_eliminar";
            SqlCommand commEliminarCuentas = new SqlCommand(vUspEliminarCuentas, db_conexion.MtdAbrirConexion());
            commEliminarCuentas.CommandType = CommandType.StoredProcedure;

            commEliminarCuentas.Parameters.AddWithValue("@Codigo", Codigo);

            vCantidadRegistrosEliminados = commEliminarCuentas.ExecuteNonQuery();
            return vCantidadRegistrosEliminados;
        }
    }
}
