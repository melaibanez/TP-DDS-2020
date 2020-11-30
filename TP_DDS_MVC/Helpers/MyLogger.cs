using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TP_DDS_MVC.Helpers
{
    public static class MyLogger
    {
        public static void log(Object obj)
        {
            System.Diagnostics.Debug.WriteLine(obj.ToString());
        }
        public static void log(String msg)
        {
            System.Diagnostics.Debug.WriteLine(msg);
        }
    }
}