using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace WpfApp1.Интерфейс.PagesLINQ
{
    /// <summary>
    /// Логика взаимодействия для QueryTwoPage.xaml
    /// </summary>
    public partial class QueryLINQFivePage : Page
    {
        public QueryLINQFivePage()
        {
            InitializeComponent();
        }

        DatabaseContext db = DatabaseContext.GetContext();

        private void btApply_Click(object sender, RoutedEventArgs e)
        {
            int.TryParse(tbNumberAbonent.Text, out int numberId);
            var item = from p in db.Абоненты
                       where p.Id == numberId
                       select p;
            QueryLINQOnePage.dgLinq = item.ToList();

        }
    }
}
