using DurableTask.Core.Common;
using Microsoft.Azure.Documents;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebAPI.Models;

namespace WebAPI.Repository
{
    public class LoginRepo : ILoginRepo
    {
        Shopping_ZoneEntities _LoginEntities = null;
        public UserTable VerifyLogin(string emailID, string Password)
        {
            UserTable userTable = null;
            try
            {
                var checkValidUser = _LoginEntities.UserTables.Where(m => m.EmailID == emailID && m.Password == Password).FirstOrDefault();
                if (checkValidUser != null)
                {
                    userTable = checkValidUser;
                }



                else
                {
                    userTable = null;
                }
            }
            catch (Exception ex)
            {
            }
            return userTable;
        }



        public LoginRepo(Shopping_ZoneEntities loginentities)
        {
            this._LoginEntities = loginentities;
        }



    }
}
