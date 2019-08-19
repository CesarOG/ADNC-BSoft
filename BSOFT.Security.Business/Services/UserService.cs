using BSOFT.Security.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BSOFT.Security.Business.Services
{
    public class UserService : IUserService
    {
        private DbSecurityContext _context;
        public UserService(DbSecurityContext context)
        {
            _context = context;
        }
        public bool ValidateUser(string userName, string password)
        {
            var user = _context.tbl_user.Where(x => x.Username == userName && x.Password == password).FirstOrDefault();
            if (user != null)
            {
                return true;
            }
            return false;
        }
    }
}
