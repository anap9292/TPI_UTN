using TPI_UTN.Models;
using TPI_UTN.Models.Proveedor;
using System.Data.SqlClient;
using System.Data;

namespace TPI_UTN.Datos
{
    public class OrdenDatos
    {
        public List<Orden> Listar()
        {
            var oLista = new List<Orden>();

            //Instancia de la conexión
            var conexion = new Conexion();

            //usando using, defiimos el tiempo de vida de la conexion
            using (var conexionTemp = new SqlConnection(conexion.getCadenaSQL()))
            {
                conexionTemp.Open();
                SqlCommand cmd = new SqlCommand("ListarOrdenes", conexionTemp);
                cmd.CommandType = CommandType.StoredProcedure;
                // comienza la lectura de datos
                using (var lector = cmd.ExecuteReader())
                {
                    //mientras hayan registros
                    while (lector.Read())
                    {
                        oLista.Add(new Orden()
                        {
                            id = Convert.ToInt32(lector["orde_id"]),
                            cliente = Convert.ToInt32(lector["orde_cliente"]),
                            empleado = Convert.ToInt32(lector["orde_empleado"]),
                            producto = Convert.ToInt32(lector["deta_producto"]),

                            clienteNombre = Convert.ToString(lector["clie_nombre"]),
                            clienteApellido= Convert.ToString(lector["clie_apellido"]),
                            empleadoNombre= Convert.ToString(lector["empl_nombre"]),
                            empleadoApellido = Convert.ToString(lector["empl_apellido"]),
                            productoNombre = Convert.ToString(lector["prod_nombre"]),
                            productoImagen = Convert.ToString(lector["prod_imagen"]),
                            productoDescripcion = Convert.ToString(lector["prod_descripcion"]),

                            cantidad = Convert.ToDecimal(lector["deta_cantidad"]),
                            descuento = Convert.ToDecimal(lector["deta_descuento"]),
                            precioUnitario = Convert.ToDecimal(lector["deta_precio_unitario"]),

                            fecha = Convert.ToDateTime(lector["orde_fecha_compra"])


                        });
                    }
                }
                return oLista;
            }
        }

        public Orden Obtener(int id)
        {
            //Instancia de la conexión
            var conexion = new Conexion();
            var orden = new Orden();
            //usando using, defiimos el tiempo de vida de la conexion
            using (var conexionTemp = new SqlConnection(conexion.getCadenaSQL()))
            {
                conexionTemp.Open();
                SqlCommand cmd = new SqlCommand("ObtenerOrden", conexionTemp);
                cmd.Parameters.AddWithValue("id", id); //busca valores
                cmd.CommandType = CommandType.StoredProcedure;
                // comienza la lectura de datos
                using (var lector = cmd.ExecuteReader())
                {
                    //mientras hayan registros
                    while (lector.Read())
                    {

                        
                            orden.id = Convert.ToInt32(lector["orde_id"]);
                        orden.cliente = Convert.ToInt32(lector["orde_cliente"]);
                        orden.empleado = Convert.ToInt32(lector["orde_empleado"]);
                        orden.producto = Convert.ToInt32(lector["deta_producto"]);

                        orden.clienteNombre = Convert.ToString(lector["clie_nombre"]);
                        orden.clienteApellido = Convert.ToString(lector["clie_apellido"]);
                        orden.empleadoNombre = Convert.ToString(lector["empl_nombre"]);
                        orden.empleadoApellido = Convert.ToString(lector["empl_apellido"]);
                        orden.productoNombre = Convert.ToString(lector["prod_nombre"]);
                        orden.productoImagen = Convert.ToString(lector["prod_imagen"]);
                        orden.productoDescripcion = Convert.ToString(lector["prod_descripcion"]);

                        orden.cantidad = Convert.ToDecimal(lector["deta_cantidad"]);
                        orden.descuento = Convert.ToDecimal(lector["deta_descuento"]);
                        orden.precioUnitario = Convert.ToDecimal(lector["deta_precio_unitario"]);

                        orden.fecha = Convert.ToDateTime(lector["orde_fecha_compra"]);


                        
                    }
                }
                return orden;
            }
        }

        public bool Guardar(Orden objeto)
        {
            bool respuesta;
            try
            {
                var conexion = new Conexion();
                using (var conexionTemp = new SqlConnection(conexion.getCadenaSQL()))
                {
                    conexionTemp.Open();

                    SqlCommand cmd = new SqlCommand("GuardarOrden", conexionTemp);
                    cmd.Parameters.AddWithValue("producto", objeto.producto);
                    cmd.Parameters.AddWithValue("cantidad", objeto.cantidad);
                    cmd.Parameters.AddWithValue("cliente", objeto.cliente);
                    cmd.Parameters.AddWithValue("empleado", objeto.empleado);
                    cmd.Parameters.AddWithValue("descuento", objeto.descuento);

                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.ExecuteNonQuery();
                }

                respuesta = true;
            }
            catch (Exception e)
            {
                string error = e.Message;
                respuesta = false;
            }
            return respuesta;
        }

        public bool Editar (Orden objeto)
        {
            bool respuesta;
            try
            {
                var conexion = new Conexion();
                using (var conexionTemp = new SqlConnection(conexion.getCadenaSQL()))
                {
                    conexionTemp.Open();

                    SqlCommand cmd = new SqlCommand("EditarOrden", conexionTemp);
                    cmd.Parameters.AddWithValue("id", objeto.id);
                    cmd.Parameters.AddWithValue("producto", objeto.producto);
                    cmd.Parameters.AddWithValue("cantidad", objeto.cantidad);
                    cmd.Parameters.AddWithValue("cliente", objeto.cliente);
                    cmd.Parameters.AddWithValue("empleado", objeto.empleado);
                    cmd.Parameters.AddWithValue("descuento", objeto.descuento);
                    cmd.Parameters.AddWithValue("precio", objeto.precioUnitario);




                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.ExecuteNonQuery();
                }

                respuesta = true;
            }
            catch (Exception e)
            {
                string error = e.Message;
                respuesta = false;
            }
            return respuesta;
        }

        public bool Eliminar (int id)
        {
            bool respuesta;
            try
            {
                var conexion = new Conexion();
                using (var conexionTemp = new SqlConnection(conexion.getCadenaSQL()))
                {
                    conexionTemp.Open();

                    SqlCommand cmd = new SqlCommand("EliminarOrden", conexionTemp);
                    cmd.Parameters.AddWithValue("id", id); //este solo se usa para encontrar el registro
                    //modificar valores
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.ExecuteNonQuery();
                }

                respuesta = true;
            }
            catch (Exception e)
            {
                string error = e.Message;
                respuesta = false;
            }
            return respuesta;
        }

        public bool Cancelar(int id)
        {
            bool respuesta;
            try
            {
                var conexion = new Conexion();
                using (var conexionTemp = new SqlConnection(conexion.getCadenaSQL()))
                {
                    conexionTemp.Open();

                    SqlCommand cmd = new SqlCommand("CancelarOrden", conexionTemp);
                    cmd.Parameters.AddWithValue("id", id); //este solo se usa para encontrar el registro
                    //modificar valores
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.ExecuteNonQuery();
                }

                respuesta = true;
            }
            catch (Exception e)
            {
                string error = e.Message;
                respuesta = false;
            }
            return respuesta;
        }

    }
}
