using BusinessObjects.Entities;
using Services.IService;
using Services.Service;
using Services.Validator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace TranGiaPhuFall2024WPF
{
    /// <summary>
    /// Interaction logic for PopupProfileWindow.xaml
    /// </summary>
    public partial class PopupProfileWindow : Window
    {
        public SystemAccount CurrentAccount { get; set; } = null;
        private readonly ISystemAccountService _accountService;
        public PopupProfileWindow(ISystemAccountService accountService, SystemAccount systemAccount)
        {
            InitializeComponent();
            _accountService = accountService;
            CurrentAccount = systemAccount;
            DataContext = this;

        }
        private void Border_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left)
            {
                this.DragMove();
            }
        }

        private void btnCancle_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {

            if (string.IsNullOrEmpty(tbAccountId.Text) ||
               string.IsNullOrEmpty(tbProfileName.Text) ||
               string.IsNullOrEmpty(tbProfileEmail.Text) ||
               string.IsNullOrEmpty(tbProfilePassword.Text))
            {
                MessageBox.Show("Please fill in all fields", "Validation Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            if (!InputValidator.IsValidEmail(tbProfileEmail.Text))
            {
                MessageBox.Show("Please enter a valid email address", "Validation Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            if (!InputValidator.IsValidPassword(tbProfilePassword.Text))
            {
                MessageBox.Show("Password must be at least 2 characters long", "Validation Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
                SystemAccount account = new SystemAccount()
                {

                    AccountId = CurrentAccount.AccountId,
                    AccountName = tbProfileName.Text,
                    AccountEmail = tbProfileEmail.Text,
                    AccountPassword = tbProfilePassword.Text,
                    AccountRole = CurrentAccount.AccountRole


                };
                try
                {
                    _accountService.UpdateSystemAccount(account);
                    MessageBox.Show("Update successfully", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Update failed: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
                this.Close();
            }
        }
    }

