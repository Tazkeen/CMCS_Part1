using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

using System.Windows;

using System.Windows;

namespace ClaimManagement
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void LecturerDashboard_Click(object sender, RoutedEventArgs e)
        {
            LecturerDashboard lecturerDashboard = new LecturerDashboard();
            lecturerDashboard.Show();
            this.Close();
        }

        private void ClaimsHistory_Click(object sender, RoutedEventArgs e)
        {
            ClaimsHistory claimsHistory = new ClaimsHistory();
            claimsHistory.Show();
            this.Close();
        }
    }
}
