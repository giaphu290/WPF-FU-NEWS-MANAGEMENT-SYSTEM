using BusinessObjects.Entities;
using Services.IService;
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
    /// Interaction logic for HistoryNewsArticle.xaml
    /// </summary>
    public partial class HistoryNewsArticle : Window
    {
        private readonly INewsArticleService _newsArticle;
        public SystemAccount LoggedInAccount;
        public HistoryNewsArticle(INewsArticleService newsArticle,SystemAccount systemAccount)
        {
            InitializeComponent();
            _newsArticle = newsArticle;
            LoggedInAccount = systemAccount;
            loadList();
        }
        private void loadList()
        {
            lvNewArticles.ItemsSource = _newsArticle.GetNewsArticleByAccountId(LoggedInAccount.AccountId);
        }
        private void lvNewArticles_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
