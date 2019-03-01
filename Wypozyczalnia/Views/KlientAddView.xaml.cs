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
using Wypozyczalnia.Models.Services;

namespace Wypozyczalnia.Views
{
    /// <summary>
    /// Logika interakcji dla klasy KlientAddView.xaml
    /// </summary>
    public partial class KlientAddView : Window
    {
        private readonly KlientService klientService;
        public KlientAddView()
        {
            klientService = new KlientService();
            InitializeComponent();

        }
        private void Zapisz_Click(object sender, RoutedEventArgs e)
        {
            klientService.AddKlient(NazwiskoKlientaTxtBox.Text);
            this.Close();
        }
    }
}
