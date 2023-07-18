using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TOL.Customers;
using TOL.BusinessPartner;
using TOL.Contacts;
using TOL._Persons;

namespace BLL
{
    public class Customers
    {
        public Customer getCustomerById(string id)
        {
            DAL.businessPartners dal = new DAL.businessPartners();
            BusinessPartner myBusinessPartner = dal.getBusinessPartnerById(id);

            Customer myCustomer = null;
            if (myBusinessPartner != null)
            {
                myCustomer = new Customer();
                myCustomer.Codigo_Cliente = myBusinessPartner.Codigo_Cliente;
                myCustomer.Nombre_Cliente = myBusinessPartner.Nombre_Cliente;
                myCustomer.contactoCodigo = myBusinessPartner.contactoCodigo;
                myCustomer.contactoNombre = myBusinessPartner.Persona_contacto;
                myCustomer.Moneda = myBusinessPartner.Moneda;
                myCustomer.Numero_Referencia = myBusinessPartner.Numero_Referencia;
                myCustomer.direccionDestinoCodigo = myBusinessPartner.codigoDireccionDestino;
                myCustomer.Direccion_Destino = myBusinessPartner.Direccion_Destino;
                myCustomer.direccionFacturaCodigo = myBusinessPartner.codigoDireccionFactura;
                myCustomer.Direccion_Factura = myBusinessPartner.Direccion_Factura;
                myCustomer.condicionPagoCodigo = myBusinessPartner.codigoCondicionPago;
                myCustomer.Condicion_pago = myBusinessPartner.Condicion_pago;
                myCustomer.CodSerie = myBusinessPartner.CodSerie;
                myCustomer.Correlativo = myBusinessPartner.Correlativo;
                myCustomer.Cod_Lista_Precio = myBusinessPartner.Cod_Lista_Precio;
            }
            return myCustomer;
        }   
        public CItem[] getCustomerList()
        {
            //Customer myCustomer = new Customer();
            List<CItem> myCustomers = new List<CItem>();
            DAL.businessPartners Dal = new DAL.businessPartners();
            BPItem[] myList = Dal.getBusinessPartnerList();
            foreach (BPItem item in myList)
            {
                CItem myCustomer = new CItem();
                myCustomer.Codigo_Cliente = item.Codigo_CLiente;
                myCustomer.Nombre_Cliente = item.Nombre_Cliente;
                myCustomers.Add(myCustomer);
            }
            return myCustomers.ToArray();
        }

        public ContactItem[] getPersonContactsList(string id)
        {
            List<ContactItem> myContacts = new List<ContactItem>();
            DAL.businessPartners Dal = new DAL.businessPartners();
            PersonItem[] myList = Dal.getPersonsByBusinessPartnerId(id);
            foreach (PersonItem item in myList)
            {
                ContactItem myCustomer = new ContactItem();
                myCustomer.codigo = item.codigo;
                myCustomer.nombreCompleto = item.descripcion;
                myContacts.Add(myCustomer);
            }
            return myContacts.ToArray();
        }
        public CustomerAddressList[] GetCustomerAddressList(string addressType, string customerId)
        {
            CustomerAddressList[] myArray;
            DAL.businessPartners dal = new DAL.businessPartners();
            myArray = dal.getBusinessPartnerAddressByType(addressType, customerId);
            return myArray;
        }
    }
}
