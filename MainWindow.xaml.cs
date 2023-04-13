using System.Data.Entity;
using System.Windows;
using System.Collections.Generic;
using WpfApp1.Интерфейс;
using System.Linq;
using WpfApp1.Интерфейс.PagesLINQ;
using WpfApp1.Интерфейс.PagesUpdate;
using WpfApp1.Interface.PagesDelete;

namespace WpfApp1
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        DatabaseContext db = DatabaseContext.GetContext();
        private static List<Абоненты> defaultAbonents = new List<Абоненты>();
        public MainWindow()
        {
            InitializeComponent();
            db.Абоненты.Load();
            dgAbonents.ItemsSource = db.Абоненты.Local.ToBindingList();
            DefaultData();
        }
        private void DefaultData()
        {
            foreach (Абоненты item in db.Абоненты)
            {
                defaultAbonents.Add(item);
            }
        }
        private void AddObj_Click(object sender, RoutedEventArgs e)
        {
            AddObjWin addObjWin = new AddObjWin();
            addObjWin.ShowDialog();
            dgAbonents.Items.Refresh();
        }

        private void EditObj_Click(object sender, RoutedEventArgs e)
        {
            int indexRow = dgAbonents.SelectedIndex;
            if(indexRow != -1)
            {
                var item = (Абоненты)dgAbonents.Items[indexRow];
                Data.Id = item.Id;
                EditObjWin editObjWin = new EditObjWin();
                editObjWin.ShowDialog();
                dgAbonents.Items.Refresh();
            }
            else
            {
                MessageBox.Show("Выберите запись для редактирования.", "ERROR!", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
        }

        private void DeleteObj_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult result = MessageBox.Show("Вы уверены что, хотите удалить запись?", "Удаление", MessageBoxButton.YesNo, MessageBoxImage.Information);
            if(MessageBoxResult.Yes == result)
            {
                int indexRow = dgAbonents.SelectedIndex;
                if(indexRow != -1)
                {
                    var item = (Абоненты)dgAbonents.Items[indexRow];
                    db.Абоненты.Remove(item);
                    db.SaveChanges();
                    dgAbonents.Items.Refresh();
                }
                else
                {
                    MessageBox.Show("Выберите запись для удаления.", "ERROR!", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }
            }
        }

        private void ViewObjBut_Click(object sender, RoutedEventArgs e)
        {
            int indexRow = dgAbonents.SelectedIndex;
            if(indexRow != -1)
            {
                var item = (Абоненты)dgAbonents.Items[indexRow];
                Data.Id = item.Id;
                ViewObjWin viewObjWin = new ViewObjWin();
                viewObjWin.ShowDialog();
                dgAbonents.Items.Refresh();
            }
            else
            {
                MessageBox.Show("Выберите запись для просмотра.", "ERROR!", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
        }

        private void ResetFilter_Click(object sender, RoutedEventArgs e)
        {
            dgAbonents.ItemsSource = defaultAbonents;
        }

        private void CloseProg_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void dgUpdate_Click(object sender, RoutedEventArgs e)
        {
            dgAbonents.Items.Refresh();
            db.ChangeTracker.Entries().ToList().ForEach(x => x.Reload());
        }

        private void AboutProg_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Разработчик");
        }

        private void QueriesLINQ_Click(object sender, RoutedEventArgs e)
        {
            LINQQuery lINQQuery = new LINQQuery();
            lINQQuery.ShowDialog();
            dgAbonents.ItemsSource = QueryLINQOnePage.dgLinq;
            dgAbonents.Items.Refresh();
        }

        private void QueriesUpdate_Click(object sender, RoutedEventArgs e)
        {
            UpdateQuery updateQuery = new UpdateQuery();
            updateQuery.ShowDialog();
            dgAbonents.Items.Refresh();
        }

        private void QueriesDelete_Click(object sender, RoutedEventArgs e)
        {
            DeleteQuery deleteQuery = new DeleteQuery();
            deleteQuery.ShowDialog();
            dgAbonents.ItemsSource = QueryDeleteOnePage.dgResult.ItemsSource;
            dgAbonents.Items.Refresh();
        }
    }
    public class Data
    {
        public static int Id;
    }
}
