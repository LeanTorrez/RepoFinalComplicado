using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsFinal
{
    public class Persona : Humano
    {
        public string apellido;
        public int edad;

        public Persona(string nombre,string apellido, EIdioma idioma,int edad) : base(nombre,idioma)
        {
            this.apellido = apellido;
            this.edad = edad;
        }

        public override string ToString()
        {
            return  base.ToString() + $" Apellido {this.apellido} Edad {this.edad}";
        }


    }
}
