using HostingManagmentSystem.AdditionalWindows;
using HostingManagmentSystem.Domain.Infrastructure;
using System.Windows;
namespace HostingManagmentSystem
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            Initializer.Init(false);
        }

        private void Button_Admins(object sender, RoutedEventArgs e)
        {
            var window = new AdminWindow();
            Close();
            window.Show();
        }

        private void Button_Users(object sender, RoutedEventArgs e)
        {
            var window = new UserWindow();
            Close();
            window.Show();
        }

        private void Button_VPS(object sender, RoutedEventArgs e)
        {
            var window = new VpsWindow();
            Close();
            window.Show();
        }

        private void Button_Tickets(object sender, RoutedEventArgs e)
        {
            var window = new TicketWindow();
            Close();
            window.Show();
        }
    }
}
