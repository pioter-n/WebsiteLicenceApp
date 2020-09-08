using System;
using System.Collections.Generic;
using System.Net;
using System.Text;

namespace LicenceApp
{
    static class InternetConnection
    {
        static public bool Connection
        {
            get
            {
                try
                {
                    using (var client = new WebClient())
                    using (var stream = client.OpenRead("http://www.google.com"))
                    {
                        return true;
                    }
                }
                catch
                {
                    return false;
                }
            }
        }
    }
}
