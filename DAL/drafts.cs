using B1SLayer;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json.Serialization;
using RestSharp;
using Sap.Data.Hana;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using TOL.Drafts;
using TOL.PreliminaryOrders;

namespace DAL
{
    public sealed class ServiceLayer
    {
        private static readonly SLConnection _serviceLayer = new SLConnection(
            "http://10.171.151.202:50000/b1s/v1/",
            "SBO_TEST_240523_PE",
            "manager",
            "15agosto");

        static ServiceLayer() { }

        private ServiceLayer() { }

        public static SLConnection Connection => _serviceLayer;
    }
    public class drafts
    {
        public PreliminaryOrdersItem[] getDraftList(string user)
        {
            List<PreliminaryOrdersItem> lstDLO = new List<PreliminaryOrdersItem>();
            HanaConnection conn = new HanaConnection(AccesoDatos.Cadena);

            conn.Open();

            HanaCommand cmd = new HanaCommand("SELECT " +
                "\"CodigoCliente\"," +
                "\"NombreCliente\"," +
                "\"Fecha\"," +
                "\"Estado\"," +
                "\"Status\"," +
                "\"Usuario\"," +
                "\"Vendedor\"," +
                "\"HoraC\"," +
                " \"NroOrden\"," +
                " \"Monto\"," +
                "\"ClaseDocumento\" " +
                "FROM \"_SYS_BIC\".\"DPG_Web/DGP_GET_PRELIMINARY_WEB\"('PLACEHOLDER' = ('$$UsuarioWeb$$', '" + user + "'))", conn)
            {

            };
            cmd.CommandType = System.Data.CommandType.Text;

            HanaDataReader result = cmd.ExecuteReader();
            while (result.Read())
            {
                PreliminaryOrdersItem myDLO = new PreliminaryOrdersItem();
                
                myDLO.cliente_codigo = (string)result[0];
                myDLO.cliente_nombre = (string)result[1];

                var fecha = (DateTime)result[2];
                TimeSpan ts = new TimeSpan(int.Parse(result[7].ToString().Substring(0,2)), int.Parse(result[7].ToString().Substring(2, 2)), 0);
                myDLO.fecha = (fecha.Date + ts).ToString("dd/MM/yyyy HH:mm:00");
                myDLO.status = (string)result[4];
                myDLO.estado = (string)result[3];
                myDLO.ClaseDocumento = (string)result[10];
                myDLO.usuario = (string)result[5];
                myDLO.vendedor = (string)result[6];
                myDLO.horaC = (string)result[7];
                myDLO.num_orden = (int)result[8];
                myDLO.monto = float.Parse(result[9].ToString());
                lstDLO.Add(myDLO);
            }
            conn.Close(); conn.Dispose();
            return lstDLO.ToArray();
        }
        public PreliminaryOrder[] getDraft(string id)
        {
            List<PreliminaryOrder> myList = new List<PreliminaryOrder>();
            HanaConnection conn = new HanaConnection(AccesoDatos.Cadena);
            HanaCommand cmd = new HanaCommand("SELECT " +
                "   \"ClaseDocumento\"," +
                "   \"CodigoCliente\"," +
                "   \"NombreCliente\"," +
                "   \"CodPersonaContacto\"," +
                "   \"NombrePersonaContacto\"," +
                "   \"FechaContabilizacion\"," +
                "   \"FechaEntrega\"," +
                "   \"FechaDocumento\"," +
                "   \"Estado\"," +
                "   \"Status\"," +
                "   \"Usuario\"," +
                "   \"Vendedor\"," +
                "   \"CodArticulo\"," +
                "   \"Descripcion\"," +
                "   \"Almacen\"," +
                "   \"IndicadorImpuesto\"," +
                "   \"Moneda\"," +
                "   \"CodTerminoPago\"," +
                "   \"TerminoPago\"," +
                "   \"NumRef\"," +
                "   \"CodDireEntrega\"," +
                "   \"DireEntrega\"," +
                "   \"CodDireFactura\"," +
                "   \"DireFactura\"," +
                "   \"SerieDocumento\"," +
                "   \"IdTransferencia\"," +
                "   \"DescripcionTransferencia\"," +
                "   \"IdConsignacion\"," +
                "   \"DescripcionConsignacion\"," +
                "   \"NroOrden\"," +
                "   \"Monto\"," +
                "   \"Descuento\"," +
                "   \"CantidadAlmacen\"," +
                "   \"StockGeneral\"," +
                "   \"Cantidad\"," +
                "   \"CodigodeBarra\"," +
                "   \"SeriesNombre\"," +
                "   \"Comentario\"," +
                "   \"DocNumero\"," +
                "   \"PrecioUnitario\"," +
                "   \"ValorImpuesto\"," +
                "   \"OrdenDeCompra\" " +
                "FROM \"_SYS_BIC\".\"DPG_Web/DGP_GET_ORDER_PRELIMINARY\"('PLACEHOLDER' = ('$$DocEntry$$', '" + id + "'))", conn);

            conn.Open();

            cmd.CommandType = System.Data.CommandType.Text;

            HanaDataReader result = cmd.ExecuteReader();
            while (result.Read())
            {
                PreliminaryOrder myRecord = new PreliminaryOrder();
                myRecord.ClaseDocumento = result[0].ToString();
                myRecord.CodigoCliente = result[1].ToString();
                myRecord.NombreCliente = result[2].ToString();
                myRecord.CodPersonaContacto = result[3].ToString();
                myRecord.NombrePersonaContacto = result[4].ToString();
                myRecord.FechaContabilizacion = result[5].ToString();
                myRecord.FechaEntrega = result[6].ToString();
                myRecord.FechaDocumento = result[7].ToString();
                myRecord.Estado = result[8].ToString();
                myRecord.Status = result[9].ToString();
                myRecord.Usuario = result[10].ToString();
                myRecord.Vendedor = result[11].ToString();
                myRecord.CodArticulo = result[12].ToString();
                myRecord.Descripcion = result[13].ToString();
                myRecord.Almacen = result[14].ToString();
                myRecord.IndicadorImpuesto = result[15].ToString();
                myRecord.Moneda = result[16].ToString();
                myRecord.CodTerminoPago = result[17].ToString();
                myRecord.TerminoPago = result[18].ToString();
                myRecord.NumRef = result[19].ToString();
                myRecord.CodDireEntrega = result[20].ToString();
                myRecord.DireEntrega = result[21].ToString();
                myRecord.CodDireFactura = result[22].ToString();
                myRecord.DireFactura = result[23].ToString();
                myRecord.SerieDocumento = result[24].ToString();
                myRecord.IdTransferencia = result[25].ToString();
                myRecord.DescripcionTransferencia = result[26].ToString();
                myRecord.IdConsignacion = result[27].ToString();
                myRecord.DescripcionConsignacion = result[28].ToString();
                myRecord.NroOrden = result[29].ToString();
                myRecord.Monto = result[30].ToString();
                myRecord.Descuento = result[31].ToString();
                myRecord.CantidadAlmacen = result[32].ToString();
                myRecord.StockGeneral = result[33].ToString();
                myRecord.Cantidad = result[34].ToString();
                myRecord.PrecioUnitario = result[39].ToString();
                myRecord.CodigodeBarra = result[35].ToString();
                myRecord.SeriesNombre = result[36].ToString();
                myRecord.Comentario = result[37].ToString();
                myRecord.DocNumero = result[38].ToString();
                myRecord.ValorImpuesto = result[40].ToString();
                myRecord.OrdenDeCompra = result[41].ToString();
                myList.Add(myRecord);
            }
            conn.Close(); conn.Dispose();
            return myList.ToArray();
        }

