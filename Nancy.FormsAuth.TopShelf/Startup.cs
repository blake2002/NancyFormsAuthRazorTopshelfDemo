using Owin;

namespace NcyFormsAuthWithTopShelf
{
    public class Startup
    {
        public void Configuration(IAppBuilder application)
        {

            application
                .Use(typeof(OwinLogger))
                .UseNancy();
        }
    }
}
