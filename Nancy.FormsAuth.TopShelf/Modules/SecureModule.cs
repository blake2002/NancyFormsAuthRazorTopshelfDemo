using System;
using Nancy;
using Nancy.Security;
using Nancy.Session;
using System.Dynamic;

namespace NcyFormsAuthWithTopShelf.Modules
{
    public class SecureModule : NancyModule
    {
        public SecureModule()
        {
            this.RequiresAuthentication();

            Get["/secure"] = p =>
                {
                    dynamic model = new ExpandoObject();
                    model.username = this.Request.Session["username"];
                    model.password = this.Request.Session["password"];
                    return View["Secure.html", model];
                };
        }
    }
}
