using System.Data.SqlClient;
using System.Data;
using TPI_UTN.Models;
using TPI_UTN.Models.Proveedor;

namespace TPI_UTN.Datos
{
    public class PromocionDatos
    {
        public List<Promocion> Listar()
        {

            //Recibir informacion
            var oLista = new List<Promocion>();

            //Instancia de la conexión
            var conexion = new Conexion();

            //usando using, defiimos el tiempo de vida de la conexion
            using (var conexionTemp = new SqlConnection(conexion.getCadenaSQL()))
            {
                conexionTemp.Open();
                SqlCommand cmd = new SqlCommand("ListarPromocion", conexionTemp);
                cmd.CommandType = CommandType.StoredProcedure;
                // comienza la lectura de datos
                using (var lector = cmd.ExecuteReader())
                {
                    //mientras hayan registros
                    while (lector.Read())
                    {
                        oLista.Add(new Promocion()
                        {
                            id = Convert.ToInt32(lector["prom_id"]),
                            nombre = Convert.ToString(lector["prom_nombre"]),
                            imagen = Convert.ToString(lector["prod_imagen"]),
                            descuento = Convert.ToDecimal(lector["prom_descuento"]),
                            descripcion = Convert.ToString(lector["prod_descripcion"])
                        });
                    }
                }
                return oLista;
            }
        }


        public Promocion Obtener(int idBuscado)
        {
            var oProducto = new Promocion();
            var conexion = new Conexion();

            using (var conexionTemp = new SqlConnection(conexion.getCadenaSQL()))
            {
                conexionTemp.Open();

                SqlCommand cmd = new SqlCommand("ObtenerPromocion", conexionTemp);
                cmd.Parameters.AddWithValue("id", idBuscado); //busca valores
                cmd.CommandType = CommandType.StoredProcedure;

                using (var lector = cmd.ExecuteReader())
                {
                    while (lector.Read())
                    {
                        oProducto.id = Convert.ToInt32(lector["prom_id"]);
                        oProducto.nombre = Convert.ToString(lector["prom_nombre"]);
                        oProducto.descuento = Convert.ToDecimal(lector["prom_descuento"]);
                        oProducto.imagen = Convert.ToString(lector["prod_imagen"]);
                        oProducto.descripcion = Convert.ToString(lector["prod_descripcion"]);
                    }
                }
            }
            return oProducto;

        }

