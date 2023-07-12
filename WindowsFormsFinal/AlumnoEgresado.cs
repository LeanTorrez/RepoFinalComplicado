using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace WindowsFormsFinal
{
    public class AlumnoEgresado : Alumno,ISerializar,IDeserializar
    {
        public float promedio;
        public short promocion;

        public AlumnoEgresado() : base(new Persona("pepe","pepe",EIdioma.Español,2),0,ENivelDeEstudio.Universitaria)
        { }

        public AlumnoEgresado(Alumno a,float promedio,short promicion) : base((Alumno)a, a.legajo, a.nivel)
        {
            this.promedio = promedio;
            this.promocion = promicion;
        }

        public override string ToString()
        {
            return base.ToString() + $"Promedio {this.promedio} Promocion {this.promocion}";
        }

        public bool Xml(string ruta)
        {
            bool retorno = false;
            try
            {
                using (StreamWriter streamWriter = new StreamWriter(ruta))
                {
                    XmlSerializer xmlSerializer = new XmlSerializer(typeof(AlumnoEgresado));

                    xmlSerializer.Serialize(streamWriter,this);
                }
                retorno = true;
            }
            catch (Exception ex) { }

            return retorno;
        }

        bool IDeserializar.Xml(string ruta,out AlumnoEgresado a)
        {
            bool retorno = false;

            try
            {
                using (StreamReader streamReader = new StreamReader(ruta))
                {
                    XmlSerializer xmlSerializer = new XmlSerializer(typeof(AlumnoEgresado));
                    a = xmlSerializer.Deserialize(streamReader) as AlumnoEgresado;
                }         
                
                return true;
            }
            catch (Exception)
            {
                
            }
            a = null;
            return false;
        }
    }
}
