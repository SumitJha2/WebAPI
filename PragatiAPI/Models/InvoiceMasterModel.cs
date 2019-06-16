using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PragatiAPI.Models
{
    public class InvoiceMasterModel
    {
        public int InvoiceID {get;set;}
        public int CustomerID { get; set; }
        public string InvoiceNo { get; set; }
        public string OrderNo { get; set; }
        public DateTime? OrderDate { get; set; }
        public string ChallanNo { get; set; }
        public DateTime? InvoiceDate { get; set; }
     
        public decimal? NetTotal { get; set; }
     
        public bool? IsDeleted { get; set; }
        public string CustomerName { get; set; }
        public List<InvoiceDetailModel> InvoiceDetailList { get; set; }
        public List<CustomerModel> CustomerList { get; set; }
        
    }
}