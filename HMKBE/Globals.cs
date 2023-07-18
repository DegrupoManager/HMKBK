using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HMKBE
{
    public static  class Globals
    {

        public static string DbServerType;
        public static string Path;
        public static SAPbobsCOM.CompanyService oCompanyService;
        public static SAPbobsCOM.Company oCompany;
        public static SAPbouiCOM.Application Application { get; set; }
        public static string CompanyName { get; set; }
        public static string UserName { get; set; }
        public static string UserPassword { get; set; }

        public static string SessionId { get; set; }
        public static string SessionTimeout { get; set; }
        public static string Version { get; set; }

        public static bool IsConnected { get; set; }

        public static string UrlServiceLayer { get; set; }


        public static string ConnectionContexSAP { get; set; }
    }
}