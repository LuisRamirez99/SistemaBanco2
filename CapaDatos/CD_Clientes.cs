﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDatos
{
    public class CD_Clientes
    {
    
        CD_Conexion db_conexion = new CD_Conexion();

        public DataTable MtMostrarClientes()
        {
            string QryMostrarClientes = "usp_clientes_mostrar";
            SqlDataAdapter adapter = new SqlDataAdapter(QryMostrarClientes,db_conexion.MtdAbrirConexion());
            DataTable dtMostrarClientes = new DataTable();
            adapter.Fill(dtMostrarClientes);
            db_conexion.MtdCerrarConexion();
            return dtMostrarClientes;
        }

        // Capa datos
        public void CP_mtdAgregarClientes(string Nombre, string Direccion, string Departamento, string Pais, string Categoria, string Estado)
        {
    
            string Usp_crear = "usp_clientes_crear";
            SqlCommand cmd_InsertarClientes = new SqlCommand(Usp_crear, db_conexion.MtdAbrirConexion());
            cmd_InsertarClientes.CommandType = CommandType.StoredProcedure;

            cmd_InsertarClientes.Parameters.AddWithValue("@Nombre", Nombre);
            cmd_InsertarClientes.Parameters.AddWithValue("@Direccion", Direccion);
            cmd_InsertarClientes.Parameters.AddWithValue("@Departamento", Departamento);
            cmd_InsertarClientes.Parameters.AddWithValue("@Pais", Pais);
            cmd_InsertarClientes.Parameters.AddWithValue("@Categoria", Categoria);
            cmd_InsertarClientes.Parameters.AddWithValue("@Estado", Estado);
            cmd_InsertarClientes.ExecuteNonQuery();
        }
        public int CP_mtdActualizarClientes(int Codigo, string Nombre, string Direccion, string Departamento, string Pais, string Categoria, string Estado)
        {
            int vContarRegistrosAfectados = 0;

            string vUspActualizarClientes = "usp_clientes_editar";
            SqlCommand commActualizarClientes = new SqlCommand(vUspActualizarClientes, db_conexion.MtdAbrirConexion());
            commActualizarClientes.CommandType = CommandType.StoredProcedure;

            commActualizarClientes.Parameters.AddWithValue("@Codigo", Codigo);
            commActualizarClientes.Parameters.AddWithValue("@Nombre", Nombre);
            commActualizarClientes.Parameters.AddWithValue("@Direccion", Direccion);
            commActualizarClientes.Parameters.AddWithValue("@Departamento", Departamento);
            commActualizarClientes.Parameters.AddWithValue("@Pais", Pais);
            commActualizarClientes.Parameters.AddWithValue("@Categoria", Categoria);
            commActualizarClientes.Parameters.AddWithValue("@Estado", Estado);

            vContarRegistrosAfectados = commActualizarClientes.ExecuteNonQuery();
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

        public int CP_mtdEliminarClientes(int codigo)
        {
            int vCantidadRegistrosEliminados = 0;

            string vUspEliminarClientes = "usp_clientes_eliminar";
            SqlCommand commEliminarClientes = new SqlCommand(vUspEliminarClientes, db_conexion.MtdAbrirConexion());
            commEliminarClientes.CommandType = CommandType.StoredProcedure;

            commEliminarClientes.Parameters.AddWithValue("@Codigo", codigo);

            vCantidadRegistrosEliminados = commEliminarClientes.ExecuteNonQuery();
            return vCantidadRegistrosEliminados;
        }
    }
}
