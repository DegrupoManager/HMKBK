using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TOL.Drafts;
using TOL.PreliminaryOrders;

namespace BLL
{
    public class PreliminaryOrders
    {
        public consulta[] getConsulta(
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
            DAL.drafts dal = new DAL.drafts();


            consulta[] myList = dal.getConsulta(
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
            return myList;
        }

        public reporte[] getReporte(
            string FechaInicioEmision,
            string FechaFinEmision,
            string CodAlmacen)
        {
            DAL.drafts dal = new DAL.drafts();


            reporte[] myList = dal.getReporte(
                FechaInicioEmision,
                FechaFinEmision,
                CodAlmacen
            );
            return myList;
        }
        public status[] getStatus()
        {
            DAL.drafts dal = new DAL.drafts();


            status[] myList = dal.getStatus();
            return myList;

        }

        public estado[] getEstado()
        {
            DAL.drafts dal = new DAL.drafts();


            estado[] myList = dal.getEstado();
            return myList;

        }




        public PreliminaryOrdersItem[] getPreOrdersList(string id)
        {
            DAL.drafts dal = new DAL.drafts();
            

            PreliminaryOrdersItem[] myList = dal.getDraftList(id);
            return myList;

        }
        public PreliminaryOrder[] getPreliminaryOrderAsync(string id)
        {
            PreliminaryOrder[] myTable = null;

            DAL.drafts dal = new DAL.drafts();
            myTable = dal.getDraft(id);

            return myTable;
        }
        public async Task<PreliminaryOrder> createPreliminaryOrderAsync(JObject order)
        {
            DAL.drafts dal = new DAL.drafts();
            PreliminaryOrder rpta = null;
            rpta = await dal.createDraftAsync(order);

            return rpta;
        }
        public async Task<string> deletePreliminaryOrderAsync(string id)
        {
            DAL.drafts dal = new DAL.drafts();
            string rpta = null;
            rpta = await dal.deleteDraftAsync(id);

            return rpta;
        }
        public async Task<PreliminaryOrder[]> updatePreliminaryOrderAsync(string id, JObject order)
        {
            DAL.drafts dal = new DAL.drafts();
            PreliminaryOrder[] rpta = null;
            rpta = await dal.updateDraftAsync(id, order);

            return rpta;
        }
        public SerieList[] getNumberSerie(string serieCodigo)
        {
            DAL.drafts dal = new DAL.drafts();
            SerieList[] myList = dal.getNumberSerie(serieCodigo);
            return myList;
        }
        public TipoSerie[] getSerieList()
        {
            DAL.drafts dal = new DAL.drafts();
            TipoSerie[] myList = dal.getListSeries();
            return myList;
        }
        public float getPorcentajeDescuentoAsync(string ProductId, string StorageId)
        {
            DAL.drafts dal = new DAL.drafts();
            float descuento =  dal.getPorcentajeDescuentoAsync(ProductId, StorageId);
            return descuento;
        }
        public Consignacion[] getConsignacion() {
            DAL.drafts dal = new DAL.drafts();
            var lst = dal.getConsignacionAsync();
            return lst;
        }
        public TransferenciaGratuita[] getTransferenciaGratuita() {
            DAL.drafts dal = new DAL.drafts();
            var lst = dal.getTransferenciaGratuita();
            return lst;
        }
        public LineArt getLineArt(string codListaPrecio, string itemId, string storageId)
        {
            DAL.drafts dal = new DAL.drafts();
            LineArt lineart = dal.getLineArt(codListaPrecio, itemId, storageId);
            return lineart;
        }
    }
}
