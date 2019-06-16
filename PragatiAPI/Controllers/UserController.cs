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
    public class UserController : ApiController
    {
        private UsersDAL db = new UsersDAL();

        // POST api/Customer
        [ResponseType(typeof(UserModel))]
        [HttpPost]
        public IHttpActionResult Authenticate( UserModel model)
        {           
            model.Password = "sumit";
            model.UserId = "sumit";
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            model=db.Authenticate(model);
            //Request.CreateResponse<IEnumerable<UserModel>>(HttpStatusCode.OK, db.Authenticate(model));
            return Ok(model);
        }

    }
}
