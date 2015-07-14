using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;

namespace OdeToFood.Tests
{
    class FakeHttpRequest: HttpRequestBase
    {
        public override string this[string key]
        {
            get
            {
                return null;
            }
        }
        public override System.Collections.Specialized.NameValueCollection Headers
        {
            get
            {
                return new System.Collections.Specialized.NameValueCollection();
            }
        }
       
    }
}
