using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsFinal
{
    public class Burbujeo
    {
        //Realizar el burbujeo de una excepción propia (MiException), comenzando en un método de instancia
        //(de la clase Burbujeo), pasando por un método de estático (de la misma clase *) y capturado 
        //por última vez en el método que lo inicio (manejador btnPunto4_Click). 
        //En cada paso, agregar en un único archivo de texto (burbujeo.log), en la carpeta 
        //'Mis documentos' del cliente, el lugar por donde se pasó junto con la hora, minuto y segundo de la acción. 
        //Atrapar la excepción y relanzarla en cada ocación.

        public Burbujeo() { }


        public void MetodoInstancia()
        {
            throw new ExcepcionPropia("desde metodo Isntancia");
        }
        public static void MetodoClase()
        {
            try
            {
                Burbujeo b = new Burbujeo();
                b.MetodoInstancia();
            }
            catch (ExcepcionPropia ex) 
            {
                EscrituraArchivo(ex.ToString());
                throw new ExcepcionPropia("desde metodo de clase",ex);
            }
        }

        public static void EscrituraArchivo(string escribir)
        {
            try
            {
                string path = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + @"\burbujeo.log";
                using (StreamWriter streamWriter = new StreamWriter(path, true))
                {
                    string hora = DateTime.Now.ToString("hh:mm:ss");
                    hora += "\n" + escribir;
                    streamWriter.WriteLine(hora);                    
                }
            }
            catch (Exception) { }
        }
    }
}
