using System;
using System.Windows.Forms;
using ItemNamespace;

namespace CashierApplication
{
    public partial class Form1 : Form
    {
        private Item purchasedItem;

        public Form1()
        {
            InitializeComponent();
            this.label8.Text = "";
            this.label9.Text = "";
            this.textBox1.KeyPress += new KeyPressEventHandler(this.textBox1_KeyPress);
            this.textBox2.KeyPress += new KeyPressEventHandler(this.decimalOnly_KeyPress);
            this.textBox3.KeyPress += new KeyPressEventHandler(this.decimalOnly_KeyPress);
            this.textBox4.KeyPress += new KeyPressEventHandler(this.integerOnly_KeyPress);
            this.textBox5.KeyPress += new KeyPressEventHandler(this.decimalOnly_KeyPress);
            this.button1.Click += new EventHandler(this.button1_Click);
            this.button2.Click += new EventHandler(this.button2_Click);
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            TextBox box = (TextBox)sender;

            if (char.IsControl(e.KeyChar))
            {
                return;
            }

            if (char.IsLetter(e.KeyChar) && e.KeyChar < 128)
            {
                bool atStart = box.SelectionStart == 0;
                bool afterSpace = box.SelectionStart > 0 && box.Text[box.SelectionStart - 1] == ' ';

                if (atStart || afterSpace)
                {
                    e.KeyChar = char.ToUpper(e.KeyChar);
                }
            }
            else if (e.KeyChar != ' ')
            {
                e.Handled = true;
            }
        }

        private void decimalOnly_KeyPress(object sender, KeyPressEventArgs e)
        {
            TextBox box = (TextBox)sender;

            if (char.IsControl(e.KeyChar) || char.IsDigit(e.KeyChar))
            {
                return;
            }

            if (e.KeyChar == '.' && !box.Text.Contains("."))
            {
                return;
            }

            e.Handled = true;
        }

        private void integerOnly_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            double test;
            int testInt;

            if (string.IsNullOrWhiteSpace(this.textBox1.Text) ||
                !double.TryParse(this.textBox2.Text, out test) ||
                !double.TryParse(this.textBox3.Text, out test) ||
                !int.TryParse(this.textBox4.Text, out testInt))
            {
                MessageBox.Show("Please complete all fields with valid values.");
                return;
            }

            string name = this.textBox1.Text;
            double discount = Convert.ToDouble(this.textBox2.Text) * 0.01;
            double price = Convert.ToDouble(this.textBox3.Text);
            int quantity = Convert.ToInt32(this.textBox4.Text);

            this.purchasedItem = new DiscountedItem(name, price, quantity, discount);
            this.label8.Text = this.purchasedItem.getTotalPrice().ToString("N2");
            this.label9.Text = "";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            double payment;

            if (this.purchasedItem == null)
            {
                MessageBox.Show("Please compute the total amount first.");
                return;
            }

            if (!double.TryParse(this.textBox5.Text, out payment))
            {
                MessageBox.Show("Please enter a valid payment amount.");
                return;
            }

            this.purchasedItem.setTotalPayment(Convert.ToDouble(this.textBox5.Text));
            DiscountedItem discountedItem = (DiscountedItem)this.purchasedItem;
            this.label9.Text = discountedItem.getChange().ToString("N2");
        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {
        }
    }
}