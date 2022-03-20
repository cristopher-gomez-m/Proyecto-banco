using System;
using models;
namespace controllers
{
    class OperationAmount
    {
        CreditRequestor creditRequestor;
        UserFinderBD userFinderBD;
        
        public OperationAmount(UserFinderBD userFinderBD)
        {
            this.userFinderBD = userFinderBD;   
        }

        public Boolean addMount(double monto)
        {
            Boolean state;
            int serial = userFinderBD.getSerial();
            double finalMount = userFinderBD.addAmount(monto);
            state= this.userFinderBD.updateMount(serial, finalMount);
            return state;
        }

        public Boolean reduceMount(double monto)
        {
            Boolean state;
            int serial = userFinderBD.getSerial();
            double finalMount = userFinderBD.reduceAmount(monto);
            state = this.userFinderBD.updateMount(serial, finalMount);
            return state;
        }

        public string getAnualidad(double numCuotas, double monto)
        {
            this.creditRequestor = new CreditRequestor(numCuotas, monto);
            return this.creditRequestor.getAnualidad();
        }

        
    }
}
