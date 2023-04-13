using System;
using System.Linq;
using System.Text;
using System.Windows;
using System.Xml.Linq;

namespace WpfApp1.Интерфейс
{
    /// <summary>
    /// Логика взаимодействия для EditObjWin.xaml
    /// </summary>
    public partial class EditObjWin : Window
    {
        public EditObjWin()
        {
            InitializeComponent();
        }
        DatabaseContext db = DatabaseContext.GetContext();
        Абоненты Абоненты = new Абоненты();

        private void ChangeData_Click(object sender, RoutedEventArgs e)
        {
            StringBuilder errors = new StringBuilder();
            if (tbMiddleName.Text == null || tbMiddleName.Text == "") errors.AppendLine("Введите фамилию");
            if (tbName.Text == null || tbName.Text == "") errors.AppendLine("Введите имя");
            if (tbPatronymic.Text == null || tbPatronymic.Text == "") errors.AppendLine("Введите отчество");
            if (tbTelephoneNumber.Text.Length > 11) errors.AppendLine("Номер телефона не может быть больше 11 (Пример: 79832340987)");
            if (tbPhoneSetup.Text == null || tbPhoneSetup.Text == "") errors.AppendLine("Введите тип установки телефона");
            if (int.TryParse(tbBenefit.Text, out int benefit) && benefit < 0) errors.AppendLine("Введите льготу");
            if (dtYearInstallation.SelectedDate == null) errors.AppendLine("Выберите дату установки телефона");

            if (errors.Length > 0)
            {
                MessageBox.Show($"{errors}", "ERROR!", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            Абоненты.Фамилия = tbMiddleName.Text;
            Абоненты.Отчество = tbPatronymic.Text;
            Абоненты.Имя = tbName.Text;
            Абоненты.Номер_телефона = tbTelephoneNumber.Text;
            Абоненты.Год_установки = dtYearInstallation.SelectedDate;
            Абоненты.Льгота = benefit;
            Абоненты.Тип_установки_телефона = tbPhoneSetup.Text;

            try
            {
                db.SaveChanges();
                Close();
            }
            catch
            {
                return;
            }
        }

        private void Stopbut_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            Абоненты = db.Абоненты.Find(Data.Id);
            tbBenefit.Text = Convert.ToString(Абоненты.Льгота);
            tbMiddleName.Text = Абоненты.Фамилия;
            tbName.Text = Абоненты.Имя;
            tbPatronymic.Text = Абоненты.Отчество;
            tbPhoneSetup.Text = Абоненты.Тип_установки_телефона;
            tbTelephoneNumber.Text = Абоненты.Номер_телефона;
            dtYearInstallation.SelectedDate = Абоненты.Год_установки;
        }
    }
}
