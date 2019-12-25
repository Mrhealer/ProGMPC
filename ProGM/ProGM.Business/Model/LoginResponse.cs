using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProGM.Business.Model
{
    public class LoginResponse
    {
        public Result[] result { get; set; }
    }

    public class Result
    {
        public string status { get; set; }
        public string strId { get; set; }
        public string strCompanyId { get; set; }
        public string strName { get; set; }
        public string strPhoneNumber { get; set; }
        public string strEmail { get; set; }
        public string strFullName { get; set; }
        public string strAvatar { get; set; }
        public string strCityId { get; set; }
        public string strAddress { get; set; }
        public string iActive { get; set; }
        public string iVerifyStatus { get; set; }
        public string iIsEmployee { get; set; }
        public string strCreatedDate { get; set; }
        public string strModifiedDate { get; set; }
        public string strRoleId { get; set; }
        public string strRoleName { get; set; }
        public string strRoleDesc { get; set; }
        public string dBalance { get; set; }
    }

}
