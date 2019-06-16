using PragatiAPI.DAL;
using PragatiAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using System.Web.Http.Controllers;
using System.Web.Mvc;

namespace PragatiAPI
{
    public class CustomAuthorizeAttribute : System.Web.Http.AuthorizeAttribute  
    {
        //Entities context = new Entities(); // my entity  
        private readonly string[] allowedroles;
        public CustomAuthorizeAttribute(params string[] roles)
        {
            this.allowedroles = roles;
        }
        
        public override void OnAuthorization(HttpActionContext actionContext)
        {

            if (!IsAuthorized(actionContext))
            {
               HandleUnauthorizedRequest(actionContext);
            }
        }
        protected override bool IsAuthorized(HttpActionContext actionContext)
        {
            bool IsAuthorized = false;
           // string _token = actionContext.Request.Headers.Authorization.Parameter;
            string _token = actionContext.Request.Headers.GetValues("token").FirstOrDefault();
            if (!string.IsNullOrEmpty(_token))
            { 
                // check for valid token
                UsersDAL repo=new UsersDAL();
                UserModel model = repo.ValidateToken(_token);
                if (model != null)
                {
                    IsValidRole(model);
                }
            }


            return IsAuthorized;
        }
        private bool IsValidRole(UserModel model)
        {
            bool IsValid = false;
            foreach(var role in allowedroles)
            {
                if (model.RoleList.Where(x => x.RoleName == role).ToList().Any())
                {
                    IsValid = true;
                    break;
                }
            }
            return IsValid;
        }
        protected override void HandleUnauthorizedRequest(HttpActionContext actionContext)
        {
            var message = new System.Net.Http.HttpResponseMessage(System.Net.HttpStatusCode.Unauthorized);
            message.Headers.Add("Add-Authenticate","Forms");
            message.Content=new StringContent("You are unauthorized to access this resource");
            throw new HttpResponseException(message);
        }
        
       
    }
}