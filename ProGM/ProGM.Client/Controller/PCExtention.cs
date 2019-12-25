using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;

namespace ProGM.Client
{
    class PCExtention
    {
        public static string GetMacId()
        {
            var macAddr =
            (
                from nic in NetworkInterface.GetAllNetworkInterfaces()
                where nic.OperationalStatus == OperationalStatus.Up
                select nic.GetPhysicalAddress().ToString()
            ).FirstOrDefault();



            string mac = "";
            int dem = 1;
            for (int i = 0; i < macAddr.Length; i++)
            {
                if (dem == 2 && i != macAddr.Length - 1)
                {
                    mac += macAddr[i] + ":";
                    dem = 0;
                }
                else
                {
                    mac += macAddr[i];
                }
                dem++;
            }
            mac = mac.ToLower();
            return mac;
        }
    }
}
