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
    public partial class NewAccountView : Form
    {
        Login login;
        UserAccountCreator userAccountCreator;
        public NewAccountView(Login login)
        {
            InitializeComponent();
            this.login = login;
            this.userAccountCreator = new UserAccountCreator();
        }

        private void validateEmail()
        {
            String email = emailTextBox.Text.Trim();
            if (email == string.Empty)
            {
                this.buttonCreateAccount.Enabled = false;
                errorProvider1.SetError(emailTextBox, "Debe introducir un nombre");
            }
            else
            {
                Boolean ok = login.validateText(email);
                if (!ok)
                {
                    errorProvider1.SetError(emailTextBox, "Solo se acepta letras y espacios en blanco");
                }
                else
                {
                    errorProvider1.SetError(emailTextBox, "");
                    buttonCreateAccount.Enabled = true;
                }
            }
        }

        private void validatePassword()
        {
            String password = passwordTextBox.Text.Trim();
            if (password == string.Empty)
            {
                this.buttonCreateAccount.Enabled = false;
                errorProvider2.SetError(passwordTextBox, "Debe introducir una contraseña");
            }
            else
            {
                errorProvider2.SetError(passwordTextBox, "");
                buttonCreateAccount.Enabled = true;
            }
        }
        private void emailTextBox_TextChanged(object sender, EventArgs e)
        {
            validateEmail();
        }

        private void passwordTextBox_TextChanged(object sender, EventArgs e)
        {
            validatePassword();
        }

        private void buttonCreateAccount_Click(object sender, EventArgs e)
        {
            String email = emailTextBox.Text.Trim();
            String password = passwordTextBox.Text.Trim();
            Boolean state = this.userAccountCreator.createAccount(email,password);
            if (state)
            {
                Console.WriteLine("Llegue a true");
                MessageBoxButtons buttons = MessageBoxButtons.OK;
                string mensaje = "Cuenta creada correctamente";
                MessageBox.Show(mensaje, "Cuenta creada", buttons);
            }
            else
            {
                Console.WriteLine("Llegue a false");
                MessageBoxButtons buttons = MessageBoxButtons.OK;
                string mensaje = "El usuario elejido ya existe,elija otro";
                MessageBox.Show(mensaje, "Cuenta no creada", buttons);
            }
        }
    }
}
