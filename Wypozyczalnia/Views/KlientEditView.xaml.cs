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
    /// Logika interakcji dla klasy KlientEditView.xaml
    /// </summary>
    public partial class KlientEditView : Window
    {
        private KlientDto _dto;
        private KlientService service;
        public KlientEditView(KlientDto dto)
        {
            if (dto == null)
                throw new ArgumentNullException(nameof(dto));

            InitializeComponent();
            _dto = dto;
            KlientNazwiskoTxtBox.Text = dto.Nazwisko;
            service = new KlientService();
        }

        private void ZapiszZmianyBTN_Click(object sender, RoutedEventArgs e)
        {
            _dto.Nazwisko = KlientNazwiskoTxtBox.Text;
            service.UpdateKlient(_dto);
            this.Close();
        }
    }
}
