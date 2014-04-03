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
            routes.MapPageRoute("Default", "", "~/Pages/RecordPages/List.aspx");
            routes.MapPageRoute("Records", "skivor", "~/Pages/RecordPages/List.aspx");
            routes.MapPageRoute("RecordDetails",    "skivor/{id}",              "~/Pages/RecordPages/Details.aspx");
            routes.MapPageRoute("RecordDelete",     "skivor/{id}/tabort",       "~/Pages/RecordPages/Delete.aspx");
            routes.MapPageRoute("NewDigital",       "skivor/ny/digital",        "~/Pages/RecordPages/NewDigital.aspx");
            routes.MapPageRoute("NewPhysical",      "skivor/ny/fysisk",         "~/Pages/RecordPages/NewPhysical.aspx");
            routes.MapPageRoute("EditRecord",       "skivor/{id}/redigera",     "~/Pages/RecordPages/EditRecord.aspx");
            routes.MapPageRoute("AddInfo",          "skivor/{id}/laggtillinfo", "~/Pages/RecordPages/AddInfo.aspx");
            routes.MapPageRoute("Error  ",          "serverfel",                "~/Pages/Shared/Error.aspx");
           
           
        }
    }
}
