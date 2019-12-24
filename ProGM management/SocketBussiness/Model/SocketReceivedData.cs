using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocketBussiness.Model
{
    public class SocketReceivedData
    {
        public string msgFrom { get; set; }
        public string msgTo { get; set; }
        public string msg { get; set; }
        public string type { get; set; }
        public string macAddressFrom { get; set; }
    }
}
