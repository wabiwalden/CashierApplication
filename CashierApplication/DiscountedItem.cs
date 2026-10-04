namespace ItemNamespace
{
    public class DiscountedItem : Item
    {
        private double item_discount;
        private double discounted_price;
        private double payment_amount;
        private double change;

        public DiscountedItem(string name, double price, int quantity, double discount) : base(name, price, quantity)
        {
            this.item_discount = discount;
            this.discounted_price = 0;
            this.payment_amount = 0;
            this.change = 0;
        }

        public override double getTotalPrice()
        {
            this.discounted_price = this.item_price - (this.item_discount * this.item_price);
            return this.discounted_price * this.item_quantity;
        }

        public override void setTotalPayment(double amount)
        {
            this.setPayment(amount);
        }

        public void setPayment(double amount)
        {
            this.payment_amount = amount;
            this.change = this.payment_amount - this.getTotalPrice();
        }

        public double getChange()
        {
            return this.change;
        }
    }
}