using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PL
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Ingrese una opcion");
            Console.WriteLine("Add: 1");
            Console.WriteLine("Delete: 2");
            Console.WriteLine("Update: 3");
            Console.WriteLine("GetAll: 4");
            Console.WriteLine("GetById: 5");
            Console.Write("Opción: ");

            int opcion = int.Parse(Console.ReadLine());

            switch (opcion)
            {
                case 1: 
                    
                    Libro.Add();
                    break;
                case 2: Libro.Delete();
                    break;
                case 3: Libro.Update();
                    break;
                case 4:
                    Console.WriteLine("------------------------------------------");
                    Libro.GetAll();
                    break;
                case 5:
                    Console.WriteLine("----------------------------------------------");
                    Libro.GetById();
                    break;

                default: Console.WriteLine("La opción es incorrecta");
                    break;

            }
        }
    }
}
