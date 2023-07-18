using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class AccesoDatos
    {
        public static string Cadena = traerCadenaConexion();

        public static string traerCadenaConexion()
        {
            string cadena = @"Server=10.171.151.202:30015;UserName=B1ADMIN;Password=uOAQhY09xk";
            return cadena;

        }
    }
}
