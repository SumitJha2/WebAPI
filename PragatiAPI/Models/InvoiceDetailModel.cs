using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PragatiAPI.Models
{
    public class InvoiceDetailModel
    {
        public int InvoiceDetailID {get;set;}
        public int InvoiceMasterID {get;set;}
        public string Particular {get;set;}
        public float? Length {get;set;}
        public float? Width {get;set;}
        public int? Qty {get;set;}
        public float? Rate {get;set;}
        public decimal? Amount {get;set;}
         public bool? IsDeleted {get;set;}
    }
}