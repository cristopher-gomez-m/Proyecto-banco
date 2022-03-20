using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using models;
namespace controllers
{
    class CreditRequestor
    {
        Annuality annuality;
  
        public CreditRequestor(double numCuotas,double monto)
        {
            this.annuality = new Annuality(numCuotas,monto);
        }

        public string getAnualidad()
        {
            return this.annuality.getAnualidad();
        }
    }
}
