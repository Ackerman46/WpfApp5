using System;
using System.Windows;


namespace WpfApp1.Интерфейс
{
    /// <summary>
    /// Логика взаимодействия для ViewObjWin.xaml
    /// </summary>
    public partial class ViewObjWin : Window
    {
        public ViewObjWin()
        {
            InitializeComponent();
        }
        Абоненты Абоненты = new Абоненты();
        DatabaseContext db = DatabaseContext.GetContext();

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
