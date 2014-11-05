using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http.WebHost;
using System.Web.Routing;
using System.Web.SessionState;

namespace UCsoft.Web.Handlers
{
   public class SessionableControlHandler : HttpControllerHandler, IRequiresSessionState
    {
        public SessionableControlHandler(RouteData routeData)
            : base(routeData)
        {
        }
    }
}