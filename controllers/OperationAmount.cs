using System;
using models;
namespace controllers
{
    public class OperationAmount
    {
        CreditRequestor creditRequestor;
        UserFinderBD userFinderBD;
        Annuality annuality;
        public OperationAmount(UserAccountFinder userAccountFinder)
        {
            this.userFinderBD = userAccountFinder.getUserFinderBD();
            
        }

        public string addMount(double monto,double cuotas)
        {
            string amountString;

            int serial = userFinderBD.getSerial();
            double finalMount = this.userFinderBD.addAmount(monto);
             this.userFinderBD.updateMount(serial, finalMount);
            string annuality = this.getAnnuality(monto, cuotas);
            amountString = "El dinero actual en la cuenta es de: " + finalMount
                +" "+annuality;
            return amountString;
        }

        private string getAnnuality(double monto,double cuotas)
        {
            this.annuality = new Annuality( cuotas,monto);
            Console.WriteLine("monto: " + monto);
            Console.WriteLine("cuotas: " + cuotas);
            return this.annuality.getAnualidad();
        }

        public string reduceMount(double monto)
        {
            string amountString;
            double amount = this.userFinderBD.getAmount();
            if (amount < monto)
            {
                 amountString = "Su dinero es de" + amount + " no cuenta con el dinero suficiente para la transacción";
            }
            else
            {
                int serial = this.userFinderBD.getSerial();
                double finalMount = this.userFinderBD.reduceAmount(monto);
                this.userFinderBD.updateMount(serial, finalMount);
                amountString = "Su dinero final es de: " + finalMount;
            }
            return amountString;
        }

        public string getAnualidad(double numCuotas, double monto)
        {
            this.creditRequestor = new CreditRequestor(numCuotas, monto);
            return this.creditRequestor.getAnualidad();
        }

        
    }
}
