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
using System.Windows.Navigation;
using System.Windows.Shapes;
using Wypozyczalnia.Models.Common.Dtos;
using Wypozyczalnia.Models.Services;
using Wypozyczalnia.Views;

namespace Wypozyczalnia
{
    /// <summary>
    /// Logika interakcji dla klasy MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
       
        private readonly AutorService autorService;
        public MainWindow()
        {
            InitializeComponent();
            autorService = new AutorService();
            

        }

        private void AddAuthorBTN_Click(object sender, RoutedEventArgs e)
        {
            var autorAddWindow = new AutorAddView();
            autorAddWindow.Show();
        }

        private void RefreshAuthorsBTN_Click(object sender, RoutedEventArgs e)
        {
            AuthorsListView.Items.Clear();
            var result = autorService.GetAllAuthors();

            foreach (var r in result)
                this.AuthorsListView.Items.Add(r);
        }

        private void EditAuthorsBTN_Click(object sender, RoutedEventArgs e)
        {
            if (AuthorsListView.SelectedItem == null)
                return;

            var dto = AuthorsListView.SelectedItem as AutorDto;

            var autorEditWindow = new AutorEditView(dto);
            autorEditWindow.Show();


        }
    }
}
