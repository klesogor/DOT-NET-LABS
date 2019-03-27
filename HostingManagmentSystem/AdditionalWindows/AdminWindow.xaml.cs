
using System.Windows;
using HostingManagmentSystem.Domain.Repositories;
using HostingManagmentSystem.Domain.Repositories.Contracts;
using HostingManagmentSystem.Domain.Model;
using HostingManagmentSystem.Domain.Repositories.Contracts.Repositories;
using HostingManagmentSystem.DialogWindows;

namespace HostingManagmentSystem.AdditionalWindows
{
    public partial class AdminWindow : Window
    {
        private IRepositoryContext _context = SimpleRepositoryContext.Of();
        public AdminWindow()
        {
            InitializeComponent();
            listAdmin.ItemsSource = _context.Get<Admin,IAdminRepository>().All();
            listAdmin.Items.Refresh();
        }


        private void Button_Add_Click(object sender, RoutedEventArgs e)
        {

            var window = new AdminDialogWindow();
            Close();
            window.Show();
        }

        private void Button_Remove_Click(object sender, RoutedEventArgs e)
        {
            var admin = (Admin)listAdmin.SelectedItem;
            _context.Get<RoleAdmin, IRoleAdminRepository>().Detach(admin);
            _context.Get<Admin, IAdminRepository>().Delete(admin);
            _context.PersistState();
            listAdmin.ItemsSource = _context.Get<Admin, IAdminRepository>().All();

        }

        private void Button_Edit_Click(object sender, RoutedEventArgs e)
        {
            int id = listAdmin.SelectedIndex;
            var admin = (Admin)listAdmin.SelectedItem;
            if (id ==-1 )
            {
                MessageBox.Show("Выберите администратора");
            }
            var window = new AdminDialogWindow(admin);
            Close();
            window.Show();
        }

        private void Button_Cancel_Click(object sender, RoutedEventArgs e)
        {
          
            var window = new MainWindow();
            Close();
            window.Show();
        }
    }
}
