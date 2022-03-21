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
    public partial class TransaccionsViews : Form
    {
        UserAccountFinder userAccountFinder;
        public TransaccionsViews(UserAccountFinder userAccountFinder)
        {
            InitializeComponent();
            this.userAccountFinder = userAccountFinder;

        }

   


  
    }
}
