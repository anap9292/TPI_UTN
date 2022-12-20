using System.Data.SqlClient;
using System.Data;
using TPI_UTN.Models;

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
    }
}
