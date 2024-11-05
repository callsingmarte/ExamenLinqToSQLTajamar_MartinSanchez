using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.SessionState;
using System.Web.UI;

namespace Ex_LinqToSql_MartinSanchez
{
    public class Global : System.Web.HttpApplication
    {
        protected void Application_Start(object sender, EventArgs e)
        {
            //Agregar el mapeo de ScripResource para JQuery
            ScriptManager.ScriptResourceMapping.AddDefinition("jquery", new ScriptResourceDefinition
            {
                Path = "~/Scripts/jquery-3.6.0.min.js", // Cambia la ruta si es diferente en tu proyecto
                DebugPath = "~/Scripts/jquery-3.6.0.js", // Cambia la ruta de depuración si es necesario
                CdnPath = "https://ajax.googleapis.com/ajax/libs/jquery/3.6.0/jquery.min.js",
                CdnDebugPath = "https://ajax.googleapis.com/ajax/libs/jquery/3.6.0/jquery.js",
                LoadSuccessExpression = "window.jQuery"
            });
        }
    }
}