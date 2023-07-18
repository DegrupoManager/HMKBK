using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Xml;

namespace HMKBE
{
    public class Conexion
    {
        public static string CompaniaDefault { get; set; }
        public static string UserLogueado { get; set; }
        public static string pwd { get; set; }

        public static string CatalogoHana { get; set; }
        public static string Version { get; set; }

        public static string UsuarioSAP { get; set; }
        public static string PwdSAP { get; set; }
 
        public static string Server { get; set; }
        public static string LicenseServer { get; set; }
        public static string UserHana { get; set; }
        public static string PwdHana { get; set; }

        public static void TraerCatalogo()
        {
            try
            {
                using (XmlReader reader = XmlReader.Create(AppDomain.CurrentDomain.BaseDirectory + @"DGP_HANA.XML"))
                {
                    while (reader.Read())
                    {
                        if (reader.IsStartElement())
                        {
                            switch (reader.Name.ToString())
                            {
                                case "CatalogoHana":
                                    CatalogoHana = reader.ReadString();
                                    break;
                                case "Version":
                                    Version = reader.ReadString();
                                    break;
                                case "UserSAP":
                                    UsuarioSAP = reader.ReadString();
                                    break;
                                case "PwdSAP":
                                    PwdSAP = reader.ReadString();
                                    break;
                                case "Server":
                                    Server = reader.ReadString();
                                    break;
                                case "LicenseServer":
                                    LicenseServer = reader.ReadString();
                                    break;
                                case "UserHana":
                                    UserHana = reader.ReadString();
                                    break;
                                case "PwdHana":
                                    PwdHana = reader.ReadString();
                                    break;
                            }
                        }

                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
        }

    }
}