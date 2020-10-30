using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
/*
namespace ViewImplementation.Models
{
    public class Admin 
    {
        private string userName;
        private string passWord;
        private string fullName;
        private Role role;
        AccountList aList = new AccountList();

        public Admin(string username, string password, string fullName)
        {
            this.userName = username;
            this.passWord = password;
            this.fullName = fullName;
            this.role = Role.ADMIN;
        }


        public Role getRole()
        {
            return role;
        }
        public void deleteAdmin(string fullname)
        {
            try
            {
                aList.removeAccount(fullname);
            }
            catch (Exception)
            {
                System.Diagnostics.Debug.Write("Invalid Admin to delete");
            }
        }
        public void addAdmin(string username, string password, string fullname)
        {
            Account adminToAdd = new Account(fullname, Role.ADMIN,username, password);
            try
            {
                aList.addAccount(adminToAdd);
            }
            catch (Exception)
            {
                System.Diagnostics.Debug.Write("Invalid Admin to add");
            }
        }
        public void addChef(string username, string password, string fullname)
        {
            Account chefToAdd = new Account(fullname, Role.CHEF, password,username);
            try
            {
                aList.addAccount(chefToAdd);
            }
            catch (Exception)
            {
                System.Diagnostics.Debug.Write("Invalid Chef to add");
            }
        }
        public void deleteChef(string fullname)
        {
            try
            {
                aList.removeAccount(fullname);
            }
            catch (Exception)
            {
                System.Diagnostics.Debug.Write("Invalid Chef to delete");
            }
        }
        public void addCustomer(string fullname, string phoneNumber, PaymentType paymentType, String password, String userName)
        {
            Account customerToAdd = new Account(fullname, Role.CUSTOMER, phoneNumber, paymentType, password, userName);
            try
            {
                aList.addAccount(customerToAdd);
            }
            catch (Exception)
            {
                System.Diagnostics.Debug.Write("Invalid Customer to add");
            }
        }
        public void deleteCustomer(string fullname)
        {
            try
            {
                aList.removeAccount(fullname);
            }
            catch (Exception)
            {
                System.Diagnostics.Debug.Write("Invalid Customer to delete");
            }
        }
        public Account getAccount(String fullName)
        {
            return aList.getAccount(fullName);
        }
    }
} 
*/