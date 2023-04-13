using System.Linq;
using System.Windows;
using System.Windows.Controls;
using WpfApp1.Interface.PagesDelete;

namespace WpfApp1.Interface.Pages
{
    /// <summary>
    /// Логика взаимодействия для QueryTwoPage.xaml
    /// </summary>
    public partial class QueryDeleteTwoPage : Page
    {
        public QueryDeleteTwoPage()
        {
            InitializeComponent();
        }

        DatabaseContext db = DatabaseContext.GetContext();

        private void btApply_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                QueryDeleteOnePage.dgResult.ItemsSource = db.Абоненты.SqlQuery($"DELETE FROM Абоненты WHERE Id = '{tbDelId.Text}'").ToList();
            }
            catch
            {
                db.ChangeTracker.Entries().ToList().ForEach(x => x.Reload());
            }
        }
    }
}
