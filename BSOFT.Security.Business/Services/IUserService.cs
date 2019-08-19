using System;
using System.Collections.Generic;
using System.Text;

namespace BSOFT.Security.Business.Services
{
    public interface IUserService
    {
        bool ValidateUser(string userName, string password);
    }
}
