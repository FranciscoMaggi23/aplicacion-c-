using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidades;
using CapaDatos;
using System.Data.SqlClient;

namespace CapaNegocio
{
    public class ClienteNegocio
    {
        public List<Cliente> listar()
        {
            List<Cliente> lista = new List<Cliente>();
            AccesoDatos conexion = new AccesoDatos();
            try
            {
                conexion.setearConsulta("select Nombre, Apellido, Correo,Edad,Telefono, Servicio from CLIENTES  ");
                conexion.ejecutarConsulta();
                while (conexion.Lector.Read())
                {
                    Cliente cliente = new Cliente();
                    cliente.Nombre = (string)conexion.Lector["Nombre"];
                    cliente.Apellido = (string)conexion.Lector["Apellido"];
                    cliente.Correo = (string)conexion.Lector["Correo"];
                    cliente.Edad = Convert.ToInt32(conexion.Lector["Edad"]);
                    cliente.Telefono = (Int32)conexion.Lector["Telefono"];
                    cliente.Servicio = (string)conexion.Lector["Servicio"];

                    lista.Add(cliente);
                }
                conexion.cerrarConexion();
                return lista;
            }
            catch (Exception)
            {
                throw;
            }
        }

       

    }
}
