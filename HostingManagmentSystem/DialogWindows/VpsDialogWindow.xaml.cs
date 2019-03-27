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
    public partial class VpsDialogWindow : Window
    {
        private readonly VPS _model;
        private readonly IRepositoryContext _context;
        public VpsDialogWindow(VPS vps = null)
        {
            InitializeComponent();

            _model = vps ?? new VPS();
            _context = SimpleRepositoryContext.Of();

            textOs.Text = vps?.OperatingSystem;
            textCpu.Text = vps?.CPU;
            textRam.Text = vps?.RAM;

            cbAdmin.ItemsSource = _context.Get<Admin, IAdminRepository>().All();
            cbOwner.ItemsSource = _context.Get<User, IUserRepository>().All();

            cbAdmin.SelectedItem = vps?.Admin;
            cbOwner.SelectedItem = vps?.Owner;
        }

        private void Button_Add_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                _model.OperatingSystem = textOs.Text;
                _model.CPU = textCpu.Text;
                _model.RAM = textRam.Text;
                _model.Admin = (Admin)cbAdmin.SelectedItem;
                _model.Owner = (User)cbOwner.SelectedItem;

                _context.Get<VPS, IVpsRepository>().Persist(_model);

                _context.PersistState();
                var window = new VpsWindow();
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
