using System;
using System.Diagnostics;
using System.Net;
using System.Net.NetworkInformation;

namespace AgnaPanel
{
    public class Net
    {
        public static bool InternetConnection => Ping("www.google.com");

        public static string GetHTML(string url)
        {
            if (InternetConnection)
            {
                WebClient webClient = new WebClient();
                try
                {
                    return webClient.DownloadString(url);
                }
                catch (Exception)
                {
                    return String.Empty;
                }
            }
            else
            {
                return String.Empty;
            }
        }

        public static bool Ping(string url)
        {
            using (Ping ping = new Ping())
            {
                try
                {
                    if (ping.Send(url).Status == IPStatus.Success)
                        return true;
                    else
                        return false;
                }
                catch (Exception)
                {
                    return false;
                }
            }
        }
    }
}