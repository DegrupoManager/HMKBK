using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using TOL.Products;
using TOL.Storages;


namespace HMKBE.Controllers
{
    public class ProductController : ApiController
    {
        [Route("api/product/getProductById")]
        [HttpGet]
        public HttpResponseMessage getProductById(string productId, string productListId)
        {
            BLL.products bll = new BLL.products();
            Product item = bll.getProductById(productId, productListId);
            return Request.CreateResponse(HttpStatusCode.OK, item);
        }
        [Route("api/product/getProductList")]
        [HttpGet]
        public HttpResponseMessage getProductList()
        {
            BLL.products bll = new BLL.products();
            PItem[] myList = bll.getProductList();
            return Request.CreateResponse(HttpStatusCode.OK, myList);
        }
        [Route("api/product/getStoragesByProductId")]
        [HttpGet]
        public HttpResponseMessage getStoragesByProductId(string productId)
        {
            BLL.products bll = new BLL.products();
            SItem[] myList = bll.getStoragesByProductId(productId);
            return Request.CreateResponse(HttpStatusCode.OK, myList);
        }


    }
}
