using System;
using System.Text.RegularExpressions;


namespace controllers
{
    public class RegexValidator
    {
        private Boolean isValid;

        public RegexValidator()
        {
            this.isValid = false;
        }

        public Boolean validarTexto(String nombre)
        {
            Regex regexName = new Regex(@"^[A-Za-zÑñÁáÉéÍíÓóÚúÜü\s]+$");
            Boolean ok = regexName.IsMatch(nombre);
            if (!ok)
            {
                this.isValid = false;
            }
            else if (ok)
            {
                this.isValid = true;
            }
            return this.isValid;

        }

        public Boolean validarNumero(string number)
        {
            Regex regexNumber = new Regex(@"^[0-9,]*$");
            Boolean ok = regexNumber.IsMatch(number);
            if (!ok)
            {
                this.isValid = false;
            }
            else if (ok)
            {
                this.isValid = true;
            }
            return this.isValid;
        }
    }
}
