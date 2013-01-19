using DAL.Memory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainLayer
{
    public class Account
    {
        #region  Fields

        private string userName;
        private string name;
        private string email;
        private string password;

        #endregion

        #region Properties

        public string UserName
        {
            get
            {
                return this.userName;
            }

            set
            {
                this.userName = value;
            }
        }

        public string Name
        {
            get
            {
                return this.name;
            }

            set
            {
                this.name = value;
            }
        }

        public string Email
        {
            get
            {
                return this.email;
            }

            set
            {
                this.email = value;
            }
        }

        public string Password
        {
            get
            {
                return this.password;
            }

            set
            {
                this.password = value;
            }
        }

     
        #endregion

           #region Methods

        public Account(string userName, string password)
        {
            AccountManager.AddAccount(userName,password);
        }

        public Account()
        {
        }

        public static List<Account> GetAccounts()
        {
            List<DAL.DataObjects.Account> dataList = AccountManager.GetAllAccount();

            if (dataList == null)
                return null;

            List<Account> accountlist = new List<Account>();

            foreach (DAL.DataObjects.Account dataAccount in dataList)
            {
                Account newAccount = new Account();

                newAccount.userName = dataAccount.UserName;
                newAccount.name = dataAccount.Name;
                newAccount.email = dataAccount.Email;
                newAccount.password = dataAccount.Password;


                accountlist.Add(newAccount);
            }

            return accountlist;
        }

        public static bool UpDateBoard(int boardID)
        {
            return true;
        }

        public static bool RemoveBoard(int boardID)
        {
            return true;
        }

        #endregion

    }
}
