using practica2.Models;
using practica2.Datos;
using System.Data.SqlClient;
using System.Data;


namespace practica2.Datos
{
    public class ProductoDatos
    {
        //Acá se definen los métodos CRUD (ABML)
        public List<Producto> Listar()
        {

            /*
             Rl paso a paso es:
            BBDD >> Conexion >> Modelos >> Controladores >> Vistas
             */

            //Recibir informacion
            var oLista = new List<Producto>();

            //Instancia de la conexión
            var conexion = new Conexion();

            //usando using, defiimos el tiempo de vida de la conexion
            using( var conexionTemp = new SqlConnection(conexion.getCadenaSQL()))
            {
                conexionTemp.Open();
                SqlCommand cmd = new SqlCommand("ListarProductos", conexionTemp);
                cmd.CommandType = CommandType.StoredProcedure;
                // comienza la lectura de datos
                using(var lector = cmd.ExecuteReader())
                {
                    //mientras hayan registros
                    while (lector.Read())
                    {
                        oLista.Add(new Producto()
                        {
                            id = Convert.ToInt32(lector["prod_id"]),
                            nombre = Convert.ToString(lector["prod_nombre"]),
                            proveedor = Convert.ToString(lector["proveedor"]),
                            imagen = Convert.ToString(lector["prod_imagen"]),
                            descripcion = Convert.ToString(lector["prod_descripcion"]),
                            precio = Convert.ToDecimal(lector["prod_precio"]),
                            stock = Convert.ToDecimal(lector["prod_stock"])
                        });
                    }
                }
                return oLista;
            }
        }
    

        public Producto Obtener(int idBuscado)
        {
            var oProducto = new Producto();
            var conexion = new Conexion();

            using (var conexionTemp = new SqlConnection(conexion.getCadenaSQL()))
            {
                conexionTemp.Open();

                SqlCommand cmd = new SqlCommand("ObtenerProducto", conexionTemp);
                cmd.Parameters.AddWithValue("id", idBuscado); //busca valores
                cmd.CommandType = CommandType.StoredProcedure;

                using (var lector = cmd.ExecuteReader())
                {
                    while (lector.Read())
                    {
                        oProducto.id = Convert.ToInt32(lector["prod_id"]);
                        oProducto.nombre = Convert.ToString(lector["prod_nombre"]);
                        oProducto.proveedor = Convert.ToString(lector["proveedor"]);
                        oProducto.precio = Convert.ToDecimal(lector["prod_precio"]);
                        oProducto.stock = Convert.ToInt32(lector["prod_stock"]);
                        oProducto.imagen = Convert.ToString(lector["prod_imagen"]);
                        oProducto.descripcion = Convert.ToString(lector["prod_descripcion"]);
                    }
                }
            }
            return oProducto;

        }

        public bool Guardar(Producto oProducto)
        {
            bool respuesta;
            try
            {
                var conexion = new Conexion();
                using (var conexionTemp = new SqlConnection(conexion.getCadenaSQL()))
                {
                    conexionTemp.Open();

                    SqlCommand cmd = new SqlCommand("GuardarProducto", conexionTemp);
                    cmd.Parameters.AddWithValue("nombre", oProducto.nombre);
                    cmd.Parameters.AddWithValue("stock", oProducto.stock);
                    cmd.Parameters.AddWithValue("precio", oProducto.precio);
                    cmd.Parameters.AddWithValue("proveedor", oProducto.proveedor);
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

        public bool Editar(Producto oProducto)
        {
            bool respuesta;
            try
            {
                var conexion = new Conexion();
                using (var conexionTemp = new SqlConnection(conexion.getCadenaSQL()))
                {
                    conexionTemp.Open();

                    SqlCommand cmd = new SqlCommand("EditarProducto", conexionTemp);
                    cmd.Parameters.AddWithValue("id", oProducto.id);
                    cmd.Parameters.AddWithValue("nombre", oProducto.nombre);
                    cmd.Parameters.AddWithValue("stock", oProducto.stock);
                    cmd.Parameters.AddWithValue("precio", oProducto.precio);
                    cmd.Parameters.AddWithValue("proveedor", oProducto.proveedor);
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
