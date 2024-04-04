using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMC
{
    public partial class Program
    {   
        static void Main(string[] args)
        {
            while(Menu())
            Console.ReadKey();
        }

        static bool Menu()
        {
            bool continuar = true;
            Console.WriteLine("1. Ingresar");
            Console.WriteLine("2. Mostrar");
            Console.WriteLine("3. Buscar");
            Console.WriteLine("q. Salir");

            switch(Console.ReadLine().Trim())
            {
                case "1": IngresarPersona();
                    break;
                case "2": MostrarPersona();
                    break;
                case "3": BuscarPersona();
                    break;
                case "q": continuar = false;
                    break;
                default: Console.WriteLine("Opción inválida");
                    break;
            }

            return continuar;
        }
    }
}
