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
    
    public partial class InvoiceMaster
    {
        public int InvoiceID { get; set; }
        public int CustomerID { get; set; }
        public string InvoiceNo { get; set; }
        public string OrderNo { get; set; }
        public Nullable<System.DateTime> OrderDate { get; set; }
        public string ChallanNo { get; set; }
        public Nullable<System.DateTime> InvoiceDate { get; set; }
        public Nullable<decimal> GrossTotal { get; set; }
        public Nullable<bool> IsVat { get; set; }
        public Nullable<bool> IsCST { get; set; }
        public Nullable<double> VatPercentage { get; set; }
        public Nullable<decimal> VatAmount { get; set; }
        public Nullable<decimal> AmountAfterVat { get; set; }
        public Nullable<double> DiscountPercentage { get; set; }
        public Nullable<decimal> DiscountAmount { get; set; }
        public Nullable<decimal> AmountAfterDiscount { get; set; }
        public Nullable<int> RoundOff { get; set; }
        public Nullable<decimal> NetToal { get; set; }
        public Nullable<System.DateTime> DueDate { get; set; }
        public Nullable<int> BalAmount { get; set; }
        public Nullable<bool> IsDeleted { get; set; }
    }
}
