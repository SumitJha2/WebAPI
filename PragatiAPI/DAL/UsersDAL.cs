using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using PragatiAPI.Models;

namespace PragatiAPI.DAL
{
    public class UsersDAL
    {
        PragatiEntities context = new PragatiEntities();
        public UserModel Authenticate(UserModel model)
        {
            UserModel userWithRoles = new UserModel();
            var user = context.Users.Where(x => x.UserId == model.UserId && x.Password == model.Password).FirstOrDefault();
                     

            if(user!=null)
            {
                // update tokens
                user.Token = "SUMIT_123";
                context.SaveChanges();

                userWithRoles.UserId = user.UserId;
                userWithRoles.Token = "SUMIT_123";  

                List<PragatiAPI.Models.Role> lstRole = new List<PragatiAPI.Models.Role>();
                lstRole=(from usrRole in context.User_Role
                                   join rle in context.Roles
                                   on usrRole.RoleId equals rle.Id
                                     where usrRole.UserId == user.Id
                                   select new PragatiAPI.Models.Role
                                    {
                                       RoleId = rle.Id,
                                       RoleName=rle.RoleName
                                    }).ToList();
                userWithRoles.RoleList = lstRole;
                                
            }
            return userWithRoles;
        }
        
        public UserModel ValidateToken(string token)
        {
            UserModel userWithRoles = new UserModel();
            var user = context.Users.Where(x => x.Token == token).FirstOrDefault();
            if (user != null)
            {
                userWithRoles.UserId = user.UserId;
                userWithRoles.Token = token;

                if (user != null)
                {

                    List<PragatiAPI.Models.Role> lstRole = new List<PragatiAPI.Models.Role>();
                    lstRole = (from usrRole in context.User_Role
                               join rle in context.Roles
                               on usrRole.RoleId equals rle.Id
                               where usrRole.UserId == user.Id
                               select new PragatiAPI.Models.Role
                               {
                                   RoleId = rle.Id,
                                   RoleName = rle.RoleName
                               }).ToList();
                    userWithRoles.RoleList = lstRole;

                }
                return userWithRoles;
            }
            else
                return null;
        }

    }
}