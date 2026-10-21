using System;
using System.Windows.Forms;
using UserAccountNamespace;

namespace CashierApplication
{
    public partial class frmPurchaseDiscountedItem : Form
    {
        private UserAccount currentUser;
        private double totalAmount;
        private bool logoutRequested;

        public frmPurchaseDiscountedItem(UserAccount user)
        {
            InitializeComponent();
            this.currentUser = user;
            this.totalAmount = 0;
            this.logoutRequested = false;
            this.label8.Text = "0.00";
            this.label9.Text = "0.00";
            this.button1.Click += new EventHandler(this.button1_Click);
            this.button2.Click += new EventHandler(this.button2_Click);
            this.logoutToolStripMenuItem.Click += new EventHandler(this.logoutToolStripMenuItem_Click);
            this.exitApplicationToolStripMenuItem.Click += new EventHandler(this.exitApplicationToolStripMenuItem_Click);
        }

        public bool LogoutRequested
        {
            get
            {
                return this.logoutRequested;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            double discount;
            double price;
            int quantity;

            if (!double.TryParse(this.textBox2.Text, out discount) || !double.TryParse(this.textBox3.Text, out price) || !int.TryParse(this.textBox4.Text, out quantity))
            {
                MessageBox.Show("Please enter valid numbers for discount, price, and quantity.", "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (discount < 0 || discount > 100 || price < 0 || quantity < 0)
            {
                MessageBox.Show("Please enter values within the valid range.", "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            double subtotal = price * quantity;
            this.totalAmount = subtotal - (subtotal * discount / 100);
            this.label8.Text = this.totalAmount.ToString("N2");
            this.label9.Text = "0.00";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            double payment;

            if (!double.TryParse(this.textBox5.Text, out payment))
            {
                MessageBox.Show("Please enter a valid payment amount.", "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (payment < this.totalAmount)
            {
                MessageBox.Show("Payment received is not enough.", "Insufficient Payment", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            this.label9.Text = (payment - this.totalAmount).ToString("N2");
        }

        private void logoutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.logoutRequested = true;
            this.Close();
        }

        private void exitApplicationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.logoutRequested = false;
            this.Close();
        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {
        }
    }
}