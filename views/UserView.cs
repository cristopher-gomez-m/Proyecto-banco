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
    public partial class UserView : Form
    {
        Login login;
        NewAccountView newAccountView;
        public UserView()
        {
            InitializeComponent();
            login = new Login();
            newAccountView = new NewAccountView();
        }

   



        private void UserView_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
           Boolean ok= Login.validateAccount(usuario, contraseña);
            if(ok)
            {
                /* mensajito de inicio de sesion*/
            }
            else
            {
                /* usuario o contraseña no valido*/
            }
        }


        private void validateForm()
        {
            String nombre = nombreUsuario.Text.Trim();
            String contraseña;
            if (nombre == string.Empty || contraseña== string.Empty)
            {
                botonPrestamo.Enabled = false;
                errorProvider1.SetError(nombreUsuario, "Debe introducir un nombre");
            }
            else
            {
                Boolean ok = login.validateText(nombe)
                if (!ok)
                {
                    errorProvider1.SetError(nombreUsuario, "Solo se acepta letras y espacios en blanco");
                }
                else if(ok)
                {
                    Boolean okk = login.validateText(contraseña);

                    if (okk)
                    {
                        errorProvider1.SetError(nombreUsuario, "");
                        botonPrestamo.Enabled = true;

                    }
                }
 
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            newAccountView.Show();
        }
    }
