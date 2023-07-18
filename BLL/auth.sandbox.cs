using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using TOL;

namespace BLL
{
    public class hmkauth
    {
        public LoginResponse login(string username, string clave)
        {
            DAL.authentication dal = new DAL.authentication();
            LoginInput myInput = new LoginInput();
            myInput.username = username;
            myInput.password = clave;
            LoginOutput rpta = dal.login(myInput);
            LoginResponse myResponse = new LoginResponse();
            myResponse.id = rpta.id;
            myResponse.nombre = rpta.nombre;
            myResponse.rol = rpta.rol;
            return myResponse;
        }
    }
}
