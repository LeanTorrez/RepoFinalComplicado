using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsFinal
{
    // Generar la clase genérico Salón. Contiene el atributo elementos:List del tipo genérico.
    // (este sólo se podrá inicializar en el constructor por defécto, que además será privado)
    // y el atributo capacidad:int (generar un constructor público que lo reciba como parámetro).
    // Sobrecarga en el operador +.
    // Al sumar un Salón con un elemento de tipo Persona, se deberá agregar a la lista de elementos
    // SÓLO si el idioma de la persona es Español y aún hay lugar en el salon.

    //Eventos
    //Agregar en la clase Salón que, si se llego al limite de capacidad, se lance un evento SalonLlenoEvent.
    //Esto mostrará un mensaje en el manejador Salon_SalonLlenoEvent (realizarlo según convenciones).
    //Agregar en la clase Salon que, si el idioma no es español, se lance un evento SalonNoEspañolEvent.
    //Esto mostrará un mensaje en el manejador Salon_SalonNoEspañolEvent (realizarlo según convenciones).
    public class Salon<T> where T : Persona
    {
        public delegate void CapacacidadMaxima(object sender, EventArgs e);
        public event CapacacidadMaxima CapacidadMaximaEvento;

        public delegate void AlumnoNoHablaEspaniol(object sender, EventArgs e);
        public event AlumnoNoHablaEspaniol AlumnoNoHablaEspaniolEvento;

        private List<T> lista;
        private int capacidad;

        private Salon() 
        {
            lista = new List<T>();
        }

        public Salon(int capacidad) : this()
        {
            this.capacidad = capacidad; 
        }

        public static Salon<T> operator +(Salon<T> sa,T p)
        {
            if (sa.lista.Count < sa.capacidad)
            {
                if (p.idioma == EIdioma.Español)
                {
                    sa.lista.Add(p);
                }
                else
                {
                    sa.AlumnoNoHablaEspaniolEvento(sa, EventArgs.Empty);
                }
            }
            else
            {
                sa.CapacidadMaximaEvento(sa, EventArgs.Empty);
            }
            return sa;
        }


    }
}
