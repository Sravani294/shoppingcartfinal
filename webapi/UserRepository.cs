using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebAPI.Models;

namespace WebAPI.Repository
{
    public class UserRepository : IDataRepository<UserTable>
    {
        Shopping_ZoneEntities _userdbcontext;
        public UserRepository(Shopping_ZoneEntities userdbcontext)
        {
            _userdbcontext = userdbcontext;



        }
        public void Add(UserTable newuser)
        {
            _userdbcontext.UserTables.Add(newuser);
            _userdbcontext.SaveChanges();
        }
        public IEnumerable<UserTable> GetAll()
        {
            return _userdbcontext.UserTables.ToList();
        }
    }
}




    