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
    // [EnableCors(origins: "http://localhost:4200", headers: "*", methods: "*")]
  //  [RoutePrefix("api/Customer")]
    public class CustomerController : ApiController
    {
        private CustomerDAL db = new CustomerDAL();

        // DELETE api/Customer/5
        // [Route("delete/{id}")]
         [HttpDelete]
        [ResponseType(typeof(CustomerModel))]
        // [ActionName("DeleteCustomer")]
        public IHttpActionResult DeleteCustomer(int id)
        {
            int idd = 0;
            bool Isdeleted = db.DeleteCustomer(idd);
            return Ok(Isdeleted);
        }

        // GET api/Customer
         [ActionName("Customer")]
         [CustomAuthorizeAttribute("Admin","Article")]
        public List<CustomerModel> GetCustomers()
        {
            return db.GetCustomer();
        }

        // GET api/Employee/5
       // [ResponseType(typeof(CustomerModel))]
        //[Route("api/{customers}/{id}")]
        [HttpGet]
        [ActionName("Customers")]
       // [Route("delete/{id}")]
        public IHttpActionResult GetCustomer(string id)
        {
            CustomerModel model = new CustomerModel();
            model = db.GetCustomer(Convert.ToInt16(id)).FirstOrDefault();
            return Ok(model);
        }

        // PUT api/Customer/5
        public IHttpActionResult PutCustomer(int id, CustomerModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != model.CustomerID)
            {
                return BadRequest();
            }

            try
            {
                db.AddCustomer(model);
            }
            catch (Exception ex)
            {

            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST api/Customer
        [ResponseType(typeof(CustomerModel))]
        public IHttpActionResult PostCustomer(CustomerModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.AddCustomer(model);
            return CreatedAtRoute("DefaultApi", new { id = model.CustomerID }, model);
        }

      

        protected override void Dispose(bool disposing)
        {

            base.Dispose(disposing);
        }
        [HttpGet]
       // [Route("api/{customers}")]
        [ActionName("CustomerType")]
        public IHttpActionResult GetCustomerTypes()
        {
            List<CustomerTypeModel> model = new List<CustomerTypeModel>();
            model = db.GetCustomerType();
            return Ok(model);
        }
        // [Route("api/{customers}")]
         [HttpGet]
        [ActionName("CustomerByType")]
        public IHttpActionResult GetCustomerByTypes(int CustomerTypeId)
        {
            List<CustomerModel> model = new List<CustomerModel>();
            model = db.GetCustomerByCustomerType(CustomerTypeId);
           return Ok(model);

            //var message = new HttpResponseMessage(HttpStatusCode.BadRequest)
            //{
            //    Content = new StringContent("We cannot use IDs greater than 100.")
            //};

            //throw new HttpResponseException(message);
        }
       


    }
}