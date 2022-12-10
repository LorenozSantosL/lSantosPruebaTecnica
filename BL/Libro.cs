using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace BL
{
    public class Libro
    {
        public static ML.Result Add(ML.Libro libro)
        {
            ML.Result result = new ML.Result();

            try
            {
                using (SqlConnection context = new SqlConnection(DL.Conexion.GetConexion()))
                {
                    var query = "AddLibro";

                    using(SqlCommand cmd = context.CreateCommand())
                    {
                        cmd.Connection = context;
                        cmd.CommandText = query;
                        cmd.CommandType = System.Data.CommandType.StoredProcedure;

                        context.Open();

                        SqlParameter [] collection = new SqlParameter[7];

                        collection[0] = new SqlParameter("Nombre", SqlDbType.VarChar);
                        collection[0].Value = libro.Nombre;

                        collection[1] = new SqlParameter("IdAutor", SqlDbType.Int);
                        collection[1].Value = libro.Autor.IdAutor;

                        collection[2] = new SqlParameter("NumeroPaginas", SqlDbType.Int);
                        collection[2].Value = libro.NumeroPaginas;

                        collection[3] = new SqlParameter("FechaPublicacion", SqlDbType.VarChar);
                        collection[3].Value = libro.FechaPublicacion;

                        collection[4] = new SqlParameter("IdEditorial", SqlDbType.Int);
                        collection[4].Value = libro.Editorial.IdEditorial;

                        collection[5] = new SqlParameter("Edicion", SqlDbType.VarChar);
                        collection[5].Value = libro.Edicion;

                        collection[6] = new SqlParameter("IdGenero", SqlDbType.Int);
                        collection[6].Value = libro.Genero.IdGenero;

                        cmd.Parameters.AddRange(collection);

                       

                        int rowsAffected = cmd.ExecuteNonQuery();

                        if(rowsAffected > 0)
                        {
                            result.Correct = true;
                            result.Message = " Se ha aagregado el libro";
                        }

                    }
                }

            }
            catch (Exception ex)
            {
                result.Correct = false;
                result.Ex = ex;
                result.Message = "Error: " + result.Ex;
            }

            return result;
        }


        public static ML.Result Update(ML.Libro libro)
        {
            ML.Result result = new ML.Result();

            try
            {
                using(SqlConnection context = new SqlConnection(DL.Conexion.GetConexion()))
                {
                    var query = "UpdateLibro";

                    using (SqlCommand cmd = new SqlCommand())
                    {
                        cmd.Connection = context;
                        cmd.CommandText = query;
                        cmd.CommandType = CommandType.StoredProcedure;

                        context.Open();
                         
                        SqlParameter[] collection = new SqlParameter[8];

                        collection[0] = new SqlParameter("IdLibro", SqlDbType.Int);
                        collection[0].Value = libro.IdLibro;

                        collection[1] = new SqlParameter("Nombre", SqlDbType.VarChar);
                        collection[1].Value = libro.Nombre;


                        collection[2] = new SqlParameter("IdAutor", SqlDbType.Int);
                        collection[2].Value = libro.Autor.IdAutor;

                        collection[3] = new SqlParameter("NumeroPaginas", SqlDbType.Int);
                        collection[3].Value = libro.NumeroPaginas;

                        collection[4] = new SqlParameter("FechaPublicacion", SqlDbType.VarChar);
                        collection[4].Value = libro.FechaPublicacion;

                        collection[5] = new SqlParameter("IdEditorial", SqlDbType.Int);
                        collection[5].Value = libro.Editorial.IdEditorial;

                        collection[6] = new SqlParameter("Edicion", SqlDbType.VarChar);
                        collection[6].Value = libro.Edicion;

                        collection[7] = new SqlParameter("IdGenero", SqlDbType.Int);
                        collection[7].Value = libro.Genero.IdGenero;

                        cmd.Parameters.AddRange(collection);

                        int rowsAffected = cmd.ExecuteNonQuery();

                        if(rowsAffected > 0)
                        {
                            result.Correct = true;
                            result.Message = "Se ha actualizado el libro";
                        }

                    }
                }
            }
            catch(Exception ex)
            {
                result.Correct = false;
                result.Ex = ex;
                result.Message = "Error: " + result.Ex;
            }

            return result;
        }

        public static ML.Result Delete(int IdLibro)
        {
            ML.Result result = new ML.Result();

            try
            {
                using(SqlConnection context = new SqlConnection(DL.Conexion.GetConexion()))
                {
                    var query = "DeleteLibro";

                    using(SqlCommand cmd = context.CreateCommand())
                    {
                        cmd.Connection = context;
                        cmd.CommandText = query;
                        cmd.CommandType = CommandType.StoredProcedure;


                        context.Open();

                        SqlParameter[] collection = new SqlParameter[1];

                        collection[0] = new SqlParameter("IdLibro", SqlDbType.Int);
                        collection[0].Value = IdLibro;

                        cmd.Parameters.AddRange(collection);

                        int rowsAffected = cmd.ExecuteNonQuery();

                        if(rowsAffected > 0)
                        {
                            result.Correct = true;
                            result.Message = " Se ha Elimiado el libro";
                        }
                    }
                }
            }
            catch(Exception ex)
            {
                result.Correct = false;
                result.Ex = ex;
                result.Message = "Error: " + result.Ex;
            }

            return result;
        }

        public static ML.Result GetAll()
        {
            ML.Result result = new ML.Result();
            try
            {
                using(SqlConnection context = new SqlConnection(DL.Conexion.GetConexion()))
                {
                    var query = "LibroGetAll";

                    using(SqlCommand cmd = new SqlCommand())
                    {
                        cmd.Connection=context;
                        cmd.CommandText = query;
                        cmd.CommandType = CommandType.StoredProcedure;

                        context.Open();

                        DataTable libroTable = new DataTable();

                        SqlDataAdapter sqldataAdapter = new SqlDataAdapter(cmd);

                        sqldataAdapter.Fill(libroTable);

                        if(libroTable.Rows.Count > 0)
                        {
                            result.Objects = new List<object>();


                            foreach(DataRow row in libroTable.Rows)
                            {
                                ML.Libro libro = new ML.Libro();

                                libro.IdLibro = int.Parse(row[0].ToString());
                                libro.Nombre = row[1].ToString();

                                libro.Autor = new ML.Autor();
                                libro.Autor.IdAutor = int.Parse(row[2].ToString());
                                libro.Autor.NombreAutor = row[3].ToString();

                                libro.NumeroPaginas = int.Parse(row[4].ToString());
                                libro.FechaPublicacion = row[5].ToString();

                                libro.Editorial = new ML.Editorial();
                                libro.Editorial.IdEditorial = int.Parse(row[6].ToString());
                                libro.Editorial.Nombre = row[7].ToString();

                                libro.Edicion = row[8].ToString();

                                libro.Genero = new ML.Genero();
                                libro.Genero.IdGenero = int.Parse(row[9].ToString());
                                libro.Genero.Nombre = row[10].ToString();


                                result.Objects.Add(libro);

                            }
                        }


                    }
                }
                result.Correct = true;
            }
            catch(Exception ex)
            {
                result.Correct = false;
                result.Ex = ex;
                result.Message = "Error:  " + result.Message;
            }

            return result;
        }

        public static ML.Result GetById(int IdLibro)
        {
            ML.Result result = new ML.Result();

            try
            {
                using (SqlConnection context = new SqlConnection(DL.Conexion.GetConexion()))
                {
                    var query = "LibroGetById";

                    using(SqlCommand cmd = new SqlCommand())
                    {
                        cmd.Connection = context;
                        cmd.CommandText = query;
                        cmd.CommandType = CommandType.StoredProcedure;

                        context.Open();

                        SqlParameter[] collection = new SqlParameter[1];

                        collection[0] = new SqlParameter("IdLibro", SqlDbType.Int);
                        collection[0].Value = IdLibro;

                        cmd.Parameters.AddRange(collection);

                        DataTable tableLibro = new DataTable();

                        SqlDataAdapter sqldataAdapter = new SqlDataAdapter(cmd);

                        sqldataAdapter.Fill(tableLibro);

                        if(tableLibro.Rows.Count > 0)
                        {
                            DataRow row = tableLibro.Rows[0];

                            ML.Libro libro = new ML.Libro();

                            libro.IdLibro = int.Parse(row[0].ToString());
                            libro.Nombre = row[1].ToString();

                            libro.Autor = new ML.Autor();
                            libro.Autor.IdAutor = int.Parse(row[2].ToString());
                            libro.Autor.NombreAutor = row[3].ToString();

                            libro.NumeroPaginas = int.Parse(row[4].ToString());
                            libro.FechaPublicacion = row[5].ToString();

                            libro.Editorial = new ML.Editorial();
                            libro.Editorial.IdEditorial = int.Parse(row[6].ToString());
                            libro.Editorial.Nombre = row[7].ToString();

                            libro.Edicion = row[8].ToString();

                            libro.Genero = new ML.Genero();
                            libro.Genero.IdGenero = int.Parse(row[9].ToString());
                            libro.Genero.Nombre = row[10].ToString();

                            result.Object = libro;

                        }
                    }
                }
                result.Correct = true;
            }
            catch (Exception ex)
            {
                result.Correct = false;
                result.Ex = ex;
                result.Message = "Error:  " + result.Message;
            }

            return result;
        }
    }
}
