namespace UserAccountNamespace
{
    public class Cashier : UserAccount
    {
        private string department;

        public Cashier(string name, string department, string uName, string password) : base(name, uName, password)
        {
            this.department = department;
        }

        public override bool validateLogin(string uName, string password)
        {
            return this.user_name == uName && this.user_password == password;
        }

        public string getDepartment()
        {
            return this.department;
        }
    }
}