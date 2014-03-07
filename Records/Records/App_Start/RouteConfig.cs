using System;
using System.Collections.Generic;
using System.Web;
using System.Web.Routing;
using Microsoft.AspNet.FriendlyUrls;

namespace Records
{
    public static class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.MapPageRoute("Records",      "skivor",        "~/Pages/RecordPages/List.aspx");
            routes.MapPageRoute("RecordDetails", "skivor/{id}",     "~/Pages/RecordPages/Details.aspx");
            routes.MapPageRoute("RecordDelete", "skivor/{id}/tabort", "~/Pages/RecordPages/Delete.aspx");
        }
    }
}
