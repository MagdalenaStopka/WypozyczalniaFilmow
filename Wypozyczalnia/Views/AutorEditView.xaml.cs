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
using Wypozyczalnia.Models.Common.Dtos;
using Wypozyczalnia.Models.Services;

namespace Wypozyczalnia.Views
{
    /// <summary>
    /// Logika interakcji dla klasy AutorEditView.xaml
    /// </summary>
    public partial class AutorEditView : Window
    {
        private readonly AutorService authorsService;
        private AutorDto _dto;
        public AutorEditView(AutorDto dto)
        {
            _dto = dto ?? throw new ArgumentNullException(nameof(dto));
            InitializeComponent();
            authorsService = new AutorService();
        }

        private void ZapiszZmianyBTN_Click(object sender, RoutedEventArgs e)
        {
            var authorsService = new AutorService();
            _dto.Nazwisko = AutorNazwiskoTxtBox.Text;
            authorsService.UpdateAutor(_dto);
            this.Close();
        }
    }
}

