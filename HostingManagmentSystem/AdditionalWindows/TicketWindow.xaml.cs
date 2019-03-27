
using System.Windows;
using HostingManagmentSystem.Domain.Repositories;
using HostingManagmentSystem.Domain.Repositories.Contracts;
using HostingManagmentSystem.Domain.Model;
using HostingManagmentSystem.Domain.Repositories.Contracts.Repositories;
using HostingManagmentSystem.DialogWindows;

namespace HostingManagmentSystem.AdditionalWindows
{
    public partial class TicketWindow : Window
    {
        private IRepositoryContext _context = SimpleRepositoryContext.Of();
        public TicketWindow()
        {
            InitializeComponent();
            listTicket.ItemsSource = _context.Get<Ticket,ITicketRepository>().All();
            listTicket.Items.Refresh();
        }


        private void Button_Add_Click(object sender, RoutedEventArgs e)
        {

            var window = new TicketDialogWindow();
            Close();
            window.Show();
        }

        private void Button_Remove_Click(object sender, RoutedEventArgs e)
        {
            var ticket = (Ticket)listTicket.SelectedItem;
            _context.Get<Ticket, ITicketRepository>().Delete(ticket);
            _context.PersistState();
            listTicket.ItemsSource = _context.Get<VPS, IVpsRepository>().All();
        }

        private void Button_Edit_Click(object sender, RoutedEventArgs e)
        {
            int id = listTicket.SelectedIndex;
            var ticket = (Ticket)listTicket.SelectedItem;
            if (id ==-1 )
            {
                MessageBox.Show("Выберите тикет");
            }
            var window = new TicketDialogWindow(ticket);
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
