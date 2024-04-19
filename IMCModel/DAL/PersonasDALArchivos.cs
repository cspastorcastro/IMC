using IMC;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMCModel
{
    public class PersonasDALArchivos : IPersonasDAL
    {
        private enum CSVIndices
        {
            Nombre,
            Estatura,
            Telefono,
            Peso,
            Edad
        }
        private static string archivo = "personas.txt";
        private static string ruta = Directory.GetCurrentDirectory() + "/" + archivo;

        public void AgregarPersona(Persona p)
        {
            /*
                1. Crear streamwritter
                2. Agregar línea al archivo
                3. Cerrar streamwritter
            */
            try
            {
                using (StreamWriter writer = new StreamWriter(ruta, true))
                {
                    string texto = p.Nombre + ","
                                 + p.Estatura + ","
                                 + p.Telefono + ","
                                 + p.Peso + ","
                                 + p.Edad;
                writer.WriteLine(texto);
                writer.Flush();
                }
            } catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
        }

        public List<Persona> FiltrarPersonas(string nombre)
        {
            throw new NotImplementedException();
        }

        public List<Persona> ObtenerPersonas()
        {
            List<Persona> personas = new List<Persona>();
            using(StreamReader reader = new StreamReader(ruta))
            {
                string texto;
                do
                {
                    texto = reader.ReadLine();
                    string[] textoArchivo = texto.Trim().Split(',');
                    string nombre = textoArchivo[(int)CSVIndices.Nombre];
                    float estatura = float.Parse(textoArchivo[(int)CSVIndices.Estatura]);
                    uint telefono = Convert.ToUInt32(textoArchivo[(int)CSVIndices.Telefono]);
                    float peso = float.Parse(textoArchivo[(int)CSVIndices.Peso]);
                    uint edad = Convert.ToUInt32(textoArchivo[(int)CSVIndices.Edad]);

                    Persona p = new Persona()
                    {
                        Nombre = nombre,
                        Estatura = estatura,
                        Peso = peso,
                        Edad = edad,
                        Telefono = telefono,
                    };

                    p.CalcularIMC();
                    personas.Add(p);

                } while (texto != null);

            }
            return personas;
        }
    }
}
