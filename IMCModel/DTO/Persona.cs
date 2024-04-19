using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMC
{
    public struct IMC
    {
        public double Valor { get; set; }
        public string Texto
        {
            get
            {
                switch (Valor)
                {
                    case double i when i < 16.0:
                        return "Delgadez severa";
                    case double i when i >= 16.0 && i < 17.0:
                        return "Delgadez moderada";
                    case double i when i >= 17.0 && i < 18.5:
                        return "Delgadez aceptable";
                    case double i when i >= 18.5 && i < 25.0:
                        return "Peso normal";
                    case double i when i >= 25.0 && i < 30.0:
                        return "Sobrepeso";
                    case double i when i >= 30.0 && i < 35.0:
                        return "Obesidad tipo I";
                    case double i when i >= 35.0 && i < 40.0:
                        return "Obesidad tipo II";
                    case double i when i >= 40.0 && i < 50.0:
                        return "Obesidad tipo III";
                    case double i when i >= 50.0:
                        return "Obesidad tipo IV";
                    default:
                        return "Rango inválido";
                }
            }
        }
    }
    public class Persona
    {

        public uint Edad {  get; set; }
        public uint Telefono {  get; set; }
        public float Peso { get; set; }
        public float Estatura { get; set; }
        public string Nombre { get; set; }
        public IMC imc;


        public void CalcularIMC()
        {
            float estaturaEnMetros = Estatura / 100;
            double valor = Peso / (estaturaEnMetros * estaturaEnMetros);
            this.imc = new IMC() { Valor = valor };
        }

        public IMC IMC
        {
            get
            {
                return this.IMC;
            }
        }

        public override string ToString()
        {
            return Nombre + "" + IMC.Texto;
        }

    }
}
