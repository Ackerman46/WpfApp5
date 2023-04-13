using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;


namespace WpfApp1.Интерфейс
{
    /// <summary>
    /// Логика взаимодействия для AddObjWin.xaml
    /// </summary>

    public partial class AddObjWin : Window
    {
        DatabaseContext db = DatabaseContext.GetContext();
        Абоненты Абоненты = new Абоненты();
        public AddObjWin()
        {
            InitializeComponent();
        }

        private void AddObj_Click(object sender, RoutedEventArgs e)
        {
            StringBuilder errors = new StringBuilder();
            if (tbMiddleName.Text == null || tbMiddleName.Text == "") errors.AppendLine("Введите фамилию");
            if (tbName.Text == null || tbName.Text == "") errors.AppendLine("Введите имя");
            if (tbPatronymic.Text == null || tbPatronymic.Text == "") errors.AppendLine("Введите отчество");
            if (tbTelephoneNumber.Text.Length > 11) errors.AppendLine("Номер телефона не может быть больше 11 (Пример: 79832340987)");
            if (tbPhoneSetup.Text == null || tbPhoneSetup.Text == "") errors.AppendLine("Введите тип установки телефона");
            if (int.TryParse(tbBenefit.Text, out int benefit) && benefit < 0) errors.AppendLine("Введите льготу");
            if (dtYearInstallation.SelectedDate == null) errors.AppendLine("Выберите дату установки телефона");

            if(errors.Length > 0)
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
                db.Абоненты.Add(Абоненты);
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
    }
}
