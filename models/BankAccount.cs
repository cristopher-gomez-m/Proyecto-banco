using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace models
{
    public class BankAccount
    {
        private int serial;
        private double money;


        public BankAccount(int serial,double money)
        {
            this.serial = serial;
            this.money = money;
        }

        public double addMoney(double money)
        {
            return this.money += money;
        }

        public double reduceMoney(double money)
        {
            return this.money -= money; 
        }

        public int getSerial()
        {
            return this.serial;
        }   
    }
}
