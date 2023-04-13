using System;
using System.Data.Entity;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Collections.Generic;

namespace WpfApp1.Интерфейс.PagesLINQ
{
    /// <summary>
    /// Логика взаимодействия для QueryOnePage.xaml
    /// </summary>
    public partial class QueryLINQOnePage : Page
    {
        DatabaseContext db = DatabaseContext.GetContext();
        public static List<Абоненты> dgLinq = new List<Абоненты>();

        public QueryLINQOnePage()
        {
            InitializeComponent();
        }

        private void btApply_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                db.Абоненты.Load();
                int.TryParse(tbBenefit.Text, out int benefit);
                var item = from p in db.Абоненты
                           where p.Льгота == benefit
                           select p;
                dgLinq = item.ToList();
            }
            catch
            {
                db.ChangeTracker.Entries().ToList().ForEach(x => x.Reload());
            }
        }
    }
}
