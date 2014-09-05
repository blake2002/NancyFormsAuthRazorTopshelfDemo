using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NcyFormsAuthWithTopShelf
{
    public class OwinLogger
    {
        private readonly Func<IDictionary<string, object>, Task> _next;

        public OwinLogger(Func<IDictionary<string, object>, Task> next)
        {
            if (next == null) throw new ArgumentNullException("next");
            _next = next;
        }

        public Task Invoke(IDictionary<string, object> environment)
        {
            foreach (var item in environment)
            {
                System.Diagnostics.Trace.WriteLine(string.Format("{0} - {1}", item.Key, environment[item.Key]));
            }

            return _next(environment);
        }
    }
}
