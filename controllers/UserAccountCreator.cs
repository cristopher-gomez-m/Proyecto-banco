using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using models;

namespace controllers
{
    public class UserAccountCreator
    {
        private UserFinderBD userFinderBD;

        public UserAccountCreator()
        {
            this.userFinderBD = new UserFinderBD();
        }

        private int createSerial()
        {
            Random ramdom = new Random();
            Boolean isAccount=true;
            int serial;
            do
            {
                 serial = ramdom.Next(1, 999999999);
                 isAccount = userFinderBD.existBankAccount(serial);
            } while (isAccount);

            return serial;
        }

        public Boolean createAccount(string user,string password)
        {
            Console.WriteLine("Llegue a createAccount");
            Boolean state;
            int serial = this.createSerial();
            state =   userFinderBD.createUser(user, password, serial);
            return state;
        }

    }
}
