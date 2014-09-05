using Nancy.Security;
using System.Collections.Generic;

namespace NcyFormsAuthWithTopShelf.Models
{
    public class MyUserIdentity : IUserIdentity
    {
        public IEnumerable<string> Claims
        {
            get;
            set;
        }

        public string UserName
        {
            get;
            set;
        }
    }
}
