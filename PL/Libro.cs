using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PL
{
    public class Libro
    {
        public static void Add()
        {
           ML.Libro libro = new ML.Libro();
            Console.Write("Ingrese el Nombre del libro: ");
            libro.Nombre = Console.ReadLine();
            Console.Write("Ingrese el Autor: ");
            libro.Autor = new ML.Autor();
            libro.Autor.IdAutor= int.Parse(Console.ReadLine());
            Console.Write("Ingrese Numero de Paginas: ");
            libro.NumeroPaginas = int.Parse(Console.ReadLine());
            Console.Write("Ingrese Fecha de publicacion(dd-mm-yyyy): ");
            libro.FechaPublicacion= Console.ReadLine();
            Console.Write("Ingrese Editorial: ");
            libro.Editorial = new ML.Editorial();
            libro.Editorial.IdEditorial= int.Parse(Console.ReadLine());
            Console.Write("Ingrese Edicion: ");
            libro.Edicion = Console.ReadLine();
            Console.Write("Ingrese el Genero: ");
            libro.Genero = new ML.Genero();
            libro.Genero.IdGenero = int.Parse(Console.ReadLine());

            ML.Result result = BL.Libro.Add(libro);


            if (result.Correct)
            {
                Console.WriteLine(result.Message);
            }
            else
            {
                Console.WriteLine(result.Message);
            }
        }

        public static void Delete()
        {
            Console.WriteLine("Ingrese el Id del Libro a eliminar: ");
            int IdLinbro = int.Parse(Console.ReadLine());

            ML.Result result = BL.Libro.Delete(IdLinbro);

            if (result.Correct)
            {
                Console.WriteLine("Se ha elimiminado el libro ");
            }
        }

        public static void Update()
        {
            ML.Libro libro = new ML.Libro();

            Console.WriteLine("Ingrese el Id del Libro a editar: ");
            libro.IdLibro = int.Parse(Console.ReadLine());

            Console.Write("Ingrese el Nombre del libro: ");
            libro.Nombre = Console.ReadLine();
            Console.Write("Ingrese el Autor: ");
            libro.Autor = new ML.Autor();
            libro.Autor.IdAutor = int.Parse(Console.ReadLine());
            Console.Write("Ingrese Numero de Paginas: ");
            libro.NumeroPaginas = int.Parse(Console.ReadLine());
            Console.Write("Ingrese Fecha de publicacion: ");
            libro.FechaPublicacion = Console.ReadLine();
            Console.Write("Ingrese Editorial: ");
            libro.Editorial = new ML.Editorial();
            libro.Editorial.IdEditorial = int.Parse(Console.ReadLine());
            Console.Write("Ingrese Edicion: ");
            libro.Edicion = Console.ReadLine();
            Console.Write("Ingrese el Genero: ");
            libro.Genero = new ML.Genero();
            libro.Genero.IdGenero = int.Parse(Console.ReadLine());


            ML.Result result = BL.Libro.Update(libro);

            if (result.Correct)
            {
                Console.WriteLine(result.Message);
            }
            else
            {
                Console.WriteLine(result.Message);
            }
            
        }


        public static void GetAll()
        {
            ML.Result result = BL.Libro.GetAll();

            if (result.Correct)
            {
                foreach(ML.Libro libro in result.Objects)
                {
                    Console.WriteLine("Id de Libro: " + libro.IdLibro);
                    Console.WriteLine("Nombre Libro: " + libro.Nombre);
                    Console.WriteLine("Id Autor: " + libro.Autor.IdAutor);
                    Console.WriteLine("Nombre Autor: " + libro.Autor.NombreAutor);
                    Console.WriteLine("Número de páginas: " + libro.NumeroPaginas);
                    Console.WriteLine("Fecha de publicación: " + libro.FechaPublicacion);
                    Console.WriteLine("Id de Editorial: " + libro.Editorial.IdEditorial);
                    Console.WriteLine("Nombre de Editorial: " + libro.Editorial.Nombre);
                    Console.WriteLine("Edición: " + libro.Edicion);
                    Console.WriteLine("id de Género: " + libro.Genero.IdGenero);
                    Console.WriteLine("Nombre del Género: "+libro.Genero.Nombre);


                    Console.WriteLine("--------------------------------------------------------------");



                }
                Console.WriteLine("Presione una tecla para teminar el programa");
                Console.ReadKey();
            }
            else
            {
                Console.WriteLine(result.Message);
            }
        }

        public static void GetById()
        {
            Console.Write("Ingrese el Id de Libro a consultar: ");
            int IdLibro = int.Parse(Console.ReadLine());

            ML.Result result = BL.Libro.GetById(IdLibro);

            if(result.Correct)
            {
                ML.Libro libro = new ML.Libro();
                libro = (ML.Libro)result.Object;

                Console.WriteLine("Id de Libro: " + libro.IdLibro);
                Console.WriteLine("Nombre Libro: " + libro.Nombre);
                Console.WriteLine("Id Autor: " + libro.Autor.IdAutor);
                Console.WriteLine("Nombre Autor: " + libro.Autor.NombreAutor);
                Console.WriteLine("Número de páginas: " + libro.NumeroPaginas);
                Console.WriteLine("Fecha de publicación: " + libro.FechaPublicacion);
                Console.WriteLine("Id de Editorial: " + libro.Editorial.IdEditorial);
                Console.WriteLine("Nombre de Editorial: " + libro.Editorial.Nombre);
                Console.WriteLine("Edición: " + libro.Edicion);
                Console.WriteLine("id de Género: " + libro.Genero.IdGenero);
                Console.WriteLine("Nombre del Género: " + libro.Genero.Nombre);


                Console.WriteLine("--------------------------------------------------------------");
                Console.WriteLine("Presione una tecla para teminar el programa");
                Console.ReadKey();
            }
            else
            {
                Console.WriteLine(result.Message);
            }
        }
    }
}
