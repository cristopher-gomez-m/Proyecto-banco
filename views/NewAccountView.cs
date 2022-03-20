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
        public NewAccountView(Login login)
        {
            InitializeComponent();
            this.login = login;
        }
    }
}
