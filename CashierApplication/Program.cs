using System;
using System.Windows.Forms;

namespace CashierApplication
{
    internal static class Program
    {
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            bool keepRunning = true;

            while (keepRunning)
            {
                using (frmLoginAccount loginForm = new frmLoginAccount())
                {
                    if (loginForm.ShowDialog() != DialogResult.OK)
                    {
                        break;
                    }

                    using (frmPurchaseDiscountedItem purchaseForm = new frmPurchaseDiscountedItem(loginForm.LoggedInAccount))
                    {
                        Application.Run(purchaseForm);
                        keepRunning = purchaseForm.LogoutRequested;
                    }
                }
            }
        }
    }
}