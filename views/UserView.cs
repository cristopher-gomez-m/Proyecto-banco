using System;
using System.Windows.Forms;
using controllers;
namespace views
{
    public partial class UserView : Form
    {
        Login login;
        NewAccountView newAccountView;
        public UserView()
        {
            InitializeComponent();
            login = new Login();
        }

   



        private void UserView_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            String email = emailTextBox.Text.Trim();
            String password = passwordTextBox.Text.Trim();
            Boolean ok= login.validateAccount(email, password);
            if(ok)
            {
                /* mensajito de inicio de sesion*/
            }
            else
            {
                /* usuario o contraseña no valido*/
            }
        }


        private void button2_Click(object sender, EventArgs e)
        {
            newAccountView = new NewAccountView(this.login);
            newAccountView.Show();
        }


        private void validateEmail()
        {
            String email = emailTextBox.Text.Trim();
            if (email == string.Empty)
            {
                this.buttonLogin.Enabled = false;
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
                        buttonLogin.Enabled = true;
                    }
                }
            }
        

        private void validatePassword()
        {
            String password = passwordTextBox.Text.Trim();
            if (password == string.Empty)
            {
                this.buttonLogin.Enabled = false;
                errorProvider2.SetError(passwordTextBox, "Debe introducir una contraseña");
            }
            else
            {
                errorProvider2.SetError(passwordTextBox, "");
                buttonLogin.Enabled = true;
            }
        }

        private void emailTextBox_TextChanged(object sender, EventArgs e)
        {
            this.validateEmail();
        }

        private void passwordTextBox_TextChanged(object sender, EventArgs e)
        {
            validatePassword();
        }
    }
}