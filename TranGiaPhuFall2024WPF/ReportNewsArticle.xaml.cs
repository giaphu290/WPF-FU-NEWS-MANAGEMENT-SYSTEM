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
    /// Interaction logic for ReportNewsArticle.xaml
    /// </summary>
    public partial class ReportNewsArticle : Window
    {
        private readonly INewsArticleService _newsArticleService;
        public ReportNewsArticle(INewsArticleService newsArticleService)
        {
            InitializeComponent();
            _newsArticleService = newsArticleService;

        }

        private void btnGenerateReport_Click(object sender, RoutedEventArgs e)
        {
            lvNewArticles.ItemsSource = null;
            if (dpStartDate.SelectedDate.HasValue && dpEndDate.SelectedDate.HasValue)
            {
                if (dpStartDate.SelectedDate.Value > dpEndDate.SelectedDate.Value)
                {
                    MessageBox.Show("Star date must be lower than end date.", "Validation Error", MessageBoxButton.OK, MessageBoxImage.Error);

                }
                DateTime startDate = dpStartDate.SelectedDate.Value; 
                DateTime endDate = dpEndDate.SelectedDate.Value; 

                var newsArticles = _newsArticleService.Report(startDate, endDate);
                lvNewArticles.ItemsSource = newsArticles; 
            }
            else
            {
                MessageBox.Show("Please select both start and end dates.", "Validation Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
