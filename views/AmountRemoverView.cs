using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using controllers;
namespace views
{
    public partial class AmountRemoverView : Form
    {
        UserAccountFinder userAccountFinder;
        OperationAmount operationAmount;
        Login login;
        public AmountRemoverView(UserAccountFinder userAccountFinder)
        {
            InitializeComponent();
            this.userAccountFinder = userAccountFinder;
            this.operationAmount = new OperationAmount(this.userAccountFinder);
            this.login = new Login();
        }


        private void validateAmount()
        {
            string amount = this.amountTextBox.Text.Trim();
            if (amount == string.Empty)
            {
                this.payButton.Enabled = false;
                errorProvider1.SetError(amountTextBox, "Debe introducir un numero");
            }
            else
            {
                Boolean ok = login.validateAmount(amount);
                if (!ok)
                {
                    errorProvider1.SetError(amountTextBox, "Solo se acepta numeros y espacios en blanco");
                }
                else
                {
                    errorProvider1.SetError(amountTextBox, "");
                    payButton.Enabled = true;
                }
                
            }
        }
        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            this.validateAmount();
        }

        private void payButton_Click(object sender, EventArgs e)
        {
            double amount = double.Parse(this.amountTextBox.Text.Trim());
            this.operationAmount.reduceMount(amount);
            string mensaje = this.operationAmount.reduceMount(amount);
            MessageBoxButtons buttons = MessageBoxButtons.OK;
            MessageBox.Show(mensaje, "Calculo de anualidad", buttons);
        }
    }

}
