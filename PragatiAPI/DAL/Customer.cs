//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace PragatiAPI.DAL
{
    using System;
    using System.Collections.Generic;
    
    public partial class Customer
    {
        public int CustomerID { get; set; }
        public string CustomerName { get; set; }
        public string BillingAddress { get; set; }
        public string ShippingAddress { get; set; }
        public string Vat { get; set; }
        public string Cst { get; set; }
        public string ImagePath { get; set; }
        public Nullable<int> CustomerType { get; set; }
        public bool IsDeleted { get; set; }
    }
}
