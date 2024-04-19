using IMCModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMC
{
    public partial class Program
    {
        static IPersonasDAL personasDAL = new PersonasDALArchivos();
        static void MostrarPersona()
        {
            List<Persona> lista = personasDAL.ObtenerPersonas();
            foreach (Persona p in lista)
            {
                Console.WriteLine(p.Nombre + ": " + p.imc.Valor + " - " + p.imc.Texto);
            }
        }

        static void BuscarPersona()
        {
            Console.WriteLine("Ingrese nombre para filtrar: ");
            string filtro = Console.ReadLine().Trim();

            List<Persona> lista = personasDAL.FiltrarPersonas(filtro);
            foreach (Persona p in lista)
            {
                Console.WriteLine(p.Nombre + ": " + p.imc.Valor + " - " + p.imc.Texto);
            }

        }

        static void IngresarPersona()
        {
            string nombre;
            string telefono;
            string edad;
            string pesoStr;
            string estaturaStr;

            float peso = default(float);
            float estatura = default(float);

            do
            {
                Console.WriteLine("Ingrese su nombre:");
                nombre = Console.ReadLine();
            } while (nombre.Equals(string.Empty));


            Console.WriteLine("Ingrese su teléfono:");
            telefono = Console.ReadLine();

            Console.WriteLine("Ingrese su edad:");
            edad = Console.ReadLine();

            bool pesoValido = false;
            while (!pesoValido)
            {
                Console.WriteLine("Ingrese su peso (en kilógramos):");
                pesoStr = Console.ReadLine();
                pesoValido = float.TryParse(pesoStr, out peso);
                if (!pesoValido)
                {
                    Console.WriteLine("Por favor introduzca un valor numérico");
                }
            }


            bool estaturaValido = false;
            while (!estaturaValido)
            {
                Console.WriteLine("Ingrese su estatura (en centímetros):");
                estaturaStr = Console.ReadLine();
                estaturaValido = float.TryParse(estaturaStr, out estatura);
                if (!estaturaValido)
                {
                    Console.WriteLine("Por favor introduzca un valor numérico");
                }
            }

            Persona p = new Persona()
            {
                Nombre = nombre,
                Estatura = estatura,
                Peso = peso,
                Edad = uint.Parse(edad),
                Telefono = uint.Parse(telefono),
            };

            /*
            p.Nombre = nombre;
            p.Estatura = estatura;
            p.Peso = peso;
            p.Edad = uint.Parse(edad);
            p.Telefono = uint.Parse(telefono);
            */

            PersonaDALObjetos pDAL = new PersonaDALObjetos();
            p.CalcularIMC();
            pDAL.AgregarPersona(p);
            personasDAL.AgregarPersona(p);

            Console.WriteLine("Su IMC es de {0}", p.imc.Valor);
            Console.WriteLine("Usted se encuentra en el rango de {0}.", p.imc.Texto);
            Console.ReadKey();

            //MostrarImc(p.Peso, p.Estatura);
        }

        static void MostrarImc(float peso, float estatura)
        {
            float imc = Program.CalcularImc(peso, estatura);
            Console.WriteLine("Su IMC es de {0}", imc.ToString());
            Console.WriteLine("Usted se encuentra en el rango de {0}.", Program.GetRangoImc(imc));
            Console.ReadKey();
        }


        static float CalcularImc(float peso, float estatura)
        {
            /* 
             * Formula IMC
             * Peso (kilógramos) / estatura (metros) ^ 2
            */

            estatura /= 100;
            return peso / (estatura * estatura);

        }

        static string GetRangoImc(float imc)
        {
            string rango = "";
            switch (imc)
            {
                case float i when i < 16.0:
                    rango = "Delgadez severa";
                    break;
                case float i when i >= 16.0 && i < 17.0:
                    rango = "Delgadez moderada";
                    break;
                case float i when i >= 17.0 && i < 18.5:
                    rango = "Delgadez aceptable";
                    break;
                case float i when i >= 18.5 && i < 25.0:
                    rango = "Peso normal";
                    break;
                case float i when i >= 25.0 && i < 30.0:
                    rango = "Sobrepeso";
                    break;
                case float i when i >= 30.0 && i < 35.0:
                    rango = "Obesidad tipo I";
                    break;
                case float i when i >= 35.0 && i < 40.0:
                    rango = "Obesidad tipo II";
                    break;
                case float i when i >= 40.0 && i < 50.0:
                    rango = "Obesidad tipo III";
                    break;
                case float i when i >= 50.0:
                    rango = "Obesidad tipo IV";
                    break;
                default:
                    rango = "Rango inválido";
                    break;
            }

            return rango;
        }
    }
}
