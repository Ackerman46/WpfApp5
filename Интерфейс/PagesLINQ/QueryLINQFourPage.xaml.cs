using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace WpfApp1.Интерфейс.PagesLINQ
{
    /// <summary>
    /// Логика взаимодействия для QueryTwoPage.xaml
    /// </summary>
    public partial class QueryLINQFourPage : Page
    {
        public QueryLINQFourPage()
        {
            InitializeComponent();
        }

        DatabaseContext db = DatabaseContext.GetContext();

        private void btApply_Click(object sender, RoutedEventArgs e)
        {

            var item = from p in db.Абоненты
                       where p.Отчество.Contains(tbPatronymic.Text)
                       select p;
            QueryLINQOnePage.dgLinq = item.ToList();

        }
    }
}
