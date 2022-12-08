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

            int opcion = int.Parse(Console.ReadLine());

            switch (opcion)
            {
                case 1: Libro.Add();
                    break;
                case 2: Libro.Delete();
                    break;

            }
        }
    }
}
