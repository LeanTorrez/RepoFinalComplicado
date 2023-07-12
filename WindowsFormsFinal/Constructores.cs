using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Forms;

namespace WindowsFormsFinal
{
    public class Constructores
    {
        private static string deClase;
        private string deInstancia;
        private string deInstanciaDos;

        public string DeInstancia
        {
            get {
                MessageBox.Show("pase por una propiedad de sólo lectura");

                return deInstancia; }
        }

        public string DeInstanciaDos
        {
            set {
                MessageBox.Show("pase por una propiedad de sólo escritura.");

                deInstanciaDos = value; }
        }
        static Constructores()
        {
            Constructores.deClase = "De Clase";

            MessageBox.Show("pase por un constructor estático");
        }

        private Constructores(string instanciaUno,string instanciaDos)
        {
            this.deInstancia = instanciaUno;
            this.deInstanciaDos = instanciaDos;

            MessageBox.Show("pase por un constructor que reciba 2 parámetros");         
        }

        public Constructores()
        {
            Constructores c = new Constructores("pepe","juan");

            MessageBox.Show("pase por un constructor público (default).");
      
            DeInstanciaDos = "solo lectura";
            string lectura = DeInstancia;

            this.MetodoInstancia();
        }

        public void MetodoInstancia()
        {
            MessageBox.Show("pase por un método de instancia");
            Constructores.MetodoDeClase();
        }

        public static void MetodoDeClase()
        {
            MessageBox.Show("pase por un método de clase.");
        }

        
    }
}
