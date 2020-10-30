using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewImplementation.Models
{
    public class AccountList
    {
        private List<Account> aList = new List<Account>();


        public void addAccount(Account a)
        {
            aList.Add(a);
        }

        public void removeAccount(String fullName)
        {
            bool contained = aList.Any(a => a.getName() == fullName);
            if (contained)
            {
                for (int i = 0; i < aList.Count(); i++)
                {
                    if (aList[i].getName() == fullName)
                        aList.Remove(aList[i]);
                }
            }
        }

        public Account getAccount(String fullName)
        {
            bool contained = aList.Any(a => a.getName() == fullName);
            if (contained)
                for (int i = 0; i < aList.Count(); i++)
                {
                    if (aList[i].getName() == fullName)
                        return aList[i];
                }
            return null;
        }
    }
}
