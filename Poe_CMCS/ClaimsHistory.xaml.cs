using System.Windows;
using System.Windows.Controls;

namespace ClaimManagement
{
    public partial class ClaimsHistory : Window
    {
        public ClaimsHistory()
        {
            InitializeComponent();
            this.DataContext = ClaimsDataModel.Instance;
            claimsDataGrid.ItemsSource = ClaimsDataModel.Instance.ClaimList;
        }

        // ✅ Change status button logic
        private void ChangeStatus_Click(object sender, RoutedEventArgs e)
        {
            var button = sender as Button;
            var claim = button.DataContext as Claim;

            if (claim != null)
            {
                switch (claim.Status)
                {
                    case "Pending":
                        claim.Status = "Approved";
                        break;
                    case "Approved":
                        claim.Status = "Rejected";
                        break;
                    case "Rejected":
                        claim.Status = "Pending";
                        break;
                    default:
                        claim.Status = "Pending";
                        break;
                }
            }
        }

        // ✅ Back button
        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            this.Close();
        }
    }
}
