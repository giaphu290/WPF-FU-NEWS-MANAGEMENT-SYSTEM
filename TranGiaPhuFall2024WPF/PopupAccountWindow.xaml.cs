using BusinessObjects.Entities;
using Services.IService;
using Services.Service;
using Services.Validator;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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
    /// Interaction logic for PopupAccountWindow.xaml
    /// </summary>
    public partial class PopupAccountWindow : Window
    {
        public SystemAccount CurrentAccount { get; set; } = null;
        public List<SystemAccount> SystemAccountList { get; set; }
        public List<Category> CategoryList { get; set; }
        private readonly ISystemAccountService _accountService;
        private readonly ICategoryService _categoryService;
        public PopupAccountWindow(ISystemAccountService accountService,ICategoryService categoryService, SystemAccount systemAccount)
        {
            InitializeComponent();
            _accountService = accountService;
            _categoryService = categoryService;
            SystemAccountList = _accountService.GetSystemAccounts().ToList();
            CategoryList = _categoryService.GetCategorys().ToList();
            if (systemAccount != null)
            {
                txtHeader.Text = "Update Account";
                CurrentAccount = systemAccount;

            }
            else
            {
                grdId.Visibility = Visibility.Collapsed;
                txtHeader.Text = "Create Account";
                CurrentAccount = null;

            }
            DataContext = this;

        }
        private void Border_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left)
            {
                this.DragMove();
            }
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(txtAccountName.Text) ||
           string.IsNullOrEmpty(txtAccountEmail.Text) ||
           cmbAccountRole.SelectedValue == null ||
           string.IsNullOrEmpty(txtAccountPassword.Text))
            {
                MessageBox.Show("Please fill in all fields", "Validation Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            if (!InputValidator.IsValidEmail(txtAccountEmail.Text))
            {
                MessageBox.Show("Please enter a valid email address", "Validation Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            if (!InputValidator.IsValidPassword(txtAccountPassword.Text))
            {
                MessageBox.Show("Password must be at least 2 characters long", "Validation Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            ComboBoxItem selectedRole = cmbAccountRole.SelectedItem as ComboBoxItem;
            int accountRole = int.Parse(selectedRole.Tag.ToString());
            SystemAccount account = new SystemAccount()
            {
                AccountId = CurrentAccount != null ? CurrentAccount.AccountId : (short)(_accountService.GetAccountWithMaxId().AccountId + 1),
                AccountName = txtAccountName.Text,
                AccountEmail = txtAccountEmail.Text,
                AccountPassword = txtAccountPassword.Text,
                AccountRole = accountRole,
            };

            if (CurrentAccount != null)
            {
                try
                {
                    _accountService.UpdateSystemAccount(account); 
                    MessageBox.Show("Update successfully", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Update failed: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }

            }
            else
            {
               
                try
                {
                    _accountService.InsertSystemAccount(account);
                    MessageBox.Show("Add successfully", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Add failed: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }

            }

            this.Close();
        }

        private void btnCancle_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
