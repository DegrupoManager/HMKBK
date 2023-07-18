using Sap.Data.Hana;
using System.Collections.Generic;
using TOL._Warehouses;
using TOL.Products;

namespace DAL
{
    public class Items
    {
        public Item getItemById(string id, string lpId)
        {
            Item myItem = null;

            HanaConnection conn = new HanaConnection(AccesoDatos.Cadena);
            conn.Open();

            HanaCommand cmd = new HanaCommand("SELECT " +
                "\"CodigoArticulo\", " +
                "\"DescripcionArticulo\", " +
                "\"CodigoAlmacenPredeterminado\", " +
                "\"CodigoBarra\", " +
                "\"Precio\" " +
                "FROM \"_SYS_BIC\".\"DPG_Web/DGP_GET_ITEM_COD\"(" +
                "'PLACEHOLDER' = ('$$CodArt$$', '" + id + "')," +
                "'PLACEHOLDER' = ('$$CodListaPrecio$$','" + lpId + "'))", conn);
            cmd.CommandType = System.Data.CommandType.Text;

            HanaDataReader result = cmd.ExecuteReader();
            if (result.Read())
            {
                myItem = new Item();
                myItem.CodigoArticulo       = result[0].ToString();
                myItem.DescripcionArticulo  = result[1].ToString();
                myItem.storageDefaultId = result[2].ToString();
                myItem.CodigoBarra          = result[3].ToString();
                myItem.precio = result[4].ToString();
            }
            conn.Close();
            conn.Dispose();
            return myItem;
        }
        public IItem[] getItemList()
        {
            List<IItem> myList = new List<IItem>();

            HanaConnection conn = new HanaConnection(AccesoDatos.Cadena);

            conn.Open();

            HanaCommand cmd = new HanaCommand("SELECT * FROM \"_SYS_BIC\".\"DPG_Web/DGP_GET_LIST_ITEM\"", conn);
            cmd.CommandType = System.Data.CommandType.Text;

            HanaDataReader result = cmd.ExecuteReader();
            while (result.Read())
            {
                IItem myRecord = new IItem();
                myRecord.CodigoArticulo         = result[0].ToString();
                myRecord.DescripcionArticulo    = result[1].ToString();
                myList.Add(myRecord);
            }
            conn.Close();
            conn.Dispose();
            return myList.ToArray();
        }
        public WItem[] getWarehouseByItemId(string id)
        {
            List<WItem> myList = new List<WItem>();

            HanaConnection conn = new HanaConnection(AccesoDatos.Cadena);
            conn.Open();

            HanaCommand cmd = new HanaCommand("SELECT * FROM \"_SYS_BIC\".\"DPG_Web/DGP_GET_ITEM_STORE\"('PLACEHOLDER' = ('$$ItemCode$$', '" + id + "'))", conn);
            cmd.CommandType = System.Data.CommandType.Text;

            HanaDataReader result = cmd.ExecuteReader();
            while (result.Read())
            {
                WItem myRecord = new WItem();
                myRecord.warehouseCode = result[0].ToString();
                myList.Add(myRecord);
            }
            conn.Close();
            conn.Dispose();
            return myList.ToArray();
        }
    }
}
