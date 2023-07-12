using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsFinal
{
    public class Alumno : Persona
    {
        public short legajo;
        public ENivelDeEstudio nivel;
        public Alumno(Persona p, short legajo, ENivelDeEstudio nivel) : base(p.nombre,p.apellido,p.idioma,p.edad)
        {
            this.legajo = legajo;
            this.nivel = nivel;
        }
        public override string ToString()
        {
            return base.ToString() + $" Legajo {this.legajo} Nivel {this.nivel}";
        }

    }
}
