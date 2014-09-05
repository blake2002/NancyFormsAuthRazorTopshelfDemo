using System.Dynamic;
using Nancy;
using Nancy.Authentication.Forms;
using System;

namespace NcyFormsAuthWithTopShelf.Modules
{
    public class LoginModule : NancyModule
    {
        public LoginModule()
        {
            Get["/login"] = p =>
                {
                    dynamic model = new ExpandoObject();
                    model.Errored = false;
                    return View["Login"];
                };

            Get["/logout"] = parameters =>
            {
                //Request.Session.DeleteAll();
                // Called when the user clicks the sign out button in the application. Should
                // perform one of the Logout actions (see below)

                return this.LogoutAndRedirect("~/");

            };

            //Post["/login", true] = async (x, ctx) =>
            Post["/login"] = p =>
            {
                var username = (string)this.Request.Form.username;
                var password = (string)this.Request.Form.password;

                if(username == "admin" && password == "admin")
                {
                    this.Request.Session["user"] = username;
                    this.Request.Session["password"] = password;

                    var guidID = Guid.NewGuid();
                    var expiry = DateTime.Now.AddDays(7);
                    return this.LoginAndRedirect(guidID, expiry, "/secure");
                }

                else
                {
                    dynamic model = new ExpandoObject();
                    model.Errored = true;
                    model.username = username;
                    return View["Login", model];
                }


            };
        }
    }
}