        public reporte[] getReporte(
            string FechaInicioEmision,
            string FechaFinEmision,
            string CodAlmacen)
        {
            List<reporte> myList = new List<reporte>();
            HanaConnection conn = new HanaConnection(AccesoDatos.Cadena);
            HanaCommand cmd = new HanaCommand("SELECT" +
            " \"Tipo\"," +
            " \"NumeroDocumento\"," +
            " \"NumeroFiscal\"," +
            " \"FechaContabilizacion\"," +
            " \"NombreCliente\"," +
            " \"NumArticulo\"," +
            " \"CodBarra\"," +
            " \"DescripcionArticulo\"," +
            " \"CodAlmacen\"," +
            " \"NumeroLote\"," +
            " \"FechaVencimiento\"," +
            " \"NumInterno\"," +
            " \"NumeroLinea\"," +
            " \"Cantidad\" " +
            " FROM \"_SYS_BIC\".\"DPG_Web/DGP_GET_CONSIGNACION\"(" +
            "'PLACEHOLDER' = ('$$FechaInicio$$','" + FechaInicioEmision + "')," +
            "'PLACEHOLDER' = ('$$FechaFin$$','" + FechaFinEmision + "')," +
            "'PLACEHOLDER' = ('$$Almacen$$','" + CodAlmacen + "'))", conn);

            conn.Open();

            cmd.CommandType = System.Data.CommandType.Text;

            HanaDataReader result = cmd.ExecuteReader();
            while (result.Read())
            {
                reporte myRecord = new reporte();
                
                myRecord.Tipo = result[0].ToString();
                myRecord.NumeroDocumento = result[1].ToString();
                myRecord.NumeroFiscal = result[2].ToString();
                myRecord.FechaContabilizacion = (result[3].ToString() == "") ? "" : ((DateTime)result[3]).ToString("dd/MM/yyyy");
                myRecord.NombreCliente = result[4].ToString();
                myRecord.NumArticulo = result[5].ToString();
                myRecord.CodBarra = result[6].ToString();
                myRecord.DescripcionArticulo = result[7].ToString();
                myRecord.CodAlmacen = result[8].ToString();
                myRecord.NumeroLote = result[9].ToString();
                myRecord.FechaVencimiento = (result[10].ToString() == "")?"":((DateTime)result[10]).ToString("dd/MM/yyyy");
                myRecord.NumInterno = result[11].ToString();
                myRecord.NumeroLinea = result[12].ToString();
                myRecord.Cantidad = result[13].ToString();
                myList.Add(myRecord);
            }
            conn.Close(); conn.Dispose();
            return myList.ToArray();
        }


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
            List<consulta> myList = new List<consulta>();
            HanaConnection conn = new HanaConnection(AccesoDatos.Cadena);
            HanaCommand cmd = new HanaCommand("SELECT" +
            " \"CodigoCliente\"," +
            " \"NombreCliente\"," +
            " \"Fecha\","+
            " \"HoraCreacion\","+
            " \"Vendedor\","+
            " \"Estado\","+
            " \"Status\","+
            " \"Comentario\","+
            " \"DireEntrega\","+
            " \"Numero_Entrega\","+
            " \"NroOrden\","+
            " \"SubTotal\","+
            " \"Total\" "+
            " FROM \"_SYS_BIC\".\"DPG_Web/DGP_GET_CONSULT_PRELIMINARY\"("+
            "'PLACEHOLDER' = ('$$ItemCodeD$$', '" + ItemCodeD + "')," +
            "'PLACEHOLDER' = ('$$CardName$$','" + CardName + "')," + //
            "'PLACEHOLDER' = ('$$StatusDraft$$','" + StatusDraft + "')," + //
            "'PLACEHOLDER' = ('$$OrdenCompra$$','" + OrdenCompra + "')," + //
            "'PLACEHOLDER' = ('$$HoraFinC$$','" + HoraFinC + "')," + //
            "'PLACEHOLDER' = ('$$Coment$$','" + Coment + "')," + //
            "'PLACEHOLDER' = ('$$SlpNameV$$','" + SlpNameV + "')," + //
            "'PLACEHOLDER' = ('$$HoraInicioC$$','" + HoraInicioC + "')," + //
            "'PLACEHOLDER' = ('$$FechaInicioEmision$$','" + FechaInicioEmision + "')," + //
            "'PLACEHOLDER' = ('$$FechaFinEmision$$','" + FechaFinEmision + "')," + //
            "'PLACEHOLDER' = ('$$EstadoDraft$$','" + EstadoDraft + "')," + //
            "'PLACEHOLDER' = ('$$Direccion$$','" + Direccion + "')," + //
            "'PLACEHOLDER' = ('$$CodCliente$$','" + CodCliente + "')," + //
            "'PLACEHOLDER' = ('$$ItemNameD$$','" + ItemNameD + "')," + //
            "'PLACEHOLDER' = ('$$NombVendedor$$','" + NombVendedor + "')," + // 
            "'PLACEHOLDER' = ('$$CodAlmacen$$','" + CodAlmacen + "'))", conn); //

