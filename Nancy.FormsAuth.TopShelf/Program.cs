using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Topshelf;

namespace NcyFormsAuthWithTopShelf
{
    class Program
    {
        static void Main(string[] args)
        {
            HostFactory.Run(x =>
            {
                x.Service<NancyService>(s =>
                {
                    s.ConstructUsing(server => new NancyService("http://localhost:3579"));
                    s.WhenStarted(ns => ns.Start());
                    s.WhenStopped(ns => ns.Stop());
                });

                x.RunAsLocalSystem();
                x.SetDisplayName("Nancy Service");
                x.SetServiceName("NancyService");
                x.SetDescription("NancyService.");

            });
        }
    }
}
