using practica2.Models;
using practica2.Models.Proveedor;
using practica2.Datos;
using System.Data.SqlClient;
using System.Data;
using System;


namespace practica2.Datos
{
    public class ProveedorDatos
    {
        //Acá se definen los métodos CRUD (ABML)
        public List<Proveedor> Listar()
        {

            /*
             Rl paso a paso es:
            BBDD >> Conexion >> Modelos >> Controladores >> Vistas
             */

            //Recibir informacion
            var oLista = new List<Proveedor>();

            //Instancia de la conexión
            var conexion = new Conexion();

            //usando using, defiimos el tiempo de vida de la conexion
            using( var conexionTemp = new SqlConnection(conexion.getCadenaSQL()))
            {
                conexionTemp.Open();
                SqlCommand cmd = new SqlCommand("ListarProveedores", conexionTemp);
                cmd.CommandType = CommandType.StoredProcedure;
                // comienza la lectura de datos
                using(var lector = cmd.ExecuteReader())
                {
                    //mientras hayan registros
                    while (lector.Read())
                    {
                        oLista.Add(new Proveedor()
                        {
                            id = Convert.ToInt32(lector["prov_id"]),
                            nombre = Convert.ToString(lector["prov_nombre"]),
                            direccion = Convert.ToString(lector["prov_direccion"]),
                            cuit = Convert.ToString(lector["prov_cuit"])
                        });
                    }
                }
                return oLista;
            }
        }
    

        public Proveedor Obtener(int idBuscado)
        {
            var objeto = new Proveedor();
            var conexion = new Conexion();

            using (var conexionTemp = new SqlConnection(conexion.getCadenaSQL()))
            {
                conexionTemp.Open();

                SqlCommand cmd = new SqlCommand("ObtenerProveedor", conexionTemp);
                cmd.Parameters.AddWithValue("id", idBuscado); //busca valores
                cmd.CommandType = CommandType.StoredProcedure;

                using (var lector = cmd.ExecuteReader())
                {
                    while (lector.Read())
                    {
                        objeto.id = Convert.ToInt32(lector["prov_id"]);
                        objeto.nombre = Convert.ToString(lector["prov_nombre"]);
                        objeto.direccion = Convert.ToString(lector["prov_direccion"]);
                        objeto.cuit = Convert.ToString(lector["prov_cuit"]);
                    }
                }
            }
            return objeto;

        }

        public bool Guardar(Proveedor objeto)
        {
            bool respuesta;
            try
            {
                var conexion = new Conexion();
                using (var conexionTemp = new SqlConnection(conexion.getCadenaSQL()))
                {
                    conexionTemp.Open();

                    SqlCommand cmd = new SqlCommand("GuardarProveedor", conexionTemp);
                    cmd.Parameters.AddWithValue("nombre", objeto.nombre);
                    cmd.Parameters.AddWithValue("direccion", objeto.direccion);
                    cmd.Parameters.AddWithValue("cuit", objeto.cuit);

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

        public bool Editar(Proveedor objeto)
        {
            bool respuesta;
            try
            {
                var conexion = new Conexion();
                using (var conexionTemp = new SqlConnection(conexion.getCadenaSQL()))
                {
                    conexionTemp.Open();

                    SqlCommand cmd = new SqlCommand("EditarProveedor", conexionTemp);
                    cmd.Parameters.AddWithValue("id", objeto.id);
                    cmd.Parameters.AddWithValue("nombre", objeto.nombre);
                    cmd.Parameters.AddWithValue("direccion", objeto.direccion);
                    cmd.Parameters.AddWithValue("cuit", objeto.cuit);

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

                    SqlCommand cmd = new SqlCommand("EliminarProveedor", conexionTemp);
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

        public List<Categoria> ListarCategorias(int id)
        {

            /*
             Rl paso a paso es:
            BBDD >> Conexion >> Modelos >> Controladores >> Vistas
             */

            //Recibir informacion
            var oLista = new List<Categoria>();

            //Instancia de la conexión
            var conexion = new Conexion();

            //usando using, defiimos el tiempo de vida de la conexion
            using (var conexionTemp = new SqlConnection(conexion.getCadenaSQL()))
            {
                conexionTemp.Open();
                SqlCommand cmd = new SqlCommand("ListarCategoriasPorProveedor", conexionTemp);
                cmd.Parameters.AddWithValue("id", id); //busca valores
                cmd.CommandType = CommandType.StoredProcedure;
                // comienza la lectura de datos
                using (var lector = cmd.ExecuteReader())
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
                return oLista;
            }
        }

    }

        public bool AgregarCategoria(CategoriaProveedor objeto) 
        {
            bool respuesta;
            try
            {
                var conexion = new Conexion();
                using (var conexionTemp = new SqlConnection(conexion.getCadenaSQL()))
                {
                    conexionTemp.Open();

                    SqlCommand cmd = new SqlCommand("GuardarCategoriaPorProveedor", conexionTemp);
                    cmd.Parameters.AddWithValue("proveedor", objeto.proveedor);
                    cmd.Parameters.AddWithValue("categoria", objeto.categoria.ToUpper());


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

        public bool EliminarCategoria(CategoriaProveedor objeto)
        {
            bool respuesta;
            try
            {
                var conexion = new Conexion();
                using (var conexionTemp = new SqlConnection(conexion.getCadenaSQL()))
                {
                    conexionTemp.Open();

                    SqlCommand cmd = new SqlCommand("EliminarCategoriaProveedor", conexionTemp);
                    cmd.Parameters.AddWithValue("proveedor", objeto.proveedor);
                    cmd.Parameters.AddWithValue("categoria", objeto.categoria);//este solo se usa para encontrar el registro
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
