using System;
using System.Windows;

namespace WpfApp1.Интерфейс.PagesLINQ
{
    /// <summary>
    /// Логика взаимодействия для Filter.xaml
    /// </summary>
    public partial class LINQQuery : Window
    {
        public LINQQuery()
        {
            InitializeComponent();
        }

        private void QueryTwo_Click(object sender, RoutedEventArgs e)
        {
            PagesChange.Source = new Uri("./QueryLINQTwoPage.xaml", UriKind.RelativeOrAbsolute);
        }

        private void QueryOne_Click(object sender, RoutedEventArgs e)
        {
            PagesChange.Source = new Uri("./QueryLINQOnePage.xaml", UriKind.RelativeOrAbsolute);
        }

        private void QueryThree_Click(object sender, RoutedEventArgs e)
        {
            PagesChange.Source = new Uri("./QueryLINQThreePage.xaml", UriKind.RelativeOrAbsolute);
        }

        private void QueryFour_Click(object sender, RoutedEventArgs e)
        {
            PagesChange.Source = new Uri("./QueryLINQFourPage.xaml", UriKind.RelativeOrAbsolute);
        }

        private void QueryFive_Click(object sender, RoutedEventArgs e)
        {
            PagesChange.Source = new Uri("./QueryLINQFivePage.xaml", UriKind.RelativeOrAbsolute);
        }
    }
}