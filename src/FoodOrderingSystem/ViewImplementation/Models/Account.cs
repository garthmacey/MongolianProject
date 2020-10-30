using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewImplementation.Models
{
    public class Account
    {
        String fullName;
        Role role;
        String password;
        String phoneNumber;
        PaymentType payType;
        String userName;

        public Account(String n, Role r, String p, String u)
        {
            fullName = n;
            role = r;
            password = p;
            userName = u;
        }

        public Account(String n, Role r, String phone, PaymentType pay, String p, String u)
        {
            fullName = n;
            role = r;
            phoneNumber = phone;
            payType = pay;

        }

        public void setName(String n)
        {
            fullName = n;
        }

        public void setRole(Role r)
        {
            role = r;
        }

        public void setPassword(String p)
        {
            password = p;
        }

        public void setUserName(String u)
        {
            userName = u;
        }


        public String getName()
        {
            return fullName;
        }

        public Role getRole()
        {
            return role;
        }

        public String getPassword()
        {
            return password;
        }

        public String getUserName()
        {
            return userName;
        }
    }
}
