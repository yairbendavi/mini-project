using BE;
using BL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace UI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        public MainWindow()
        {
            InitializeComponent();
        }

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            new AddEntities().Show();
        }
        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            new DeleteEntity().Show();
        }
        private void UpdateButton_Click(object sender, RoutedEventArgs e)
        {
            new UpdateEntities().Show();
        }
        private void LinqButton_Click(object sender, RoutedEventArgs e)
        {
            new LINQwindow().Show();
        }
    }
}
