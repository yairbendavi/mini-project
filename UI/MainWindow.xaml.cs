using BE;
using BL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
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
using System.Windows.Threading;

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

            IBL a = new BL_imp();
            BL_imp b = new BL_imp();
            b.Initialization();
        }

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            new AddEntities().ShowDialog();
        }
        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            new DeleteEntity().ShowDialog();
        }
        private void UpdateButton_Click(object sender, RoutedEventArgs e)
        {
            new UpdateEntities().ShowDialog();
        }
        private void LinqButton_Click(object sender, RoutedEventArgs e)
        {
            new LINQwindow().ShowDialog();            
        }
        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            Environment.Exit(Environment.ExitCode);
        }
    }
}
