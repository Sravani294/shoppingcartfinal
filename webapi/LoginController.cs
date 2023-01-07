using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebAPI.Models;
using WebAPI.Repository;
using Microsoft.Azure.Documents;
using System.Web.UI.WebControls;

namespace WebAPI.Controllers
{
    [RoutePrefix("api/Login")]
    public class LoginController : ApiController
    {
        private LoginRepo _Loginrepo;
        public LoginController()
        {
            this._Loginrepo = new LoginRepo(new Shopping_ZoneEntities());
        }





        [HttpPost]
        [HttpGet]

        public IHttpActionResult VerifyLogin(Loginuser objlogin)
        {
            UserTable userTable = null;
            try
            {
                userTable = _Loginrepo.VerifyLogin(objlogin.EmailID, objlogin.Password);




                if (userTable != null)
                {
                    //return NotFound();
                    return Ok(userTable);



                }



            }
            catch (Exception ex)
            {



            }



            //return Ok(customer);
            return NotFound();



        }
    }
}

 
    

