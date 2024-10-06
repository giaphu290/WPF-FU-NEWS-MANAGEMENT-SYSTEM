using BusinessObjects.Entities;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Microsoft.Identity.Client.NativeInterop;
using Services.IService;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
    /// Interaction logic for PopupNewsArticle.xaml
    /// </summary>
    public partial class PopupNewsArticle : Window
    {
        public NewsArticle CurrentNewsArticle { get; set; } =  null;
        public SystemAccount _loggedInAccount  = null;
        private readonly ICategoryService _categoryService;
        private readonly INewsArticleService _newsArticleService;
        private readonly ITagService _tagService;
        public List<Category> CategoryList { get; set; } = null;
        public ObservableCollection<Tag>  AddedTag { get; set; }
        public List<Tag> AvailableTags { get; set; }
        public Tag SelectedTag { get; set; } = null;
        public PopupNewsArticle(INewsArticleService newsArticleService,ICategoryService categoryService, ITagService tagService,SystemAccount systemAccount,NewsArticle newsArticle  )
        {
            InitializeComponent();
            _newsArticleService = newsArticleService;
            _categoryService = categoryService;
            _tagService = tagService;

            _loggedInAccount = systemAccount;
            CategoryList = _categoryService.GetCategorys().ToList();
            if (newsArticle != null)
            {
                txtHeader.Text = "Update News Article";
                CurrentNewsArticle = newsArticle;
                AvailableTags = _tagService.GetAvailableTagsForArticle(CurrentNewsArticle.NewsArticleId).ToList();

            }
            else
            {
                grdId.Visibility = Visibility.Collapsed;
                txtHeader.Text = "Create News Article";
                cbIsActice.Visibility = Visibility.Hidden;
                tbActice.Visibility = Visibility.Hidden;
                CurrentNewsArticle = null;
                AvailableTags = _tagService.GetTags().ToList();
            }
            AddedTag = new ObservableCollection<Tag>(CurrentNewsArticle?.Tags ?? new List<Tag>());
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
            if(string.IsNullOrEmpty(tbNewsTitle.Text) ||
                string.IsNullOrEmpty(tbNewsContent.Text) ||
                string.IsNullOrEmpty(tbHeadline.Text) ||
                string.IsNullOrEmpty(tbNewsSource.Text) ||
                cbbCategory.SelectedValue == null)
            {
                MessageBox.Show("Please fill in all fields", "Validation Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return; 
            }
            if (CurrentNewsArticle != null)
            {
                NewsArticle newsArticle = new NewsArticle()
                {

                    NewsArticleId = CurrentNewsArticle.NewsArticleId,
                    NewsTitle = tbNewsTitle.Text,
                    Headline = tbHeadline.Text,
                    CreatedDate = CurrentNewsArticle.CreatedDate,
                    NewsContent = tbNewsContent.Text,
                    NewsSource = tbNewsSource.Text,
                    CategoryId = short.Parse(cbbCategory.SelectedValue.ToString()),
                    NewsStatus = cbIsActice.IsChecked,
                    CreatedById = CurrentNewsArticle.CreatedById,
                    UpdatedById = _loggedInAccount.AccountId,
                    ModifiedDate = DateTime.Now,
                    Tags = AddedTag.ToList()
                };
                try
                {
                    _newsArticleService.UpdateNewsArticle(newsArticle);
                    MessageBox.Show("Update successfully", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Update failed: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            else
            {
                NewsArticle newsArticle = new NewsArticle()
                {
                    NewsArticleId = (int.Parse(_newsArticleService.GetNewsArticleWithMaxId().NewsArticleId) + 1).ToString(),
                    NewsTitle = tbNewsTitle.Text,
                    Headline = tbHeadline.Text,
                    CreatedDate = DateTime.Now,
                    NewsContent = tbNewsContent.Text,
                    NewsSource = tbNewsSource.Text,
                    CategoryId = short.Parse(cbbCategory.SelectedValue.ToString()),
                    NewsStatus = true,
                    CreatedById = _loggedInAccount.AccountId,
                    UpdatedById = _loggedInAccount.AccountId,
                    ModifiedDate = DateTime.Now,
                    Tags = AddedTag.ToList(),

                };
                try
                {
                    _newsArticleService.InsertNewsArticle(newsArticle);
                    MessageBox.Show("Add successfully", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Add failed: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }

            }
            this.Close();
        }
        private void AddTag_Click(object sender, RoutedEventArgs e)
        {
            if (SelectedTag != null)
            {
                AddedTag.Add(SelectedTag);
                AvailableTags.Remove(SelectedTag);

                AvailableTagsComboBox.ItemsSource = null;
                AvailableTagsComboBox.ItemsSource = AvailableTags;
                SelectedTag = null;
            }

        }
        private void RemoveTag_Click(object sender, RoutedEventArgs e)
        {
            var tagToRemove = (sender as FrameworkElement).DataContext as Tag;

            if (tagToRemove != null)
            {
                AddedTag.Remove(tagToRemove);
                AvailableTags.Add(tagToRemove);

                AvailableTagsComboBox.ItemsSource = null;
                AvailableTagsComboBox.ItemsSource = AvailableTags;
            }
        }
        private void btnCancle_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
