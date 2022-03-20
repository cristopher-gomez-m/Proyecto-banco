using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using models;
namespace controllers
{
    public class UserAccountFinder
    {
        UserFinderBD userFinderBD;
        User user;
        public UserAccountFinder()
        {
            userFinderBD = new UserFinderBD();
        }

        private void findUser(string email, string password)
        {
           user= this.userFinderBD.findUser(email, password);
            
        }

        public User getUser(string email,string password)
        {
            this.findUser(email, password);
            return this.user;
        }
    }
}
