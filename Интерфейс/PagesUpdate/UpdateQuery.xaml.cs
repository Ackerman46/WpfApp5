using System;
using System.Windows;

namespace WpfApp1.Интерфейс.PagesUpdate
{
    /// <summary>
    /// Логика взаимодействия для Filter.xaml
    /// </summary>
    public partial class UpdateQuery : Window
    {
        public UpdateQuery()
        {
            InitializeComponent();
        }

        private void QueryTwo_Click(object sender, RoutedEventArgs e)
        {
            PagesChange.Source = new Uri("./QueryUpdateTwoPage.xaml", UriKind.RelativeOrAbsolute);
        }

        private void QueryOne_Click(object sender, RoutedEventArgs e)
        {
            PagesChange.Source = new Uri("./QueryUpdateOnePage.xaml", UriKind.RelativeOrAbsolute);
        }
    }
}