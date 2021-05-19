using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EShopWebAPI.Models
{
    public class OrderKPI
    {
        int orderID;
        int productID;
        string productName;

        public int OrderID { get => orderID; set => orderID = value; }
        public int ProductID { get => productID; set => productID = value; }
        public string ProductName { get => productName; set => productName = value; }
    }
}