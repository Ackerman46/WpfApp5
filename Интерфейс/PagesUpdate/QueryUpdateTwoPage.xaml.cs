using System.Data.Entity;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace WpfApp1.Интерфейс.PagesUpdate
{
    /// <summary>
    /// Логика взаимодействия для QueryTwoPage.xaml
    /// </summary>
    public partial class QueryUpdateTwoPage : Page
    {
        public QueryUpdateTwoPage()
        {
            InitializeComponent();
        }

        DatabaseContext db = DatabaseContext.GetContext();


        private void btApply_Click(object sender, RoutedEventArgs e)
        {
            try
            {
              db.Абоненты.SqlQuery($"UPDATE Абоненты SET Тип_установки_телефона = '{tbNewPhoneNumber.Text}' WHERE Тип_установки_телефона = '{tbOldPhoneNumber.Text}'").ToList();
            }
            catch
            { 
                db.ChangeTracker.Entries().ToList().ForEach(x => x.Reload());
            }
        }
    }
}
