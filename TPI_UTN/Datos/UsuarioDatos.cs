using System.Data;
using System.Data.SqlClient;
using TPI_UTN.Models;

namespace TPI_UTN.Datos
{
    public class UsuarioDatos
    {
        /*Procedimiento Listar login*/

        public List<Usuario> ListarUsuario()
        {
            var oLista = new List<Usuario>();
            var conexion = new Conexion();
            using (var conexionTemp = new SqlConnection(conexion.getCadenaSQL()))
            {
                conexionTemp.Open();
                SqlCommand cmd = new SqlCommand("ListarUsuario", conexionTemp);
                cmd.CommandType = CommandType.StoredProcedure;

                using (var lector = cmd.ExecuteReader())
                {
                    while (lector.Read())
                    {
                        oLista.Add(new Usuario()
                        {
                            usuario_id = Convert.ToInt32(lector["usuario_id"]),
                            user_nombre = Convert.ToString(lector["user_nombre"]),
                            user_contrasena = Convert.ToString(lector["user_contrasena"]),
                            user_tipo = Convert.ToInt32(lector["user_tipo"]),
                            rolAsociado = new TipoUsuario()
                            {
                                tipo_id = Convert.ToInt32(lector["tipo_id"]),
                                tipo_descripcion = Convert.ToString(lector["tipo_descripcion"])
                            }

                        });
                    }
                }

            }

            return oLista;
        }

        /*Obtener Usuario*/
        public Usuario ObtenerUsuario(int usuario_id)
        {
            var oUsuario = new Usuario();
            try
            {
                var conexion = new Conexion();

                using (var conexionTemp = new SqlConnection(conexion.getCadenaSQL()))
                {
                    conexionTemp.Open();
                    SqlCommand cmd = new SqlCommand("ObtenerUsuario", conexionTemp);
                    cmd.Parameters.AddWithValue("usuario_id", usuario_id);
                    cmd.CommandType = CommandType.StoredProcedure;

                    //Realizamos la lectura de los registros
                    using (var lector = cmd.ExecuteReader())
                    {
                        while (lector.Read())
                        {
                            oUsuario.usuario_id = Convert.ToInt32(lector["usuario_id"]);
                            oUsuario.user_nombre = Convert.ToString(lector["user_nombre"]);
                            oUsuario.user_contrasena = Convert.ToString(lector["user_contrasena"]);
                            oUsuario.user_tipo = Convert.ToInt32(lector["user_tipo"]);
                            // oCliente.clie_tipo = Convert.ToInt32(lector["clie_tipo"]);
                        }
                    }
                }
            }
            catch (Exception e)
            {
                string error = e.Message;
                return oUsuario;
            }
            return oUsuario;
        }

        /*Crear nuevo usuario(Guardar)*/
        public bool GuardarUsuario(Usuario oUsuario)
        {
            bool respuesta;
            try
            {
                var conexion = new Conexion();
                using (var conexionTemp = new SqlConnection(conexion.getCadenaSQL()))
                {
                    conexionTemp.Open();
                    SqlCommand cmd = new SqlCommand("GuardarUsuario", conexionTemp);

                    cmd.Parameters.AddWithValue("user_nombre", oUsuario.user_nombre);
                    cmd.Parameters.AddWithValue("user_contrasena", oUsuario.user_contrasena);
                    cmd.Parameters.AddWithValue("user_tipo", oUsuario.user_tipo);



                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.ExecuteNonQuery();
                }
                respuesta = true;
            }
            catch (Exception e)
            {
                string error = e.Message;
                Console.WriteLine(error);
                respuesta = false;
            }
            return respuesta;
        }

