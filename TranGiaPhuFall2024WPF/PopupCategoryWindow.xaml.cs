using BusinessObjects.Entities;
using Microsoft.Identity.Client.NativeInterop;
using Microsoft.VisualBasic.Logging;
using Services.IService;
using System;
using System.Collections.Generic;
using System.Diagnostics;
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
    /// Interaction logic for PopupCategoryWindow.xaml
    /// </summary>
    public partial class PopupCategoryWindow : Window
    {

        public Category CurrentCategory { get; set; } = null;
        public List<Category> CategoryList { get; set; } = null;

        private readonly ICategoryService _categoryService;
        public PopupCategoryWindow(ICategoryService categoryService,Category category)
        {
            InitializeComponent();
            _categoryService = categoryService;
            CategoryList = _categoryService.GetCategorys().ToList();
            if (category != null)
            {
                txtHeader.Text = "Update Category";
                CurrentCategory = category;
            }
            else
            {
                grdId.Visibility = Visibility.Collapsed;
                txtHeader.Text = "Create Category";
                cbIsActice.Visibility = Visibility.Hidden;
                tbActice.Visibility = Visibility.Hidden;
                CurrentCategory = null;
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

        private void btnCancle_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(txtCategoryName.Text) ||
             string.IsNullOrEmpty(txtCategoryDesciption.Text) ||
             cbbParentCategory.SelectedValue == null)
            {
                MessageBox.Show("Please fill in all fields", "Validation Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
       
            if (CurrentCategory != null)
            {
                Category category = new Category()
                {
                    CategoryId = CurrentCategory.CategoryId,
                    CategoryName = txtCategoryName.Text,
                    CategoryDesciption = txtCategoryDesciption.Text,
                    ParentCategoryId = short.Parse(cbbParentCategory.SelectedValue.ToString()),
                    IsActive = cbIsActice.IsChecked

                };
                try
                {
                    _categoryService.UpdateCategory(category);
                    MessageBox.Show("Update successfully", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Update failed: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            else
            {
                Category category = new Category()
                {
                    CategoryName = txtCategoryName.Text,
                    CategoryDesciption = txtCategoryDesciption.Text,
                    ParentCategoryId = short.Parse(cbbParentCategory.SelectedValue.ToString()),
                    IsActive = true

                };
                try
                {
                    _categoryService.InsertCategory(category);
                    MessageBox.Show("Add successfully", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Add failed: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            this.Close();

        }
    }
}
