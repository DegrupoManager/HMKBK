using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HMKBE
{
    public class AccesoDatos
    {
        public static string Cadena = traerCadenaConexion();

        public static string traerCadenaConexion()
        {
            Conexion.TraerCatalogo();
            string cadena= @"Server=10.171.151.202:30015;UserName=B1ADMIN;Password=uOAQhY09xk;Database=NDB";
            //string cadena = @"Server=10.171.151.202:30015;UserName=SYSTEM;Password=L5dvqaGxjb;Database=NDB";

            return cadena;

        }
     }
}