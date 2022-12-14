using System.Data;
using System.Data.SqlClient;
using TPI_UTN.Models;

namespace TPI_UTN.Datos
{
    public class UsuarioDatos
    {
        /*Procedimiento ListarCliente*/

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
                             usuario_id= Convert.ToInt32(lector["usuario_id"]),
                            user_nombre = Convert.ToString(lector["user_nombre"]),
                            user_contrasena = Convert.ToString(lector["user_contrasena"]),
                            user_tipo = Convert.ToInt32(lector["user_tipo"]),
                        });
                    }
                }

            }

            return oLista;
        }







    }
}
