using System;
using System.Windows.Forms;
using UserAccountNamespace;

namespace CashierApplication
{
    public partial class frmLoginAccount : Form
    {
        private UserAccount loggedInAccount;

        public frmLoginAccount()
        {
            InitializeComponent();
            this.Text = "User Login";
            this.textBox2.UseSystemPasswordChar = true;
            this.button1.Click += new EventHandler(this.button1_Click);
        }

        public UserAccount LoggedInAccount
        {
            get
            {
                return this.loggedInAccount;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            UserAccount account = new Cashier("Bryan Carpio", "Finance", "br1110", "silly-con-man");

            if (account.validateLogin(this.textBox1.Text, this.textBox2.Text))
            {
                Cashier cashier = (Cashier)account;
                MessageBox.Show("Welcome " + cashier.getFullName() + " of " + cashier.getDepartment());
                this.loggedInAccount = account;
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            else
            {
                MessageBox.Show("Invalid username or password.", "Login Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.textBox2.Clear();
                this.textBox1.Focus();
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {
        }
    }
}