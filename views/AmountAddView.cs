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
    public partial class AmountAddView : Form
    {
        UserAccountFinder userAccountFinder;
        Login login;
        OperationAmount operationAmount;
        private int[] cuotasDisponiblesList = { 1, 2, 3, 4, 5 };
        public AmountAddView(UserAccountFinder userAccountFinder)
        {
            InitializeComponent();
            this.userAccountFinder = userAccountFinder;
            this.login = new Login();
            this.operationAmount = new OperationAmount(this.userAccountFinder);
        }

        private void llenarCuotas()
        {
            for (int i = 0; i < cuotasDisponiblesList.Length; i++)
            {
                cuotas.Items.Add(cuotasDisponiblesList[i]);
            }
        }

        private void AmountAddView_Load(object sender, EventArgs e)
        {
            llenarCuotas();
            this.borrowMoneyButton.Enabled = false;
        }

        private void validateForm()
        {
            String number = amountTextBox.Text.Trim();
            if (number == string.Empty || cuotas.Text.Trim() == string.Empty)
            {
               this.borrowMoneyButton.Enabled = false;
                errorProvider1.SetError(amountTextBox, "Debe introducir un monto y elejir el numero de cuotas");
            }
            else
            {
                Boolean ok = login.validateAmount(number);
                if (!ok)
                {
                    borrowMoneyButton.Enabled = false;
                    errorProvider1.SetError(amountTextBox, "Solo se acepta numeros");
                }
                else if (ok)
                {
                    errorProvider1.SetError(amountTextBox, "");
                    borrowMoneyButton.Enabled = true;
                }
            }
        }


   

        private void borrowMoneyButton_Click(object sender, EventArgs e)
        {
            double credit = double.Parse(this.amountTextBox.Text.Trim());
            double quota = double.Parse(this.cuotas.Text.Trim());
            string mensaje = this.operationAmount.addMount(credit,quota);
            MessageBoxButtons buttons = MessageBoxButtons.OK;
            MessageBox.Show(mensaje, "Calculo de anualidad", buttons);
        }

        private void cuotas_TextChanged(object sender, EventArgs e)
        {
            validateForm();
        }

        private void amountTextBox_TextChanged(object sender, EventArgs e)
        {
            validateForm();
        }
    }
}
