using Sap.Data.Hana;
using System.Collections.Generic;
using TOL.BusinessPartner;
using TOL._Persons;
using TOL.Customers;

namespace DAL
{
    public class businessPartners
    {
        public BusinessPartner getBusinessPartnerById(string id)
        {
            BusinessPartner myBusinessPartner = null;
            HanaConnection conn = new HanaConnection(AccesoDatos.Cadena);
            conn.Open();

            HanaCommand cmd = new HanaCommand("SELECT * FROM \"_SYS_BIC\".\"DPG_Web/DGP_GET_CLIENTE_COD\"('PLACEHOLDER' = ('$$CodCliente$$', '" + id + "'))", conn);
            cmd.CommandType = System.Data.CommandType.Text;
            HanaDataReader result = cmd.ExecuteReader();
            if(result.Read())
            {
                myBusinessPartner = new BusinessPartner();
                myBusinessPartner.contactoCodigo = result[2].ToString();
                myBusinessPartner.Persona_contacto = result[3].ToString();
                myBusinessPartner.Moneda = result[4].ToString();
                myBusinessPartner.Nombre_Cliente = result[1].ToString();
                myBusinessPartner.Numero_Referencia = result[5].ToString();
                myBusinessPartner.codigoDireccionDestino = result[6].ToString();
                myBusinessPartner.Codigo_Cliente = result[0].ToString();
                myBusinessPartner.Direccion_Destino = result[7].ToString();
                myBusinessPartner.codigoDireccionFactura = result[8].ToString();
                myBusinessPartner.Direccion_Factura = result[9].ToString();
                myBusinessPartner.codigoCondicionPago = result[10].ToString();
                myBusinessPartner.Condicion_pago = result[11].ToString();
                myBusinessPartner.CodSerie = result[12].ToString();
                myBusinessPartner.Correlativo = result[13].ToString();
                myBusinessPartner.Cod_Lista_Precio = result[14].ToString();
            }
            conn.Close();
            conn.Dispose();
            return myBusinessPartner;
        }
        public BPItem[] getBusinessPartnerList()
        {
            List<BPItem> myList = new List<BPItem>();
            HanaConnection conn = new HanaConnection(AccesoDatos.Cadena);
            conn.Open();

            HanaCommand cmd = new HanaCommand("SELECT * FROM \"_SYS_BIC\".\"DPG_Web/DGP_GET_LIST_CLIENT\"", conn);
            cmd.CommandType = System.Data.CommandType.Text;

            HanaDataReader result = cmd.ExecuteReader();
            while (result.Read())
            {
                BPItem myRecord = new BPItem();
                myRecord.Codigo_CLiente = result[0].ToString();
                myRecord.Nombre_Cliente = result[1].ToString();
                
                myList.Add(myRecord);
            }
            conn.Close();
            conn.Dispose();
            return myList.ToArray();
        }
        public PersonItem[] getPersonsByBusinessPartnerId(string id)
        {
            List<PersonItem> myList = new List<PersonItem>();
            HanaConnection conn = new HanaConnection(AccesoDatos.Cadena);
            conn.Open();

            HanaCommand cmd = new HanaCommand("SELECT * FROM \"_SYS_BIC\".\"DPG_Web/DGP_GET_PERSON_CONTAC\"('PLACEHOLDER' = ('$$CardCode$$', '" + id + "'))", conn);
            cmd.CommandType = System.Data.CommandType.Text;

            HanaDataReader result = cmd.ExecuteReader();
            while (result.Read())
            {
                PersonItem myRecord = new PersonItem();
                myRecord.codigo = result[0].ToString();
                myRecord.descripcion = result[1].ToString();

                myList.Add(myRecord);
            }
            conn.Close();
            conn.Dispose();
            return myList.ToArray();
        }
        public CustomerAddressList[] getBusinessPartnerAddressByType(string adrressType, string bussinesPartnerId)
        {
            List<CustomerAddressList> myList = new List<CustomerAddressList>();

            HanaConnection conn = new HanaConnection(AccesoDatos.Cadena);

            conn.Open();

            HanaCommand cmd = new HanaCommand("SELECT * FROM \"_SYS_BIC\".\"DPG_Web/DGP_GET_LIST_ADDRESS\"('PLACEHOLDER' = ('$$TypeAddress$$', '" + adrressType + "'),'PLACEHOLDER' = ('$$CardCode$$', '" + bussinesPartnerId + "'))", conn);
            cmd.CommandType = System.Data.CommandType.Text;

            HanaDataReader result = cmd.ExecuteReader();
            while (result.Read())
            {
                CustomerAddressList myRecord = new CustomerAddressList();
                myRecord.codigo = result[0].ToString();
                myRecord.descripcion = result[1].ToString();
                myList.Add(myRecord);
            }
            conn.Close();conn.Dispose();
            return myList.ToArray();
        }
    }
}
