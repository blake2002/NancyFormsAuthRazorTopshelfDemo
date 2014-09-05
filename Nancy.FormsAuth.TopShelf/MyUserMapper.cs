using Nancy;
using Nancy.Authentication.Forms;
using NcyFormsAuthWithTopShelf.Models;
using Nancy.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NcyFormsAuthWithTopShelf
{
    public class MyUserMapper : IUserMapper
    {
        public IUserIdentity GetUserFromIdentifier(Guid identifier, NancyContext context)
        {
            return new MyUserIdentity() { UserName = "admin", Claims = new List<string> { "admin" } };
        }
    }
}
