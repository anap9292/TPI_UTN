using TPI_UTN.Models.Proveedor;
using System.Data.SqlClient;
using System.Data;
using TPI_UTN.Models;

namespace TPI_UTN.Datos
{
    public class CategoriaDatos
    {
        public List<Categoria> Listar()
        {

            //Recibir informacion
            var oLista = new List<Categoria>();

            //Instancia de la conexión
            var conexion = new Conexion();

            //usando using, defiimos el tiempo de vida de la conexion
            using( var conexionTemp = new SqlConnection(conexion.getCadenaSQL()))
            {
                conexionTemp.Open();
                SqlCommand cmd = new SqlCommand("ListarCategoria", conexionTemp);
                cmd.CommandType = CommandType.StoredProcedure;
                // comienza la lectura de datos
                using(var lector = cmd.ExecuteReader())
                {
                    //mientras hayan registros
                    while (lector.Read())
                    {
                        oLista.Add(new Categoria()
                        {
                            id = Convert.ToInt32(lector["cate_id"]),
                            nombre = Convert.ToString(lector["cate_nombre"])
                        });
                    }
                }
                return oLista;
            
            }
        }

        public Categoria Obtener(int idBuscado)
        {
            var oCategoria = new Categoria();
            var conexion = new Conexion();

            using (var conexionTemp = new SqlConnection(conexion.getCadenaSQL()))
            {
                conexionTemp.Open();

                SqlCommand cmd = new SqlCommand("ObtenerCategoria", conexionTemp);
                cmd.Parameters.AddWithValue("id", idBuscado); //busca valores
                cmd.CommandType = CommandType.StoredProcedure;

                using (var lector = cmd.ExecuteReader())
                {
                    while (lector.Read())
                    {
                        oCategoria.id = Convert.ToInt32(lector["cate_id"]);
                        oCategoria.nombre = Convert.ToString(lector["cate_nombre"]);
                    }
                }
            }
            return oCategoria;

        }

        public bool Guardar(Categoria objeto)
        {
            bool respuesta;
            try
            {
                var conexion = new Conexion();
                using (var conexionTemp = new SqlConnection(conexion.getCadenaSQL()))
                {
                    conexionTemp.Open();

                    SqlCommand cmd = new SqlCommand("GuardarCategoria", conexionTemp);
                    cmd.Parameters.AddWithValue("nombre", objeto.nombre);

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

        public bool Editar(Categoria objeto)
        {
            bool respuesta;
            try
            {
                var conexion = new Conexion();
                using (var conexionTemp = new SqlConnection(conexion.getCadenaSQL()))
                {
                    conexionTemp.Open();

                    SqlCommand cmd = new SqlCommand("EditarCategoria", conexionTemp);
                    cmd.Parameters.AddWithValue("id", objeto.id);
                    cmd.Parameters.AddWithValue("nombre", objeto.nombre);

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

                    SqlCommand cmd = new SqlCommand("EliminarCategoria", conexionTemp);
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