        /*Editar Usuario*/
        public bool EditarUsuario(Usuario oUsuario)
        {
            bool respuesta;

            try
            {
                var conexion = new Conexion();
                using (var conexionTemp = new SqlConnection(conexion.getCadenaSQL()))
                {
                    conexionTemp.Open();
                    SqlCommand cmd = new SqlCommand("EditarUsuario", conexionTemp);
                    cmd.Parameters.AddWithValue("usuario_id", oUsuario.usuario_id);

                    cmd.Parameters.AddWithValue("user_nombre", oUsuario.user_nombre);
                    cmd.Parameters.AddWithValue("user_contrasena", oUsuario.user_contrasena);
                    cmd.Parameters.AddWithValue("user_tipo", oUsuario.user_tipo);
                   // cmd.Parameters.AddWithValue("tipo_id", oUsuario.rolAsociado.tipo_id);


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

        /*Eliminar Usuario*/

        public bool EliminarUsuario(int usuario_id)
        {
            bool respuesta;

            try
            {
                var conexion = new Conexion();
                using (var conexionTemp = new SqlConnection(conexion.getCadenaSQL()))
                {
                    conexionTemp.Open();
                    SqlCommand cmd = new SqlCommand("EliminarUsuario", conexionTemp);
                    cmd.Parameters.AddWithValue("usuario_id", usuario_id);
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

        /*----------------------------Login--------------------------------------------*/

        //validar
        public Usuario ValidarUsuario(string user, string pass)
        {
            return ListarUsuario().Where(item => item.user_nombre == user && item.user_contrasena == pass).FirstOrDefault();
        }


        //autenticar

        public Usuario AutenticarUsuario(string user_nombre, string user_contrasena)
        {
            var usuario = new Usuario();
            var conexion = new Conexion();
            try
            {
                using (var conexionTemp = new SqlConnection(conexion.getCadenaSQL()))
                {
                    conexionTemp.Open();
                    SqlCommand cmd = new SqlCommand("AutenticarUsuario", conexionTemp);
                    cmd.Parameters.AddWithValue("user_nombre", user_nombre);
                    cmd.Parameters.AddWithValue("user_contrasena", user_contrasena);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.ExecuteNonQuery();
                    using (var lector = cmd.ExecuteReader())
                    {
                        while (lector.Read())
                        {
                            usuario.usuario_id = Convert.ToInt32(lector["usuario_id"]);
                            usuario.user_nombre = Convert.ToString(lector["user_nombre"]);
                            usuario.user_contrasena = Convert.ToString(lector["user_contrasena"]);
                            usuario.user_tipo = Convert.ToInt32(lector["user_tipo"]);
                            usuario.rolAsociado = new TipoUsuario()
                            {
                                tipo_id = Convert.ToInt32(lector["tipo_id"]),
                                tipo_descripcion = Convert.ToString(lector["tipo_descripcion"])
                            };
                        }
                    }
                }
                return usuario;
            }
            catch
            {
                return null;
            }










        }




        /*Listar Usuario + tabla Tipo (suplanta el Listar comun)*/

        public List<Usuario> ListarUsuarioTipo()
        {
            var oLista = new List<Usuario>();
            var conexion = new Conexion();
            using (var conexionTemp = new SqlConnection(conexion.getCadenaSQL()))
            {
                conexionTemp.Open();
                SqlCommand cmd = new SqlCommand("ListarUsuarioTipo", conexionTemp);
                cmd.CommandType = CommandType.StoredProcedure;

                using (var lector = cmd.ExecuteReader())
                {
                    while (lector.Read())
                    {
                        oLista.Add(new Usuario()
                        {
                            usuario_id = Convert.ToInt32(lector["usuario_id"]),
                            user_nombre = Convert.ToString(lector["user_nombre"]),
                            user_contrasena = Convert.ToString(lector["user_contrasena"]),
                            user_tipo = Convert.ToInt32(lector["user_tipo"]),
                            rolAsociado = new TipoUsuario()
                            {
                                tipo_id = Convert.ToInt32(lector["tipo_id"]),
                                tipo_descripcion = Convert.ToString(lector["tipo_descripcion"])
                            }

                        });
                    }
                }

            }

            return oLista;
        }


        /*Obtener UsuarioTIpo*/
        public Usuario ObtenerUsuarioTipo(int usuario_id)
        {
            var oUsuario = new Usuario();
            try
            {
                var conexion = new Conexion();

                using (var conexionTemp = new SqlConnection(conexion.getCadenaSQL()))
                {
                    conexionTemp.Open();
                    SqlCommand cmd = new SqlCommand("ObtenerUsuarioTipo", conexionTemp);
                    cmd.Parameters.AddWithValue("usuario_id", usuario_id);
                    cmd.CommandType = CommandType.StoredProcedure;

                    //Realizamos la lectura de los registros
                    using (var lector = cmd.ExecuteReader())
                    {
                        while (lector.Read())
                        {
                            oUsuario.usuario_id = Convert.ToInt32(lector["usuario_id"]);
                            oUsuario.user_nombre = Convert.ToString(lector["user_nombre"]);
                            oUsuario.user_contrasena = Convert.ToString(lector["user_contrasena"]);
                            oUsuario.user_tipo = Convert.ToInt32(lector["user_tipo"]);
                            oUsuario.rolAsociado = new TipoUsuario()
                            {
                                tipo_id = Convert.ToInt32(lector["tipo_id"]),
                                tipo_descripcion = Convert.ToString(lector["tipo_descripcion"])
                            };
                        }
                    }
                    }
                }
            catch (Exception e)
            {
                string error = e.Message;
                return oUsuario;
            }
            return oUsuario;
        }


        public Cliente ObtenerClientePorUsuario(int usuario)
        {
            var oUsuario = new Cliente();
            try
            {
                var conexion = new Conexion();

                using (var conexionTemp = new SqlConnection(conexion.getCadenaSQL()))
                {
                    conexionTemp.Open();
                    SqlCommand cmd = new SqlCommand("ObtenerClientePorUsuario", conexionTemp);
                    cmd.Parameters.AddWithValue("id", usuario);
                    cmd.CommandType = CommandType.StoredProcedure;

                    //Realizamos la lectura de los registros
                    using (var lector = cmd.ExecuteReader())
                    {
                        while (lector.Read())
                        {
                            oUsuario.clie_id = Convert.ToInt32(lector["clie_id"]);
                            oUsuario.clie_nombre = Convert.ToString(lector["clie_nombre"]);
                            oUsuario.clie_apellido = Convert.ToString(lector["clie_apellido"]);
                            oUsuario.clie_cuil = Convert.ToString(lector["clie_cuil"]);
                            oUsuario.clie_dni = Convert.ToString(lector["clie_dni"]);
                            oUsuario.clie_razon_social = Convert.ToString(lector["clie_razon_social"]);

                        }
                    }
                }
            }
            catch (Exception e)
            {
                string error = e.Message;
                return oUsuario;
            }
            return oUsuario;
        }





    }
}
