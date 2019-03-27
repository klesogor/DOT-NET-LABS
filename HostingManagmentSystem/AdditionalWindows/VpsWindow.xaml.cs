
using System.Windows;
using HostingManagmentSystem.Domain.Repositories;
using HostingManagmentSystem.Domain.Repositories.Contracts;
using HostingManagmentSystem.Domain.Model;
using HostingManagmentSystem.Domain.Repositories.Contracts.Repositories;
using HostingManagmentSystem.DialogWindows;

namespace HostingManagmentSystem.AdditionalWindows
{
    public partial class VpsWindow : Window
    {
        private IRepositoryContext _context = SimpleRepositoryContext.Of();
        public VpsWindow()
        {
            InitializeComponent();
            listVps.ItemsSource = _context.Get<VPS,IVpsRepository>().All();
            listVps.Items.Refresh();
        }


        private void Button_Add_Click(object sender, RoutedEventArgs e)
        {

            var window = new VpsDialogWindow();
            Close();
            window.Show();
        }

        private void Button_Remove_Click(object sender, RoutedEventArgs e)
        {
            var vps = (VPS)listVps.SelectedItem;
            _context.Get<VPS, IVpsRepository>().Delete(vps);
            _context.PersistState();
            listVps.ItemsSource = _context.Get<VPS, IVpsRepository>().All();
        }

        private void Button_Edit_Click(object sender, RoutedEventArgs e)
        {
            int id = listVps.SelectedIndex;
            var vps = (VPS)listVps.SelectedItem;
            if (id ==-1 )
            {
                MessageBox.Show("Выберите VPS");
            }
            var window = new VpsDialogWindow(vps);
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
