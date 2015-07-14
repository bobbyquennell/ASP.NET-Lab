using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;

namespace OdeToFood.Tests
{
    class FakeHttpContext:HttpContextBase
    {
        public override HttpRequestBase Request
        {
            get
            {
                return new FakeHttpRequest();
            }
        }
    }
}
