using System.Data;
using System.Data.SqlClient;
using TPI_UTN.Models;



namespace TPI_UTN.Datos
{
    public class EmpleadoDatos
    {
        /*Procedimiento Listar Empleado*/


        public List<Empleado> ListarEmpleado()
        {
            var oLista = new List<Empleado>();
            var conexion = new Conexion();
            using (var conexionTemp = new SqlConnection(conexion.getCadenaSQL()))
            {
                conexionTemp.Open();
                SqlCommand cmd = new SqlCommand("ListarEmpleado", conexionTemp);
                cmd.CommandType = CommandType.StoredProcedure;

                using (var lector = cmd.ExecuteReader())
                {
                    while (lector.Read())
                    {
                        oLista.Add(new Empleado()
                        {
                            empl_id = Convert.ToInt32(lector["empl_id"]),
                            empl_nombre = Convert.ToString(lector["empl_nombre"]),
                            empl_apellido = Convert.ToString(lector["empl_apellido"]),
                           empl_supervisor_id = Convert.ToInt32(lector["empl_supervisor_id"]),
                            empl_user = Convert.ToInt32(lector["empl_user"])

                        });
                    }
                }

            }

            return oLista;
        }

        /*Procedimiento Obtener Empleado*/

        public Empleado ObtenerEmpleado(int empl_id)
        {
            var oEmpleado = new Empleado();
            try
            {
                var conexion = new Conexion();

                using (var conexionTemp = new SqlConnection(conexion.getCadenaSQL()))
                {
                    conexionTemp.Open();
                    SqlCommand cmd = new SqlCommand("ObtenerEmpleado", conexionTemp);
                    cmd.Parameters.AddWithValue("empl_id", empl_id);
                    cmd.CommandType = CommandType.StoredProcedure;

                    //Realizamos la lectura de los registros
                    using (var lector = cmd.ExecuteReader())
                    {
                        while (lector.Read())
                        {
                            oEmpleado.empl_id = Convert.ToInt32(lector["empl_id"]);
                            oEmpleado.empl_nombre = Convert.ToString(lector["empl_nombre"]);
                            oEmpleado.empl_apellido = Convert.ToString(lector["empl_apellido"]);
                            oEmpleado.empl_supervisor_id = Convert.ToInt32(lector["empl_supervisor_id"]);
                            oEmpleado.empl_user = Convert.ToInt32(lector["empl_user"]);
                            
                        }
                    }
                }
            }
            catch (Exception e)
            {
                string error = e.Message;
                return oEmpleado;
            }
            return oEmpleado;
        }

        /*Nuevo Empleado*/
        public bool GuardarEmpleado(Empleado oEmpleado)
        {
            bool respuesta;
            try
            {
                var conexion = new Conexion();
                using (var conexionTemp = new SqlConnection(conexion.getCadenaSQL()))
                {
                    conexionTemp.Open();
                    SqlCommand cmd = new SqlCommand("GuardarEmpleado", conexionTemp);

                    cmd.Parameters.AddWithValue("empl_nombre", oEmpleado.empl_nombre);
                    cmd.Parameters.AddWithValue("empl_apellido", oEmpleado.empl_apellido);
                    cmd.Parameters.AddWithValue("empl_supervisor_id", oEmpleado.empl_supervisor_id);
                    cmd.Parameters.AddWithValue("empl_user", oEmpleado.empl_user);
                    
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

        /*Editar Empleado*/

        public bool EditarEmpleado(Empleado oEmpleado)
        {
            bool respuesta;

            try
            {
                var conexion = new Conexion();
                using (var conexionTemp = new SqlConnection(conexion.getCadenaSQL()))
                {
                    conexionTemp.Open();
                    SqlCommand cmd = new SqlCommand("EditarEmpleado", conexionTemp);
                    cmd.Parameters.AddWithValue("empl_id", oEmpleado.empl_id);

                    cmd.Parameters.AddWithValue("empl_nombre", oEmpleado.empl_nombre);
                    cmd.Parameters.AddWithValue("empl_apellido", oEmpleado.empl_apellido);
                    cmd.Parameters.AddWithValue("empl_supervisor_id", oEmpleado.empl_supervisor_id);
                    cmd.Parameters.AddWithValue("empl_user", oEmpleado.empl_user);
                   
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


        /*Eliminar Empleado*/

        public bool EliminarEmpleado(int empl_id)
        {
            bool respuesta;

            try
            {
                var conexion = new Conexion();
                using (var conexionTemp = new SqlConnection(conexion.getCadenaSQL()))
                {
                    conexionTemp.Open();
                    SqlCommand cmd = new SqlCommand("EliminarEmpleado", conexionTemp);
                    cmd.Parameters.AddWithValue("empl_id", empl_id);
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
