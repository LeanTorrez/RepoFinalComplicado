using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsFinal
{
    public interface IDeserializar
    {
        bool Xml(string ruta, out AlumnoEgresado a);
    }
}
