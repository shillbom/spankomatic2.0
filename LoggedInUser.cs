using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Spankomatic
{
    
    public class LoggedInUser
    {
        private string login;

        public LoggedInUser(string login)
        {
            this.login = login;
        }

        public string GetLogin()
        {
            return login;
        }
    }
}
