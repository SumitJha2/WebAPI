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
    
    public partial class PaymentMaster
    {
        public int PaymentID { get; set; }
        public int CustomerID { get; set; }
        public string ChequeNo { get; set; }
        public int ChequeAmount { get; set; }
        public string BankName { get; set; }
        public bool IsDeleted { get; set; }
    }
}
