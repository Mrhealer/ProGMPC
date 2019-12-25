using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProGM.Management.Model
{
    public class ComputerList
    {
        public string strId { get; set; }
        public string strGroupId { get; set; }
        public string strName { get; set; }
        public string strLocalIp { get; set; }
        public string strMacAddress { get; set; }
        public string strComment { get; set; }
        public string iActive { get; set; }
        public string strCreatedDate { get; set; }
        public string strCreatedByAccountId { get; set; }
        public string strModifiedDate { get; set; }
        public string strModifiedByAccountId { get; set; }
        public string strCompanyId { get; set; }
        public string strGroupName { get; set; }
        public string strDesc { get; set; }
        public string iPrice { get; set; }
    }

    public class responseListPC
    {
        public List<ComputerList> computerList { get; set; }
    }
}
