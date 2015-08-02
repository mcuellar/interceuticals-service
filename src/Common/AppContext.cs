using Spring.Context;
using Spring.Context.Support;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace InterceuticalsService.Common
{
    public sealed class AppContext
    {
        private static AppContext instance = new AppContext();
        private static IApplicationContext context;

        public static AppContext Instance
        {
            get { return instance; }
        }

        private AppContext()
        {
            context = new XmlApplicationContext(System.Configuration.ConfigurationManager.AppSettings["ApplicationContext"]);
            //apiResponses = (Responses)context.GetObject("apiResponses");
        }


        public static object GetSpringObject(string name)
        {
            return context.GetObject(name);
        }

        //public static HelpDeskConfig GetHDConfig()
        //{
        //    return (HelpDeskConfig)context.GetObject("hdConfig");
        //}


    }
}