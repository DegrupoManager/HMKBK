using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TOL.Products;
using TOL._Warehouses;
using TOL.Storages;
namespace BLL
{
    public class products
    {
        public Product getProductById(string id, string lpId)
        {
            Product myProducto = null;
            DAL.Items dal = new DAL.Items();
            Item myItem = dal.getItemById(id, lpId);
            if(myItem != null)
            {
                myProducto = new Product();
                myProducto.CodigoArticulo = myItem.CodigoArticulo;
                myProducto.CodigoBarra = myItem.CodigoBarra;
                myProducto.StorageDefaultId = myItem.storageDefaultId;
                myProducto.DescripcionArticulo = myItem.DescripcionArticulo;
                myProducto.precio = myItem.precio;
           
            }
            return myProducto;
        }
        public PItem[] getProductList()
        {
            //Customer myCustomer = new Customer();
            List<PItem> myProducts = new List<PItem>();
            DAL.Items dal = new DAL.Items();
            IItem[] myList = dal.getItemList();
            foreach (IItem item in myList)
            {
                PItem myProduct = new PItem();
                myProduct.CodigoArticulo = item.CodigoArticulo;
                myProduct.DescripcionArticulo = item.DescripcionArticulo;
                myProducts.Add(myProduct);
            }
            return myProducts.ToArray();
        }

        public SItem[] getStoragesByProductId(string id)
        {
            List<SItem> myStorages = new List<SItem>();
            DAL.Items dal = new DAL.Items();
            WItem[] myList = dal.getWarehouseByItemId(id);
            foreach (WItem item in myList)
            {
                SItem myItem = new SItem();
                myItem.storageId = item.warehouseCode;
                myStorages.Add(myItem);
            }
            return myStorages.ToArray();
        }
    }
}
