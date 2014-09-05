using Microsoft.Owin.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NcyFormsAuthWithTopShelf
{
    public class NancyService
    {
        IDisposable WebApplication;
        private readonly string _url;
        public NancyService(string url)
        {
            _url = url;
        }

        public void Start()
        {
            WebApplication = WebApp.Start<Startup>(_url);
        }

        public void Stop()
        {
            WebApplication.Dispose();
        }
    }
}