            conn.Open();

            cmd.CommandType = System.Data.CommandType.Text;

            HanaDataReader result = cmd.ExecuteReader();
            while (result.Read())
            {
                consulta myRecord = new consulta();
                myRecord.CodigoCliente = result[0].ToString();
                myRecord.NombreCliente = result[1].ToString();
                myRecord.Fecha = ((DateTime)result[2]).ToString("dd/MM/yyyy");
                myRecord.HoraCreacion = result[3].ToString();
                myRecord.Vendedor = result[4].ToString();
                myRecord.Estado = result[5].ToString();
                myRecord.Status = result[6].ToString();
                myRecord.Comentario = result[7].ToString();
                myRecord.DireEntrega = result[8].ToString();
                myRecord.Numero_Entrega = result[9].ToString();
                myRecord.NroOrden = result[10].ToString();
                myRecord.SubTotal = result[11].ToString();
                myRecord.Total = result[12].ToString();
                myList.Add(myRecord);
            }
            conn.Close(); conn.Dispose();
            return myList.ToArray();
        }
        public async Task<PreliminaryOrder> createDraftAsync(JObject order)
        {
            var serviceLayer = ServiceLayer.Connection;
            serviceLayer.OnError(call =>
            {
                throw call.Exception;
            });
            //await serviceLayer.LoginAsync();
            JObject myRecord = await serviceLayer // SLConnection object
                    .Request("Drafts") // Creation // Configuration
                    .PostAsync<JObject>(order); // Execution
            return myRecord.ToObject<PreliminaryOrder>();
        }
        public async Task<string> deleteDraftAsync(string id)
        {
            try
            {
                var serviceLayer = ServiceLayer.Connection;
                await serviceLayer.LoginAsync();
                await serviceLayer // SLConnection object
                    .Request("Drafts", long.Parse(id)) // Creation
                    .DeleteAsync(); // Execution
            }
            catch(Exception ex)
            {
                return ex.Message;
            }
            return "OK";
        }
        public async Task<PreliminaryOrder[]> updateDraftAsync(string id, JObject order)
        {
            PreliminaryOrder[] myOrder = null;
            try {
            var serviceLayer = ServiceLayer.Connection;
            await serviceLayer.LoginAsync();
            await serviceLayer // SLConnection object
                .Request("Drafts", long.Parse(id)) // Creation // Configuration
                .PatchAsync(order); // Execution
                myOrder = getDraft(id);
            }catch(Exception ex)
            {
                var a = ex;
            }
            return myOrder; 
        }
        public status[] getStatus()
        {
            List<status> myList = new List<status>();

            HanaConnection conn = new HanaConnection(AccesoDatos.Cadena);

            conn.Open();

            HanaCommand cmd = new HanaCommand("SELECT \"CODE\",	 \"DESCRIPCION\" FROM \"_SYS_BIC\".\"DPG_Web/DGP_GET_LIST_STATUS\"", conn);
            cmd.CommandType = System.Data.CommandType.Text;

            HanaDataReader result = cmd.ExecuteReader();
            while (result.Read())
            {
                status myRecord = new status();
                myRecord.code = result[0].ToString();
                myRecord.description = result[1].ToString();
                myList.Add(myRecord);
            }
            conn.Close(); conn.Dispose();
            return myList.ToArray();
        }
        public estado[] getEstado()
        {
            List<estado> myList = new List<estado>();

            HanaConnection conn = new HanaConnection(AccesoDatos.Cadena);

            conn.Open();

            HanaCommand cmd = new HanaCommand("SELECT \"CODE\",	 \"DESCRIPCION\" FROM \"_SYS_BIC\".\"DPG_Web/DGP_GET_LIST_ESTATUS\"", conn);
            cmd.CommandType = System.Data.CommandType.Text;

            HanaDataReader result = cmd.ExecuteReader();
            while (result.Read())
            {
                estado myRecord = new estado();
                myRecord.codigo = result[0].ToString();
                myRecord.descripcion = result[1].ToString();
                myList.Add(myRecord);
            }
            conn.Close(); conn.Dispose();
            return myList.ToArray();
        }
        public SerieList[] getNumberSerie(string serieCodigo)
        {
            List<SerieList> myList = new List<SerieList>();

            HanaConnection conn = new HanaConnection(AccesoDatos.Cadena);

            conn.Open();

            HanaCommand cmd = new HanaCommand("SELECT * FROM \"_SYS_BIC\".\"DPG_Web/DGP_GET_SERIE_DRAFTS\"('PLACEHOLDER' = ('$$SerieCod$$', '" + serieCodigo + "'))", conn);
            // HanaDataReader reader = cmd.ExecuteReader();
            //cmd.CommandText = "SBO_TEST_240523_PE.DGP_GET_CLIENTE_COD";
            cmd.CommandType = System.Data.CommandType.Text;

            HanaDataReader result = cmd.ExecuteReader();
            while (result.Read())
            {
                SerieList myRecord = new SerieList();
                myRecord.CodSerie = result[0].ToString();
                myRecord.Correlativo = result[2].ToString();
                myRecord.NombreSerie = result[1].ToString();
                myList.Add(myRecord);
            }
            conn.Close(); conn.Dispose();
            return myList.ToArray();
        }
        public TipoSerie[] getListSeries()
        {
            List<TipoSerie> myList = new List<TipoSerie>();

            HanaConnection conn = new HanaConnection(AccesoDatos.Cadena);

            conn.Open();

            HanaCommand cmd = new HanaCommand("SELECT * FROM \"_SYS_BIC\".\"DPG_Web/DGP_GET_LIST_SERIE_DRAFTS\"", conn);
            // HanaDataReader reader = cmd.ExecuteReader();
            //cmd.CommandText = "SBO_TEST_240523_PE.DGP_GET_CLIENTE_COD";
            cmd.CommandType = System.Data.CommandType.Text;

            HanaDataReader result = cmd.ExecuteReader();
            while (result.Read())
            {
                TipoSerie myRecord = new TipoSerie();
                myRecord.CodSerie = result[0].ToString();
                myRecord.NombreSerie = result[1].ToString();
                myList.Add(myRecord);
            }
            conn.Close(); conn.Dispose();
            return myList.ToArray();
        }
        public float getPorcentajeDescuentoAsync(string itemId, string warehouseId)
        {
            float descuento = 0;

            HanaConnection conn = new HanaConnection(AccesoDatos.Cadena);

            conn.Open();

            HanaCommand cmd = new HanaCommand("SELECT * FROM \"_SYS_BIC\".\"DPG_Web/DGP_GET_PROC_DESC\"('PLACEHOLDER' = ('$$ItemCode$$', '" + itemId + "'),'PLACEHOLDER' = ('$$Almacen$$', '" + warehouseId + "'))", conn);
            cmd.CommandType = System.Data.CommandType.Text;

            HanaDataReader result = cmd.ExecuteReader();
            if (result.Read())
            {
                float.TryParse(result[0].ToString(), out descuento);
            }
            conn.Close(); conn.Dispose();
            return descuento;
        }
        public Consignacion[] getConsignacionAsync()
        {
            List<Consignacion> myList = new List<Consignacion>();

            HanaConnection conn = new HanaConnection(AccesoDatos.Cadena);

            conn.Open();

            HanaCommand cmd = new HanaCommand("SELECT * FROM \"_SYS_BIC\".\"DPG_Web/DGP_GET_CONSIG\"", conn);
            cmd.CommandType = System.Data.CommandType.Text;

            HanaDataReader result = cmd.ExecuteReader();
            while (result.Read())
            {
                Consignacion myRecord = new Consignacion();
                myRecord.id = result[0].ToString();
                myRecord.descripcion = result[1].ToString();
                myList.Add(myRecord);
            }
            conn.Close(); conn.Dispose();
            return myList.ToArray();
        }
        public TransferenciaGratuita[] getTransferenciaGratuita() {
            List<TransferenciaGratuita> myList = new List<TransferenciaGratuita>();

            HanaConnection conn = new HanaConnection(AccesoDatos.Cadena);

            conn.Open();

            HanaCommand cmd = new HanaCommand("SELECT * FROM \"_SYS_BIC\".\"DPG_Web/DGP_TRANS_GRATRU\"", conn);
            cmd.CommandType = System.Data.CommandType.Text;

            HanaDataReader result = cmd.ExecuteReader();
            while (result.Read())
            {
                TransferenciaGratuita myRecord = new TransferenciaGratuita();
                myRecord.id = result[0].ToString();
                myRecord.descripcion = result[1].ToString();
                myList.Add(myRecord);
            }
            conn.Close(); conn.Dispose();
            return myList.ToArray();

        }
        public LineArt getLineArt(string codListaPrecio, string itemId, string warehouseId)
        {
            LineArt myRecord = null;

            HanaConnection conn = new HanaConnection(AccesoDatos.Cadena);

            conn.Open();

            HanaCommand cmd = new HanaCommand("SELECT \"CodigoArticulo\"," +
                " \"DescripcionArticulo\"," +
                " \"CodigoAlmacen\"," +
                " \"Stock\"," +
                " \"StockGeneral\"," +
                " \"CodigoBarra\"," +
                " \"Precio\", " +
                "\"Impuesto\", " +
                " \"ValorImpuesto\" " +
                "FROM \"_SYS_BIC\".\"DPG_Web/DGP_GET_LINE_ART\"('PLACEHOLDER' = ('$$CodListaPrecio$$', '" + codListaPrecio + "'),'PLACEHOLDER' = ('$$CodArt$$', '" + itemId + "'),'PLACEHOLDER' = ('$$CodAlm$$', '" + warehouseId + "'))", conn);
            cmd.CommandType = System.Data.CommandType.Text;

            HanaDataReader result = cmd.ExecuteReader();
            if (result.Read())
            {
                myRecord = new LineArt();
                myRecord.CodigoArticulo = result[0].ToString();
                myRecord.DescripcionArticulo = result[1].ToString();
                myRecord.CodigoAlmacen = result[2].ToString();
                myRecord.Stock = result[3].ToString();
                myRecord.StockGeneral = result[4].ToString();
                myRecord.CodigoBarra = result[5].ToString();//
                myRecord.Precio = result[6].ToString();//
                myRecord.Impuesto = result[7].ToString();//
                myRecord.VarlorImpuesto = result[8].ToString();
            }
            conn.Close(); conn.Dispose();
            return myRecord;
        }
    }

}
