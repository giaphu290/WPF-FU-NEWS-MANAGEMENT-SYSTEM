using BusinessObjects.Entities;
using Microsoft.Identity.Client.NativeInterop;
using Services.IService;
using System.Runtime.InteropServices;
using System.Windows;
namespace TranGiaPhuFall2024WPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly ISystemAccountService _accountService ;
        private readonly ICategoryService _categoryService;
        private readonly INewsArticleService _newsArticleService;
        private readonly ITagService _tagService;
        public bool _isguest;
        public SystemAccount LoggedInAccount { get; set; } = null;
        public MainWindow(ISystemAccountService accountService, ICategoryService categoryService, INewsArticleService newsArticleService,ITagService tagService,SystemAccount systemAccount, bool isGuest)
        {
            InitializeComponent();
            _accountService = accountService;
            _categoryService = categoryService;
            _newsArticleService = newsArticleService;
            _tagService = tagService;
            _isguest = isGuest;
            LoggedInAccount = systemAccount;
            if (_isguest == false)
            {
                if (LoggedInAccount != null )
                {
                    //Staff
                    if (LoggedInAccount.AccountRole == 1)
                    {
                        ShowStaffUI();
                        tbRole.Text = "Staff";
                        loadNewsArticle();
                    }
                    if (LoggedInAccount.AccountRole == 2)
                    {
                        tbRole.Text = "Lecture";
                        ShowGuestUI();
                        loadNewsArticle();
                    }
                }
                else
                {
                    tbRole.Text = "Admin";
                    ShowAdminUI();
                    loadNewsArticle();
                }
            }
            else
            {
                tbRole.Text = "Guest";
                miExit.Header = "Back";
                ShowGuestUI();
                miLogout.Visibility = Visibility.Collapsed;
                loadNewsArticle();
            }
            Loaded += loadList;
        }
        private void loadList(object sender, RoutedEventArgs e)
        {
            loadNewsArticle();
        }
        private void loadNewsArticle() 
        {
            lvNewArticles.ItemsSource = null;
            lvNewArticles.ItemsSource = _newsArticleService.GetNewsArticles();
        
        }
       
        private void miCategory_Click(object sender, RoutedEventArgs e)
        {
            CategoryWindow categoryWindow = new CategoryWindow(_categoryService,_newsArticleService);
            categoryWindow.ShowDialog();

        }

        private void miHistory_Click(object sender, RoutedEventArgs e)
        {
            var count = _newsArticleService.GetNewsArticleByAccountId(LoggedInAccount.AccountId).ToList();
            if (count.Count < 1)
            {
                MessageBox.Show("User: " + LoggedInAccount.AccountName + " don't have any news article", "Note", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else
            {
                HistoryNewsArticle article = new HistoryNewsArticle(_newsArticleService, LoggedInAccount);
                article.ShowDialog();
            }
        }

        private void miProfile_Click(object sender, RoutedEventArgs e)
        {
            PopupProfileWindow popupProfileWindow = new PopupProfileWindow(_accountService, LoggedInAccount);
            popupProfileWindow.ShowDialog();
        }

        private void miAccount_Click(object sender, RoutedEventArgs e)
        {
            AccountWindow accountWindow = new AccountWindow(_accountService,_categoryService);
            accountWindow.ShowDialog();
        }

        private void btnCreateReport_Click(object sender, RoutedEventArgs e)
        {
            ReportNewsArticle report = new ReportNewsArticle(_newsArticleService);
            report.ShowDialog();
        }

        private void btnCreate_Click(object sender, RoutedEventArgs e)
        {
            PopupNewsArticle popupNewsArticle = new PopupNewsArticle(_newsArticleService, _categoryService,_tagService,LoggedInAccount,null);
            popupNewsArticle.ShowDialog();
            loadNewsArticle();
        }

        private void btnUpdate_Click(object sender, RoutedEventArgs e)
        {
         
            if (lvNewArticles.SelectedItem is NewsArticle newsArticle )
            {
                PopupNewsArticle popupNewsArticle = new PopupNewsArticle(_newsArticleService,_categoryService,_tagService, LoggedInAccount, newsArticle);
                popupNewsArticle.ShowDialog();
                loadNewsArticle();
            }
            else
            {
                MessageBox.Show("Please select a news article to update.", "No Selection", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            if (lvNewArticles.SelectedItem is NewsArticle newsArticle)
            {
                var result = MessageBox.Show("Are you sure you want to delete this news article?",
                                              "Confirm Deletion",
                                              MessageBoxButton.YesNo,
                                              MessageBoxImage.Warning);

                if (result == MessageBoxResult.Yes)
                {
                    _newsArticleService.DeleteNewsArticle(newsArticle);
                    loadNewsArticle();
                }
            }
            else
            {
                MessageBox.Show("Please select a news article to delete.", "No Selection", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }
        private void miExit_Click(object sender, RoutedEventArgs e)
        {
            if (_isguest == true)
            {
                Login loginWindow = new Login(_accountService, _categoryService, _newsArticleService,_tagService );
                loginWindow.Show();
                this.Close();
           
            }
            else
            {
                MessageBoxResult result = MessageBox.Show("Do you want to exit",
                                              "Exit",
                                              MessageBoxButton.YesNo,
                                              MessageBoxImage.Question);

                if (result == MessageBoxResult.No)
                {
                    return;
                }

                Application.Current.Shutdown();
            }
     
        }
        private void ShowStaffUI()
        {
            miCategory.Visibility = Visibility.Visible;
            miProfile.Visibility = Visibility.Visible;
            miHistory.Visibility = Visibility.Visible;
            btnCreate.Visibility = Visibility.Visible;
            btnDelete.Visibility = Visibility.Visible;
            btnUpdate.Visibility = Visibility.Visible;
        }
        private void ShowGuestUI()
        {
            miCategory.Visibility = Visibility.Hidden;
            miProfile.Visibility = Visibility.Hidden;
            miHistory.Visibility = Visibility.Hidden;
        }
        private void ShowAdminUI()
        {
            miAccount.Visibility = Visibility.Visible;
            btnCreateReport.Visibility = Visibility.Visible;
        }

        private void miLogout_Click(object sender, RoutedEventArgs e)
        {
            LoggedInAccount = null;
            Login loginWindow = new Login(_accountService, _categoryService, _newsArticleService,_tagService);
            loginWindow.Show();
            this.Close();
        }

        private void btnSearch_Click(object sender, RoutedEventArgs e)
        {
           
            if (txtSearch.Text.Length > 0) 
            {
                lvNewArticles.ItemsSource = null;
                lvNewArticles.ItemsSource = _newsArticleService.Search(txtSearch.Text);
            }
            else
            {
                loadNewsArticle();
            }

        }

        private void txtSearch_TextChanged(object sender, System.Windows.Controls.TextChangedEventArgs e)
        {
            if (txtSearch.Text.Length > 0)
            {
                lvNewArticles.ItemsSource = null;
                lvNewArticles.ItemsSource = _newsArticleService.Search(txtSearch.Text);
            }
            else
            {
                loadNewsArticle();
            }
        }
    }
}