using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Management.Model
{
    public class ListComputerbyOfficeId
    {
        public string pcCode { get; set; }
        public string pcName { get; set; }
        public string pcMacAddress { get; set; }
        public string pcPrice { get; set; }
        public string pcGroupId { get; set; }
        public string pcGroupCode { get; set; }
        public string pcGroupName { get; set; }
        public string branchId { get; set; }
        public string branchCode { get; set; }
        public string branchName { get; set; }
        public string branchAddress { get; set; }
        public string branchPhone { get; set; }
    }

    public class responseListPC
    {
        public List<ListComputerbyOfficeId> listComputerbyOfficeId { get; set; }
    }
}
