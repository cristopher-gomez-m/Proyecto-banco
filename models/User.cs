using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace models
{
    public class User
    {
        private string user;
        private string password;
        private BankAccount bankAccount;

        public User(string user,string password,BankAccount bankAccount)
        {
            this.user = user;
            this.password = password;
            this.bankAccount = bankAccount;
        }

        public int getBankAccountSerial()
        {
            return this.bankAccount.getSerial();
        }

        public BankAccount getBankAccount()
        {
            return this.bankAccount;
        }
    }
}
