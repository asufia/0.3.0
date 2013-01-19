using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.DataObjects
{
    public class Account
    {
        #region  Fields

        private string userName;
        private string name;
        private string email;
        private string password;

        #endregion

        public Account(string userName, string password)
        {
            this.userName = userName;
            this.password = password;
        }

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



    }
}
