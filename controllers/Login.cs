using System;
using models;

namespace controllers
{
    public class Login
    {
        User user;
        private RegexValidator validator;
        private UserAccountFinder userAccountFinder;

        public Login()
        {
            this.validator = new RegexValidator();
            this.userAccountFinder = new UserAccountFinder();
        }

        public Boolean validateText(string nombre)
        {
            return this.validator.validarTexto(nombre);
        }

        public Boolean validateAccount(string email, string password)
        {
            Boolean state;
             user = this.getUser(email,password);
            if (user != null)
            {
                state = true;
            }
            else
            {
                state = false;
            }

            return state;
        }

        public User getUser(string email,string password)
        {
            return this.userAccountFinder.getUser(email,password);
        }

        public UserAccountFinder getUserAccountFinder()
        {
            return this.userAccountFinder;
        }
    }
}
