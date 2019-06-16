using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PragatiAPI.Models
{
    public class UserModel
    {
        public string UserId { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Token { get; set; }
        public DateTime? Expiration { get; set; }
        public List<Role> RoleList { get; set; }
    }
}