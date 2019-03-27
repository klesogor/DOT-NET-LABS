using System;
using System.Collections.Generic;
using System.Windows;
using HostingManagmentSystem.AdditionalWindows;
using HostingManagmentSystem.Domain.Infrastructure;
using HostingManagmentSystem.Domain.Model;
using HostingManagmentSystem.Domain.Repositories;
using HostingManagmentSystem.Domain.Repositories.Contracts;
using HostingManagmentSystem.Domain.Repositories.Contracts.Repositories;

namespace HostingManagmentSystem.DialogWindows
{
    public partial class TicketDialogWindow : Window
    {
        private readonly Ticket _model;
        private readonly IRepositoryContext _context;
        public TicketDialogWindow(Ticket ticket = null)
        {
            InitializeComponent();

            _model = ticket ?? new Ticket();
            _context = SimpleRepositoryContext.Of();

            textDescription.Text = ticket?.Description;

            cbAdmin.ItemsSource = _context.Get<Admin, IAdminRepository>().All();
            cbUser.ItemsSource = _context.Get<User, IUserRepository>().All();
            cbVps.ItemsSource = _context.Get<VPS, IVpsRepository>().All();

            cbAdmin.SelectedItem = ticket?.Admin;
            cbUser.SelectedItem = ticket?.User;
            cbVps.SelectedItem = ticket?.VPS;
            
        }

        private void Button_Add_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                _model.Description = textDescription.Text;
                _model.Date = DateTime.Now;
                _model.Admin = (Admin)cbAdmin.SelectedItem;
                _model.User = (User)cbUser.SelectedItem;
                _model.VPS = (VPS)cbVps.SelectedItem;

                _context.Get<Ticket, ITicketRepository>().Persist(_model);

                _context.PersistState();
                var window = new TicketWindow();
                Close();
                window.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            
        }

        private void Button_Cancel_Click(object sender, RoutedEventArgs e)
        {
            var window = new VpsWindow();
            window.Show();
            Close();
        }
    }
}
