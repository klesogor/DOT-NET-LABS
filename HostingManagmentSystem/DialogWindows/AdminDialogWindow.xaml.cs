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
    public partial class AdminDialogWindow : Window
    {
        private readonly Admin _model;
        private readonly IRepositoryContext _context;
        public AdminDialogWindow(Admin admin = null)
        {
            InitializeComponent();

            _model = admin ?? new Admin();
            _context = SimpleRepositoryContext.Of();

            textName.Text = admin?.Name;
            textDesciption.Text = admin?.Description;
            textIp.Text = admin?.Ip;

            listboxRole.ItemsSource = _context.Get<Role, IRoleRepository>().All();

            loadSelectedRoles(admin);
            
        }

        private void Button_Add_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                _model.Name = textName.Text;
                _model.Description = textDesciption.Text;
                _model.Ip = textIp.Text;

                _context.Get<Admin, IAdminRepository>().Persist(_model);

                var res = new List<Role>();
                foreach (Role role in listboxRole.SelectedItems)
                {
                    res.Add(role);
                }
                _context.Get<RoleAdmin, IRoleAdminRepository>().Attach(_model,res);

                _context.PersistState();

                var window = new AdminWindow();
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
           
            var window = new AdminWindow();
            window.Show();
            Close();
        }

        private void loadSelectedRoles(Admin model)
        {
            model?.Roles.ForEach(x => listboxRole.SelectedItems.Add(x));
        }
    }
}
