using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsFinal
{
    public class ExcepcionPropia : Exception
    {
        public ExcepcionPropia() : base(null,null) 
        { 

        }
        public ExcepcionPropia(string mensaje) : base(mensaje, null)
        {

        }
        public ExcepcionPropia(string mensaje, Exception a) : base(mensaje, a)
        {

        }
    }
}
