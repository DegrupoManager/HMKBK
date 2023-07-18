using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using TOL;
using BLL;

namespace HMKBE.Controllers
{
    public class AuthController : ApiController
    {
        [Route("api/Auth/Login")]
        [HttpPost]
        public HttpResponseMessage Login([FromBody]LoginRequest cred)
        {
            LoginResponse rpta;

            try
            {
                hmkauth auth = new hmkauth();
                rpta = auth.login(cred.username, cred.password);
                return Request.CreateResponse(HttpStatusCode.OK, rpta);
            }
            catch(Exception e)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest,e.Message);
            }

        }
        // GET: api/Auth
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/Auth/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Auth
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/Auth/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Auth/5
        public void Delete(int id)
        {
        }
    }
}
