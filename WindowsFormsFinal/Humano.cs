

namespace WindowsFormsFinal
{
    public class Humano
    {
        public string nombre;
        public EIdioma idioma;

        public Humano(string nombre, EIdioma idioma)
        {
            this.nombre = nombre;
            this.idioma = idioma;
        }

        public override string ToString()
        {
            return $"Nombre: {this.nombre} Idioma {this.idioma} ";
        }
    }
}