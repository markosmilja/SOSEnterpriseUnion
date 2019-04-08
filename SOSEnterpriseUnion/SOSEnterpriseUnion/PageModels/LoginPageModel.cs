using System;
using System.Collections.Generic;
using System.Text;

namespace SOSEnterpriseUnion.PageModels
{
    public class LoginPageModel : BasePageModel
    {
        public LoginPageModel() : base()
        {
            Title = "Login";
        }

        public bool IsPasswordValid(string password)
        {
            if (password == "123")
                return true;
            else
                return false;
        }
    }
}
