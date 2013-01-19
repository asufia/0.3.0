using DAL.DataObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Memory
{
    public class AccountManager
    {
        private static List<DataObjects.Account> accountList = new List<DataObjects.Account>();

        public static void AddAccount(string userName, string password)
        {
            accountList.Add(new Account(userName, password));
        }

        public static Account GetAccountByUserName(string userName)
        {

            return accountList.Find(b => b.UserName == userName);

        }

        private static void fillAccountList()
        {
            DataObjects.Account account1 = new DAL.DataObjects.Account("patato", "1234");

            DataObjects.Account account2 = new DAL.DataObjects.Account("fire", "1234");

            accountList.Add(account1);
            accountList.Add(account2);
        }

        public static List<Account> GetAllAccount()
        {
            fillAccountList();
            return accountList;
        }

    }
}