        public bool Guardar(Promocion oProducto)
        {
            bool respuesta;
            try
            {
                var conexion = new Conexion();
                using (var conexionTemp = new SqlConnection(conexion.getCadenaSQL()))
                {
                    conexionTemp.Open();

                    SqlCommand cmd = new SqlCommand("GuardarPromocion", conexionTemp);
                    cmd.Parameters.AddWithValue("nombre", oProducto.nombre);
                    cmd.Parameters.AddWithValue("descuento", oProducto.descuento);
                    cmd.Parameters.AddWithValue("imagen", oProducto.imagen);
                    cmd.Parameters.AddWithValue("descripcion", oProducto.descripcion);


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

        public bool Editar(Promocion oProducto)
        {
            bool respuesta;
            try
            {
                var conexion = new Conexion();
                using (var conexionTemp = new SqlConnection(conexion.getCadenaSQL()))
                {
                    conexionTemp.Open();

                    SqlCommand cmd = new SqlCommand("EditarPromocion", conexionTemp);
                    cmd.Parameters.AddWithValue("nombre", oProducto.nombre);
                    cmd.Parameters.AddWithValue("descuento", oProducto.descuento);
                    cmd.Parameters.AddWithValue("imagen", oProducto.imagen);
                    cmd.Parameters.AddWithValue("descripcion", oProducto.descripcion);

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

        public bool Eliminar(int id)
        {
            bool respuesta;
            try
            {
                var conexion = new Conexion();
                using (var conexionTemp = new SqlConnection(conexion.getCadenaSQL()))
                {
                    conexionTemp.Open();

                    SqlCommand cmd = new SqlCommand("EliminarProducto", conexionTemp);
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

        public List<Producto> ListarProducto(int id)
        {

            //Recibir informacion
            var oLista = new List<Producto>();

            //Instancia de la conexión
            var conexion = new Conexion();

            //usando using, defiimos el tiempo de vida de la conexion
            using (var conexionTemp = new SqlConnection(conexion.getCadenaSQL()))
            {
                conexionTemp.Open();
                SqlCommand cmd = new SqlCommand("ListarProductosPorPromocion", conexionTemp);
                cmd.Parameters.AddWithValue("id", id); //busca valores
                cmd.CommandType = CommandType.StoredProcedure;
                // comienza la lectura de datos
                using (var lector = cmd.ExecuteReader())
                {
                    //mientras hayan registros
                    while (lector.Read())
                    {
                        oLista.Add(new Producto()
                        {
                            id = Convert.ToInt32(lector["prod_id"]),
                            nombre = Convert.ToString(lector["prod_nombre"]),
                            imagen = Convert.ToString(lector["prod_imagen"]),
                            descripcion = Convert.ToString(lector["prod_descripcion"]),
                            precio = Convert.ToDecimal(lector["prod_precio"]),
                            stock = Convert.ToDecimal(lector["prod_stock"])

                        });
                    }
                    return oLista;
                }
            }

        }

        public List<PromocionProducto> ListarPP(int id)
        {

            //Recibir informacion
            var oLista = new List<PromocionProducto>();

            //Instancia de la conexión
            var conexion = new Conexion();

            //usando using, defiimos el tiempo de vida de la conexion
            using (var conexionTemp = new SqlConnection(conexion.getCadenaSQL()))
            {
                conexionTemp.Open();
                SqlCommand cmd = new SqlCommand("ListarProductosPorPromocion", conexionTemp);
                cmd.Parameters.AddWithValue("id", id); //busca valores
                cmd.CommandType = CommandType.StoredProcedure;
                // comienza la lectura de datos
                using (var lector = cmd.ExecuteReader())
                {
                    //mientras hayan registros
                    while (lector.Read())
                    {
                        oLista.Add(new PromocionProducto()
                        {
                            id = Convert.ToInt32(lector["pp_id"]),
                            fechaInicio = Convert.ToDateTime(lector["pp_fecha_inicio"]),
                            fechaFinal = Convert.ToDateTime(lector["pp_fecha_final"]),
                            producto = Convert.ToInt32(lector["pp_producto"]),
                            promocion = Convert.ToInt32(lector["pp_promocion"])

                        });
                    }
                    return oLista;
                }
            }

        }

        public bool AgregarProducto(PromocionProducto objeto)
        {
            bool respuesta;
            try
            {
                var conexion = new Conexion();
                using (var conexionTemp = new SqlConnection(conexion.getCadenaSQL()))
                {
                    conexionTemp.Open();

                    SqlCommand cmd = new SqlCommand("GuardarProductoPorPromocion", conexionTemp);
                    cmd.Parameters.AddWithValue("promocion", objeto.promocion);
                    cmd.Parameters.AddWithValue("producto", objeto.producto);
                    cmd.Parameters.AddWithValue("fechaInicio", objeto.fechaInicio);
                    cmd.Parameters.AddWithValue("fechaFinal", objeto.fechaFinal);



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

        public bool EliminarPP(PromocionProducto objeto)
        {
            bool respuesta;
            try
            {
                var conexion = new Conexion();
                using (var conexionTemp = new SqlConnection(conexion.getCadenaSQL()))
                {
                    conexionTemp.Open();

                    SqlCommand cmd = new SqlCommand("EliminarPP", conexionTemp);
                    cmd.Parameters.AddWithValue("promocion", objeto.promocion);
                    cmd.Parameters.AddWithValue("producto", objeto.producto);
                    cmd.Parameters.AddWithValue("fechaInicio", objeto.fechaInicio);
                    cmd.Parameters.AddWithValue("fechaFinal", objeto.fechaFinal);
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
