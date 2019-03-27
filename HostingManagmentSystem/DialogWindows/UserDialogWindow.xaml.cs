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
    public partial class UserDialogWindow : Window
    {
        private readonly User _model;
        private readonly IRepositoryContext _context;
        public UserDialogWindow(User user = null)
        {
            InitializeComponent();

            _model = user ?? new User();
            _context = SimpleRepositoryContext.Of();

            textName.Text = user?.Name;
            textSurname.Text = user?.Surname;
            textPhone.Text = user?.Phone;
            textSecret.Text = user?.Secret;
        }

        private void Button_Add_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                _model.Name = textName.Text;
                _model.Surname = textSurname.Text;
                _model.Phone = textPhone.Text;
                _model.Secret = textSecret.Text;

                _context.Get<User, IUserRepository>().Persist(_model);

                _context.PersistState();

                var window = new UserWindow();
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
           
            var window = new UserWindow();
            window.Show();
            Close();
        }
    }
}
