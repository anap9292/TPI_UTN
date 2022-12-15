using System.Data;
using System.Data.SqlClient;
using TPI_UTN.Models;

namespace TPI_UTN.Datos
{
    public class ClienteDatos
    {
        /*Procedimiento ListarCliente*/

        public List<Cliente> ListarCliente()
        {
            var oLista = new List<Cliente>();
            var conexion = new Conexion();
            using (var conexionTemp = new SqlConnection(conexion.getCadenaSQL()))
            {
                conexionTemp.Open();
                SqlCommand cmd = new SqlCommand("ListarCliente", conexionTemp);
                cmd.CommandType = CommandType.StoredProcedure;

                using (var lector = cmd.ExecuteReader())
                {
                    while (lector.Read())
                    {
                        oLista.Add(new Cliente()
                        {
                            clie_id = Convert.ToInt32(lector["clie_id"]),
                            clie_nombre = Convert.ToString(lector["clie_nombre"]),
                            clie_apellido = Convert.ToString(lector["clie_apellido"]),
                            clie_cuil = Convert.ToString(lector["clie_cuil"]),
                            clie_dni = Convert.ToString(lector["clie_dni"]),
                            clie_razon_social = Convert.ToString(lector["clie_razon_social"]),
                            clie_user = Convert.ToInt32(lector["clie_user"]),
                            clie_tipo = Convert.ToInt32(lector["clie_tipo"]),
                        });
                    }
                }

            }

            return oLista;
        }

        /*Obtener Cliente*/
        public Cliente ObtenerCliente(int clie_id)
        {
            var oCliente = new Cliente();
            try
            {
                var conexion = new Conexion();

                using (var conexionTemp = new SqlConnection(conexion.getCadenaSQL()))
                {
                    conexionTemp.Open();
                    SqlCommand cmd = new SqlCommand("ObtenerCliente", conexionTemp);
                    cmd.Parameters.AddWithValue("clie_id", clie_id);
                    cmd.CommandType = CommandType.StoredProcedure;

                    //Realizamos la lectura de los registros
                    using (var lector = cmd.ExecuteReader())
                    {
                        while (lector.Read())
                        {
                            oCliente.clie_id = Convert.ToInt32(lector["clie_id"]);
                            oCliente.clie_nombre = Convert.ToString(lector["clie_nombre"]);
                            oCliente.clie_apellido = Convert.ToString(lector["clie_apellido"]);
                            oCliente.clie_cuil = Convert.ToString(lector["clie_cuil"]);
                            oCliente.clie_dni = Convert.ToString(lector["clie_dni"]);
                            oCliente.clie_razon_social = Convert.ToString(lector["clie_razon_social"]);
                            oCliente.clie_user = Convert.ToInt32(lector["clie_user"]);
                            oCliente.clie_tipo = Convert.ToInt32(lector["clie_tipo"]);
                        }
                    }
                }
            }
            catch (Exception e)
            {
                string error = e.Message;
                return oCliente;
            }
            return oCliente;
        }


        /*Guardar cliente*/
        public bool GuardarCliente(Cliente oCliente)
        {
            bool respuesta;
            try
            {
                var conexion = new Conexion();
                using (var conexionTemp = new SqlConnection(conexion.getCadenaSQL()))
                {
                    conexionTemp.Open();
                    SqlCommand cmd = new SqlCommand("GuardarCliente", conexionTemp);

                    cmd.Parameters.AddWithValue("clie_nombre", oCliente.clie_nombre);
                    cmd.Parameters.AddWithValue("clie_apellido", oCliente.clie_apellido);
                    cmd.Parameters.AddWithValue("clie_cuil", oCliente.clie_cuil);
                    cmd.Parameters.AddWithValue("clie_dni", oCliente.clie_dni);
                    cmd.Parameters.AddWithValue("clie_razon_Social", oCliente.clie_razon_social);
                    cmd.Parameters.AddWithValue("clie_user", oCliente.clie_user);
                    cmd.Parameters.AddWithValue("clie_tipo", oCliente.clie_tipo);


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


        /*Editar Cliente*/
        public bool EditarCliente(Cliente oCliente)
        {
            bool respuesta;

            try
            {
                var conexion = new Conexion();
                using (var conexionTemp = new SqlConnection(conexion.getCadenaSQL()))
                {
                    conexionTemp.Open();
                    SqlCommand cmd = new SqlCommand("EditarCliente", conexionTemp);
                    cmd.Parameters.AddWithValue("clie_id", oCliente.clie_id);

                    cmd.Parameters.AddWithValue("clie_nombre", oCliente.clie_nombre);
                    cmd.Parameters.AddWithValue("clie_apellido", oCliente.clie_apellido);
                    cmd.Parameters.AddWithValue("clie_cuil", oCliente.clie_cuil);
                    cmd.Parameters.AddWithValue("clie_dni", oCliente.clie_dni);
                    cmd.Parameters.AddWithValue("clie_razon_Social", oCliente.clie_razon_social);
                    cmd.Parameters.AddWithValue("clie_user", oCliente.clie_user);
                    cmd.Parameters.AddWithValue("clie_tipo", oCliente.clie_tipo);

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

        /*Eliminar Cliente*/
        public bool EliminarCliente(int clie_id)
        {
            bool respuesta;

            try
            {
                var conexion = new Conexion();
                using (var conexionTemp = new SqlConnection(conexion.getCadenaSQL()))
                {
                    conexionTemp.Open();
                    SqlCommand cmd = new SqlCommand("EliminarCliente", conexionTemp);
                    cmd.Parameters.AddWithValue("clie_id", clie_id);
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
