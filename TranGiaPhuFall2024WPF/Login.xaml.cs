
using BusinessObjects.Entities;
using Microsoft.Identity.Client.NativeInterop;
using Repositories.IRepository;
using Services.IService;
using Services.Validator;
using System.Windows;
using System.Windows.Controls;

namespace TranGiaPhuFall2024WPF
{
    /// <summary>
    /// Interaction logic for Login.xaml
    /// </summary>
    public partial class Login : Window
    {

        private readonly ISystemAccountService _accountService;
        private readonly ICategoryService _categoryService;
        private readonly INewsArticleService _newsArticleService;
        private readonly ITagService _tagService;

        public SystemAccount LoggedInAccount { get; private set; } = null;

        public Login(ISystemAccountService accountService, ICategoryService categoryService, INewsArticleService newsArticleService,ITagService tagService)
        {
            InitializeComponent();
            _accountService = accountService;
            _categoryService = categoryService;
            _newsArticleService = newsArticleService;
            _tagService = tagService;
        }

        private void txtUser_TextChanged(object sender, TextChangedEventArgs e)
        {
           

        }
        private void txtPass_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void btnLogin_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(txtUser.Text) || string.IsNullOrEmpty(txtPass.Password))
            {
                MessageBox.Show("You need to fill in Email and Password!", "Input required", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            if (!InputValidator.IsValidEmail(txtUser.Text))
            {
                MessageBox.Show("Please enter a valid email address", "Validation Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            if (!InputValidator.IsValidPassword(txtPass.Password))
            {
                MessageBox.Show("Password must be at least 2 characters long", "Validation Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            //Check Account
            var a = _accountService.LoginByEmail(txtUser.Text, txtPass.Password);
            var adminAccount = _accountService.AdminLogin(txtUser.Text, txtPass.Password);
            if (a == null && !adminAccount) {
            MessageBox.Show("Login failed, Please check username and password again!", "Wrong credentials", MessageBoxButton.OK, MessageBoxImage.Exclamation);
                return;
            }
            // Staff role
            if(a !=null)
            {
                LoggedInAccount = a;
                MessageBox.Show("Logged in successfully");
                MainWindow mainWindow = new MainWindow(_accountService,_categoryService,_newsArticleService,_tagService, LoggedInAccount, false);
                mainWindow.Show();
                this.Close();
            }
            //Lecture role
            else if(adminAccount == true)
            {
                MessageBox.Show("Logged in successfully");
                MainWindow mainWindow = new MainWindow(_accountService, _categoryService, _newsArticleService,_tagService, null, false);
                mainWindow.Show();
                this.Close();
            }
            else
            {
                MessageBox.Show("You have no permission to access this function!", "Access denied", MessageBoxButton.OK, MessageBoxImage.Stop);
            }
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult result = MessageBox.Show("No Login?",
                                               "Exit",
                                               MessageBoxButton.YesNo,
                                               MessageBoxImage.Question);

            if (result == MessageBoxResult.No)
            {
                return;
            }

           Close();
        }

        private void btnGuest_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow(_accountService, _categoryService, _newsArticleService,_tagService, null, true);
            mainWindow.Show();
            this.Close();
        }
    }
}
