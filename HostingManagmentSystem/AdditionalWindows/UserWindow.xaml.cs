
using System.Windows;
using HostingManagmentSystem.Domain.Repositories;
using HostingManagmentSystem.Domain.Repositories.Contracts;
using HostingManagmentSystem.Domain.Model;
using HostingManagmentSystem.Domain.Repositories.Contracts.Repositories;
using HostingManagmentSystem.DialogWindows;

namespace HostingManagmentSystem.AdditionalWindows
{
    public partial class UserWindow : Window
    {
        private IRepositoryContext _context = SimpleRepositoryContext.Of();
        public UserWindow()
        {
            InitializeComponent();
            listUser.ItemsSource = _context.Get<User,IUserRepository>().All();
            listUser.Items.Refresh();
        }


        private void Button_Add_Click(object sender, RoutedEventArgs e)
        {

            var window = new UserDialogWindow();
            Close();
            window.Show();
        }

        private void Button_Remove_Click(object sender, RoutedEventArgs e)
        {
            var user = (User)listUser.SelectedItem;
            _context.Get<User, IUserRepository>().Delete(user);
            _context.PersistState();
            listUser.ItemsSource = _context.Get<User, IUserRepository>().All();
        }

        private void Button_Edit_Click(object sender, RoutedEventArgs e)
        {
            int id = listUser.SelectedIndex;
            var user = (User)listUser.SelectedItem;
            if (id ==-1 )
            {
                MessageBox.Show("Выберите пользователя");
            }
            var window = new UserDialogWindow(user);
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
