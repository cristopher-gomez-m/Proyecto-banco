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
            if (user == null)
            {
                state = false;
            }
            else
            {
                state = true;
            }

            return state;
        }

        public User getUser(string email,string password)
        {
            return userAccountFinder.getUser(email,password);
        }
    }
}
