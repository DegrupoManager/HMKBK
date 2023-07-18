using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TOL.Drafts
{
    public class Condignacion { 
        public string item;
        public string value;
        public Condignacion() { }
        public Condignacion(string item, string value)
        {
            this.item = item;
            this.value = value;
        }
    }
}
