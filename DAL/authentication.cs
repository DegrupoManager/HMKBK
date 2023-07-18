using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Sap.Data.Hana;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using TOL;

namespace DAL
{
    public class authentication
    {
        public LoginOutput login(LoginInput cred)
        {
            LoginOutput myResponse = new LoginOutput();

            HanaConnection conn = new HanaConnection(AccesoDatos.Cadena);

            conn.Open();

                HanaCommand cmd = new HanaCommand("", conn);
            // HanaDataReader reader = cmd.ExecuteReader();
            cmd.CommandText = "SBO_TEST_240523_PE.DGP_AW_LOGIN";
            cmd.CommandType = System.Data.CommandType.StoredProcedure;

            HanaParameter param = new HanaParameter();
            param = cmd.CreateParameter();
            param.HanaDbType = HanaDbType.NVarChar;
            param.Direction = System.Data.ParameterDirection.Input;
            param.Value = cred.username;
            param.ParameterName = "user";
            cmd.Parameters.Add(param);
            HanaParameter param1 = new HanaParameter();
            param1 = cmd.CreateParameter();
            param1.HanaDbType = HanaDbType.NVarChar;
            param1.Direction = System.Data.ParameterDirection.Input;
            param1.ParameterName = "passsword";
            param1.Value = cred.password;
            cmd.Parameters.Add(param1);
            HanaDataReader result = cmd.ExecuteReader();
            if (result.Read())
            {
                myResponse.id = (string)result[0];
                myResponse.nombre = (string)result[1];
                myResponse.rol = (string)result[2];
            }
            conn.Close();
            conn.Dispose();
            return myResponse;
        }
        public async Task<string> getServiceLayerTokenAsync()
        {
            try
            {
                var client = new HttpClient();
                //client.DefaultRequestHeaders.ExpectContinue = false;
                var request = new HttpRequestMessage(HttpMethod.Post, "http://10.171.151.202:50000/b1s/v1/Login");
                //request.Headers.Add("Cookie", "B1SESSION=1676b764-16ba-11ee-8000-00505680205c; ROUTEID=.node3");
                var content = new StringContent("{\r\n    \"CompanyDB\": \"SBO_TEST_240523_PE\",\r\n    \"Password\": \"15agosto\",\r\n    \"UserName\": \"manager\"\r\n}", null, "application/json");
                request.Content = content;
                var response = await client.SendAsync(request);
                response.EnsureSuccessStatusCode();
                var c = await response.Content.ReadAsStringAsync();
                JObject json = JObject.Parse(c);
                var token = json["SessionId"].ToString();
            }
            catch(Exception ex)
            {
                var a = ex;
            }





            //var client = new HttpClient();
            //var request = new HttpRequestMessage(HttpMethod.Post, "http://10.171.151.202:50000/b1s/v1/Login");
            ////request.Headers.Add("Cookie", "B1SESSION=7dcc1392-161e-11ee-8000-00505680205c; ROUTEID=.node3");
            //var content = new StringContent("{\"CompanyDB\":\"SBO_TEST_240523_PE\",\"Password\":\"15agosto\",\"UserName\":\"manager\"}", null, "application/json");
            //request.Content = content;
            //var response = await client.SendAsync(request);
            //response.EnsureSuccessStatusCode();
            //var wToken = await response.Content.ReadAsStringAsync();
            var wToken = ""; // response.Content.ToString();

            return wToken;
        }
    }
}
