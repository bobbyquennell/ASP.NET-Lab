using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using System.Web;

namespace OdeToFood.Tests
{
    class FakeControllerContext:ControllerContext
    {
        public override HttpContextBase HttpContext
        {
            get
            {
                return new FakeHttpContext();
                
            }
            set
            {
                base.HttpContext = value;
            }
        }
    }
}
