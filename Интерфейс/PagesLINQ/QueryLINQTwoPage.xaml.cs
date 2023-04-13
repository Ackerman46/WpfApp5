using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace WpfApp1.Интерфейс.PagesLINQ
{
    /// <summary>
    /// Логика взаимодействия для QueryTwoPage.xaml
    /// </summary>
    public partial class QueryLINQTwoPage : Page
    {
        public QueryLINQTwoPage()
        {
            InitializeComponent();
        }

        DatabaseContext db = DatabaseContext.GetContext();

        private void btApply_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var item = from p in db.Абоненты
                           where p.Номер_телефона.Contains(tbTelephone.Text)
                           select p;
                QueryLINQOnePage.dgLinq = item.ToList();
            }
            catch
            {
                db.ChangeTracker.Entries().ToList().ForEach(x => x.Reload());
            }
        }
    }
}
