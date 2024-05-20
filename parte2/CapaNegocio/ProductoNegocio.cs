using CapaDatos;
using Entidades;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaNegocio
{
    public class ProductoNegocio
    {
        public List<Productos> listarProductos()
        {
            List<Productos> lista = new List<Productos>();
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearConsulta("select Id, Codigo, Nombre, Descripcion, Stock, PrecioCompra ,Estado from PRODUCTO where Estado = 1");
                datos.ejecutarConsulta();
                while (datos.Lector.Read())
                {
                    Productos listaProductos = new Productos();
                    listaProductos.Id = Convert.ToInt32(datos.Lector["Id"]);
                    listaProductos.Codigo = (string)datos.Lector["Codigo"];
                    listaProductos.Nombre = (string)datos.Lector["Nombre"];
                    listaProductos.Descripcion = (string)datos.Lector["Descripcion"];
                    listaProductos.Stock = Convert.ToInt32(datos.Lector["Stock"]);
                    listaProductos.PrecioCompra = Convert.ToDecimal(datos.Lector["PrecioCompra"]);
                    listaProductos.Estado = Convert.ToInt32(datos.Lector["Estado"]);

                    lista.Add(listaProductos);
                }
                datos.cerrarConexion();
                return lista;


            }
            catch (Exception)
            {

                throw;
            }
        }
        public void agregar(Productos obj)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearConsulta("INSERT INTO PRODUCTO(Codigo,Nombre,Descripcion, Stock, PrecioCompra, Estado) VALUES ('"+obj.Codigo+"','"+obj.Nombre+"','"+obj.Descripcion+ "',"+obj.Stock+ ","+obj.PrecioCompra+",@estado)");
                datos.setearParametro("@estado", obj.Estado);
                datos.ejecutarConsulta();
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                datos.cerrarConexion();
            }
        }

        public void modificar(Productos obj)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearConsulta("UPDATE PRODUCTO SET Codigo = @Codigo, Nombre = @Nombre, Descripcion = @Descripcion, Stock = @Stock, PrecioCompra = @PrecioCompra, Estado = @Estado WHERE Id = @Id");
                datos.setearParametro("@Codigo", obj.Codigo);
                datos.setearParametro("@Nombre", obj.Nombre);
                datos.setearParametro("@Descripcion", obj.Descripcion);
                datos.setearParametro("@Stock", obj.Stock);
                datos.setearParametro("@PrecioCompra", obj.PrecioCompra);
                datos.setearParametro("@Estado", obj.Estado);
                datos.setearParametro("@Id", obj.Id);

                datos.ejecutarConsulta();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void EliminarLogico(Productos obj)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearConsulta("UPDATE PRODUCTO SET Estado = '0' WHERE Id = @Id");
                datos.setearParametro("@Id", obj.Id);
                datos.ejecutarConsulta();
            }catch (Exception) { throw; }
        }
    }
}
