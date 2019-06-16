using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PragatiAPI.Models
{
    public class CustomerModel
    {
        public int CustomerID { get; set; }
        public string CustomerName { get; set; }
        public string BillingAddress { get; set; }
        public string ShippingAddress { get; set; }
        public string VAT { get; set; }
        public string GST { get; set; }
        public string ImagePath { get; set; }
        public string domainPath { get; set; }
        public int? CustomerTypeID { get; set; }
        public string CustomerType { get; set; }
        public bool ISDeleted { get; set; }
        //public List<CustomerTypeModel> CustomerTypes { get; set; }
    }
}