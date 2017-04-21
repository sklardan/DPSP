using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DPSP_UI_LG
{
    public static class Configuration
    {
        public static string DPSP_API_SERVER => System.Configuration.ConfigurationManager.AppSettings["DPSP_API_SERVER"];
    }
}