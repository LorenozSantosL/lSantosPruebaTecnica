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

            Console.WriteLine("Ingrese el Id del Libro a eliminar: ");
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
            
        }
    }
}
