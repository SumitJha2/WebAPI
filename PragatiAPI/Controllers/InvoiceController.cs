using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using PragatiAPI.Models;
using PragatiAPI.DAL;
using System.Web.Http.Description;
using System.Web.Http.Cors;
using System.Web;


namespace PragatiAPI.Controllers
{
    public class InvoiceController : ApiController
    {
        private InvoiceDAL db = new InvoiceDAL();
        // GET api/Customer
        [ActionName("GetInvoice")]
        public List<InvoiceMasterModel> GetInvoice()
        {
            return db.GetInvoice(0);
            
        }
        [ActionName("GetInvoiceWithDetail")]
        public InvoiceMasterModel GetInvoiceWithDetail(int invoiceId)
        {
            return db.GetInvoiceWithDetail(invoiceId);
        }  
        // POST api/Customer
        [ResponseType(typeof(InvoiceMasterModel))]
        [HttpPost]
        public IHttpActionResult PostInvoice(InvoiceMasterModel model)
        {
            db.AddInvoice(model);
            return CreatedAtRoute("DefaultApi", new { id = model.CustomerID }, model);
        }
    }
}
