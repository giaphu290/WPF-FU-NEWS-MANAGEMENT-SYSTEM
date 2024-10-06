using BusinessObjects.Entities;
using Services.IService;
using Services.Service;
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
    /// Interaction logic for AccountWindow.xaml
    /// </summary>
    public partial class AccountWindow : Window
    {
        private readonly ISystemAccountService _accountService;
        private readonly ICategoryService _categoryService;
        public AccountWindow(ISystemAccountService accountService,ICategoryService categoryService)
        {
            InitializeComponent();
            _accountService = accountService;
            _categoryService = categoryService;
            Loaded += loadList;
        }
        private void loadList(object sender, RoutedEventArgs e)
        {
            loadAccount();
        }
        private void loadAccount()
        {
            lvAccounts.ItemsSource = null;
            lvAccounts.ItemsSource = _accountService.GetSystemAccounts();
        }
        private void btnSearch_Click(object sender, RoutedEventArgs e)
        {
            if (txtSearch.Text.Length > 0)
            {
                lvAccounts.ItemsSource = null;
                lvAccounts.ItemsSource = _accountService.Search(txtSearch.Text);
            }
            else
            {
                loadAccount();
            }
        }

        private void btnInsert_Click(object sender, RoutedEventArgs e)
        {
            PopupAccountWindow popupAccountWindow = new PopupAccountWindow(_accountService, _categoryService,null);
          popupAccountWindow.ShowDialog();
            loadAccount();
        }

        private void btnUpdate_Click(object sender, RoutedEventArgs e)
        {
            if (lvAccounts.SelectedItem is SystemAccount selected)
            {
                var popup = new PopupAccountWindow(_accountService, _categoryService,selected);
                popup.ShowDialog();
                loadAccount();
            }
            else
            {
                MessageBox.Show("Please select a account to update.", "No Selection", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            if (lvAccounts.SelectedItem is SystemAccount selected)
            {
                var result = MessageBox.Show("Are you sure you want to delete this account?",
                                              "Confirm Deletion",
                                              MessageBoxButton.YesNo,
                                              MessageBoxImage.Warning);
                if (result == MessageBoxResult.Yes)
                {
                    _accountService.DeleteSystemAccount(selected);
                    loadAccount();
                }
            }
            else
            {
                MessageBox.Show("Please select an account to delete.", "No Selection", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void txtSearch_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (txtSearch.Text.Length > 0)
            {
                lvAccounts.ItemsSource = null;
                lvAccounts.ItemsSource = _accountService.Search(txtSearch.Text);
            }
            else
            {
                loadAccount();
            }
        }

        private void lvAccounts_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
