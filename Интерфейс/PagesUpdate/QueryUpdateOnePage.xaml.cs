using System.Data.Entity;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace WpfApp1.Интерфейс.PagesUpdate
{
    /// <summary>
    /// Логика взаимодействия для QueryOnePage.xaml
    /// </summary>
    public partial class QueryUpdateOnePage : Page
    {
        DatabaseContext db = DatabaseContext.GetContext();

        public QueryUpdateOnePage()
        {
            InitializeComponent();
        }
        private void btApply_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                db.Database.ExecuteSqlCommand($"UPDATE Абоненты SET Льгота = '{tbNewBenefit.Text}' WHERE Льгота = {tbOldBenefit.Text}");
                db.ChangeTracker.Entries().ToList().ForEach(x => x.Reload());
            }
            catch
            {

                
            }
        }
    }
}
