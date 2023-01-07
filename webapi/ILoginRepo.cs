using WebAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Azure.Documents;


namespace WebAPI.Repository
{
    internal interface ILoginRepo
    {
     UserTable VerifyLogin(string EmailID, string Password);
    }
}
