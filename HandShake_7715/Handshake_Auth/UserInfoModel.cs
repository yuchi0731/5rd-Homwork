using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Handshake_Auth
{
    public class UserInfoModel
    {
        //和DB裡的欄位一致
        public string ID { get; set; }
        public string Account { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string UserLevel { get; set; }

        public string CreateDate { get; set; }

        public string PWD { get; set; }

    }
}
