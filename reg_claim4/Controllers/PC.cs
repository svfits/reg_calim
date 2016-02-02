using System;
using System.Net;

namespace reg_claim4.Controllers
{
    static class PC
    {
        static public string GetIPAddress()
        {
            string IPAddress = "";
            IPHostEntry Host = default(IPHostEntry);
            string Hostname = null;
            Hostname = System.Environment.MachineName;
            Host = Dns.GetHostEntry(Hostname);
            foreach (IPAddress IP in Host.AddressList)
            {
                if (IP.AddressFamily == System.Net.Sockets.AddressFamily.InterNetwork)
                {
                    IPAddress = Convert.ToString(IP);
                }
            }
            return IPAddress;

        }

        static public string GetNamePC()
        {
            string GetNamePC = "";
            return GetNamePC;
        }
    }
}
