
using Newtonsoft.Json.Linq;
using SAPbouiCOM.Framework;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using TOL.Drafts;
using TOL.PreliminaryOrders;

namespace HMKBE.Controllers
{
    public class PreOrdersController : ApiController
    {
        [Route("api/PreOrders/list")]
        [HttpGet]
        public HttpResponseMessage List(string id)
        {
            BLL.PreliminaryOrders bll = new BLL.PreliminaryOrders();
            PreliminaryOrdersItem[] lst = bll.getPreOrdersList(id);
            return Request.CreateResponse(HttpStatusCode.OK, lst);
        }

        [Route("api/PreOrders/getPorcentajeDescuento")]
        [HttpGet]
        public HttpResponseMessage getPorcentajeDescuento(string productId, string storageId)
        {
            BLL.PreliminaryOrders bll = new BLL.PreliminaryOrders();
            float draft =  bll.getPorcentajeDescuentoAsync(productId, storageId);
            return Request.CreateResponse(HttpStatusCode.OK, draft);
        }

        [Route("api/PreOrders")]
        [HttpPost]
        public async Task<HttpResponseMessage> PostAsync(JObject newOrder)
        {
            BLL.PreliminaryOrders bll = new BLL.PreliminaryOrders();
            PreliminaryOrder draft = await bll.createPreliminaryOrderAsync(newOrder);
            return Request.CreateResponse(HttpStatusCode.OK, draft);
        }

        [Route("api/PreOrders")]
        [HttpGet]
        public HttpResponseMessage GetAsync(string id)
        {
            BLL.PreliminaryOrders bll = new BLL.PreliminaryOrders();
            object draft = bll.getPreliminaryOrderAsync(id);
            return Request.CreateResponse(HttpStatusCode.OK, draft);
        }
        [Route("api/PreOrders")]
        [HttpDelete]
        public async Task<HttpResponseMessage> DeleteAsync(string id)
        {
            BLL.PreliminaryOrders bll = new BLL.PreliminaryOrders();
            object draft = await bll.deletePreliminaryOrderAsync(id);
            return Request.CreateResponse(HttpStatusCode.OK, draft);
        }
        [Route("api/PreOrders")]
        [HttpPatch]
        public async Task<HttpResponseMessage> PatchAsync(JObject order)
        {
            BLL.PreliminaryOrders bll = new BLL.PreliminaryOrders();
            string id = order.Property("DocEntry").Value.ToString();
            order.Property("DocEntry").Remove();
            object draft = await bll.updatePreliminaryOrderAsync(id,order);
            return Request.CreateResponse(HttpStatusCode.OK, draft);
        }
        [Route("api/PreOrders/getLineArt")]
        [HttpGet]
        public HttpResponseMessage getLineArt(string codListaPrecio, string productId, string storageId)
        {
            BLL.PreliminaryOrders bll = new BLL.PreliminaryOrders();
            LineArt lst = bll.getLineArt(codListaPrecio, productId, storageId);
            return Request.CreateResponse(HttpStatusCode.OK, lst);
        }

        [Route("api/PreOrders/getConsulta")]
        [HttpGet]
        public HttpResponseMessage getConsulta(
            string ItemCodeD,
            string CardName,
            string StatusDraft,
            string OrdenCompra,
            string HoraFinC,
            string Coment,
            string SlpNameV,
            string HoraInicioC,
            string FechaInicioEmision,
            string FechaFinEmision,
            string EstadoDraft,
            string Direccion,
            string CodCliente,
            string ItemNameD,
            string NombVendedor,
            string CodAlmacen)
        {
            BLL.PreliminaryOrders bll = new BLL.PreliminaryOrders();
            consulta[] lst = bll.getConsulta(
            ItemCodeD,
            CardName,
            StatusDraft,
            OrdenCompra,
            HoraFinC,
            Coment,
            SlpNameV,
            HoraInicioC,
            FechaInicioEmision,
            FechaFinEmision,
            EstadoDraft,
            Direccion,
            CodCliente,
            ItemNameD,
            NombVendedor,
            CodAlmacen);
            return Request.CreateResponse(HttpStatusCode.OK, lst);
        }
        [Route("api/PreOrders/getReporte")]
        [HttpGet]
        public HttpResponseMessage getReporte(
            string FechaInicioEmision,
            string FechaFinEmision,
            string CodAlmacen)
        {
            BLL.PreliminaryOrders bll = new BLL.PreliminaryOrders();
            reporte[] lst = bll.getReporte(
                FechaInicioEmision,
                FechaFinEmision,
                CodAlmacen
            );
            return Request.CreateResponse(HttpStatusCode.OK, lst);
        }


        /***********/

        [Route("api/PreOrders/getSerieDoc")]
        [HttpGet]
        public HttpResponseMessage getNumberSerie(string serieCodigo)
        {
            BLL.PreliminaryOrders bll = new BLL.PreliminaryOrders();
            SerieList[] lst = bll.getNumberSerie(serieCodigo);
            return Request.CreateResponse(HttpStatusCode.OK, lst);
        }

        [Route("api/PreOrders/getSerieList")]
        [HttpGet]
        public HttpResponseMessage getSerieList()
        {
            BLL.PreliminaryOrders bll = new BLL.PreliminaryOrders();
            TipoSerie[] lst = bll.getSerieList();
            return Request.CreateResponse(HttpStatusCode.OK, lst);
        }

        [Route("api/PreOrders/getStatus")]
        [HttpGet]
        public HttpResponseMessage getStatus()
        {
            BLL.PreliminaryOrders bll = new BLL.PreliminaryOrders();
            status[] lst = bll.getStatus();
            return Request.CreateResponse(HttpStatusCode.OK, lst);
        }


        [Route("api/PreOrders/getEstado")]
        [HttpGet]
        public HttpResponseMessage getEstado()
        {
            BLL.PreliminaryOrders bll = new BLL.PreliminaryOrders();
            estado[] lst = bll.getEstado();
            return Request.CreateResponse(HttpStatusCode.OK, lst);
        }
        [Route("api/PreOrders/getConsignacion")]
        [HttpGet]
        public HttpResponseMessage getConsignacion()
        {
            BLL.PreliminaryOrders bll = new BLL.PreliminaryOrders();
            Consignacion[] lst = bll.getConsignacion();
            return Request.CreateResponse(HttpStatusCode.OK, lst);
        }

        [Route("api/PreOrders/getTransferenciaGratuita")]
        [HttpGet]
        public HttpResponseMessage getTransferenciaGratuita()
        {
            BLL.PreliminaryOrders bll = new BLL.PreliminaryOrders();
            TransferenciaGratuita[] lst = bll.getTransferenciaGratuita();
            return Request.CreateResponse(HttpStatusCode.OK, lst);
        }


    }
}

