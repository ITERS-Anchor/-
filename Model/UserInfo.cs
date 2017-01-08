using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class UserInfo
    {
        private int _userId;
        private string _userName;
        private string _userPwd;

        public int UserId
        {
            get
            {
                return _userId;
            }

            set
            {
                _userId = value;
            }
        }

        public string UserName
        {
            get
            {
                return _userName;
            }

            set
            {
                _userName = value;
            }
        }

        public string UserPwd
        {
            get
            {
                return _userPwd;
            }

            set
            {
                _userPwd = value;
            }
        }
    }
}
