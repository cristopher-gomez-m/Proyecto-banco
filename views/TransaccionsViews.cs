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
        AmountAddView amountAddView;
        AmountRemoverView AmountRemoverView;
        public TransaccionsViews(UserAccountFinder userAccountFinder)
        {
            InitializeComponent();
            this.userAccountFinder = userAccountFinder;

        }

        private void buttonAmountAdder_Click(object sender, EventArgs e)
        {
            this.amountAddView = new AmountAddView(this.userAccountFinder);
            this.amountAddView.Show();
        }

        private void buttonAmountReducer_Click(object sender, EventArgs e)
        {
            this.AmountRemoverView = new AmountRemoverView(this.userAccountFinder);
            this.AmountRemoverView.Show();
        }
    }
}
