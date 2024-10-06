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
    /// Interaction logic for CategoryWindow.xaml
    /// </summary>
    public partial class CategoryWindow : Window
    {
        private readonly ICategoryService _categoryService;
        private readonly INewsArticleService _newsArticleService;

        public CategoryWindow(ICategoryService categoryService, INewsArticleService newsArticleService)
        {
            InitializeComponent();
            _categoryService = categoryService;
            _newsArticleService = newsArticleService;
            Loaded += loadList;

        }
        private void loadList(object sender, RoutedEventArgs e)
        {
            loadCategory();
        }
        private void loadCategory()
        {
            lvCategorys.ItemsSource = null;
            lvCategorys.ItemsSource =  _categoryService.GetCategorys();
        }

        private void lvCategorys_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
    
        }

        private void btnInsert_Click(object sender, RoutedEventArgs e)
        {
            PopupCategoryWindow popupCategoryWindow = new PopupCategoryWindow(_categoryService,null);
            popupCategoryWindow.ShowDialog();
            loadCategory();

        }

        private void btnUpdate_Click(object sender, RoutedEventArgs e)
        {
            if (lvCategorys.SelectedItem is Category selectedCategory) 
            { 
            var popup = new PopupCategoryWindow(_categoryService, selectedCategory);
                popup.ShowDialog();
                loadCategory();
            }
            else
            {
                MessageBox.Show("Please select a category to update.", "No Selection", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            if (lvCategorys.SelectedItem is Category selectedCategory)
            {
                var check = _newsArticleService.GetNewsArticleByCategoryId(selectedCategory.CategoryId);
                if (check != null)
                {
                    MessageBox.Show("This catogory belong to another news article?",
                                             "Warning",
                                             MessageBoxButton.OK,
                                             MessageBoxImage.Warning);
                }
                var result = MessageBox.Show("Are you sure you want to delete this category?",
                                              "Confirm Deletion",
                                              MessageBoxButton.YesNo,
                                              MessageBoxImage.Warning);

                if (result == MessageBoxResult.Yes)
                {
                    _categoryService.DeleteCategory(selectedCategory);
                    loadCategory();
                }
            }
            else
            {
                MessageBox.Show("Please select a category to delete.", "No Selection", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void btnSearch_Click(object sender, RoutedEventArgs e)
        {
            if (txtSearch.Text.Length > 0)
            {
                lvCategorys.ItemsSource = null;
                lvCategorys.ItemsSource = _categoryService.Search(txtSearch.Text);
            }
            else
            {
                loadCategory();
            }
        }

        private void txtSearch_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (txtSearch.Text.Length > 0)
            {
                lvCategorys.ItemsSource = null;
                lvCategorys.ItemsSource = _categoryService.Search(txtSearch.Text);
            }
            else
            {
                loadCategory();
            }
        }
    }
}
