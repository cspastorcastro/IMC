using IMC;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMCModel
{
    public interface IPersonasDAL
    {
        void AgregarPersona(Persona p);
        List<Persona> ObtenerPersonas();
        List<Persona> FiltrarPersonas(string nombre);
    }
}
