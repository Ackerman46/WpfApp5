using System;
using System.Windows;

namespace WpfApp1.Interface.PagesDelete
{
    /// <summary>
    /// Логика взаимодействия для Filter.xaml
    /// </summary>
    public partial class DeleteQuery : Window
    {
        public DeleteQuery()
        {
            InitializeComponent();
        }

        private void QueryTwo_Click(object sender, RoutedEventArgs e)
        {
            PagesChange.Source = new Uri("./QueryDeleteTwoPage.xaml", UriKind.RelativeOrAbsolute);
        }

        private void QueryOne_Click(object sender, RoutedEventArgs e)
        {
            PagesChange.Source = new Uri("./QueryDeleteOnePage.xaml", UriKind.RelativeOrAbsolute);
        }
    }
}