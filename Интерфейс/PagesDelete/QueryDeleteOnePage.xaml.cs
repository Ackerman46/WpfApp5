using System.Data.Entity;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace WpfApp1.Interface.PagesDelete
{
    /// <summary>
    /// Логика взаимодействия для QueryOnePage.xaml
    /// </summary>
    public partial class QueryDeleteOnePage : Page
    {
        DatabaseContext db = DatabaseContext.GetContext();
        public static DataGrid dgResult = new DataGrid();
        public QueryDeleteOnePage()
        {
            InitializeComponent();
        }

        private void btApply_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                dgResult.ItemsSource = db.Абоненты.SqlQuery($"DELETE FROM Абоненты WHERE Фамилия = '{tbDelName.Text}'").ToList();
                db.ChangeTracker.Entries().ToList().ForEach(x => x.Reload());
            }
            catch
            {
                db.Абоненты.Load();
                dgResult.ItemsSource = db.Абоненты.Local.ToBindingList();
                db.ChangeTracker.Entries().ToList().ForEach(x => x.Reload());
            }
        }
    }
}
