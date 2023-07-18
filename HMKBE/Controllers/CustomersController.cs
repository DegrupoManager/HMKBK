using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using TOL.Customers;
using TOL.Contacts;

namespace HMKBE.Controllers
{
    public class CustomersController : ApiController
    {
        [Route("api/customer/getCustomerById")]
        [HttpGet]
        public HttpResponseMessage getCustomerById(string customerId)
        {
            BLL.Customers bll = new BLL.Customers();
            Customer item = bll.getCustomerById(customerId);
            return Request.CreateResponse(HttpStatusCode.OK, item);
        }

        [Route("api/customer/getCustomerList")]
        [HttpGet]
        public HttpResponseMessage getCustomerList()
        {
            BLL.Customers bll = new BLL.Customers();
            CItem[] myLst = bll.getCustomerList();
            return Request.CreateResponse(HttpStatusCode.OK, myLst);
        }
        
        [Route("api/customer/getPersonContactsByCustomerId")]
        [HttpGet]
        public HttpResponseMessage getPersonContacsByCustomerId(string customerId)
        {
            BLL.Customers bll = new BLL.Customers();
            ContactItem[] myLst = bll.getPersonContactsList(customerId);
            return Request.CreateResponse(HttpStatusCode.OK, myLst);
        }
        [Route("api/customer/getCustomerAddressByType")]
        [HttpGet]
        public HttpResponseMessage getCustomerAddressByType(string addressType, string customerId)
        {
            BLL.Customers bll = new BLL.Customers();
            CustomerAddressList[] myLst = bll.GetCustomerAddressList(addressType,customerId);
            return Request.CreateResponse(HttpStatusCode.OK, myLst);
        }
    }
}
