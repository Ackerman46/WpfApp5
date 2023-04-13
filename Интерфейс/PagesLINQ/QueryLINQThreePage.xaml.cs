using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace WpfApp1.Интерфейс.PagesLINQ
{
    /// <summary>
    /// Логика взаимодействия для QueryTwoPage.xaml
    /// </summary>
    public partial class QueryLINQThreePage : Page
    {
        public QueryLINQThreePage()
        {
            InitializeComponent();
        }

        DatabaseContext db = DatabaseContext.GetContext();

        private void btApply_Click(object sender, RoutedEventArgs e)
        {

            var item = from p in db.Абоненты
                       where p.Тип_установки_телефона.Contains(tbPhoneSetup.Text)
                       select p;
            QueryLINQOnePage.dgLinq = item.ToList();

        }
    }
}
