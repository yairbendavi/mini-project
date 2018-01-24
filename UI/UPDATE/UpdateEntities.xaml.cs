using System;
using BL;
using BE;
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
using System.Windows.Shapes;

namespace UI
{
    /// <summary>
    /// Interaction logic for UpdateEntities.xaml
    /// </summary>
    public partial class UpdateEntities : Window
    {
        public UpdateEntities()
        {
            InitializeComponent();
        }

        private void UpdateNannyButton_Click(object sender, RoutedEventArgs e)
        {
            new UpdateNanny().Show();
            this.Close();
        }
        private void UpdateMotherButton_Click(object sender, RoutedEventArgs e)
        {
            new UpdateMother().Show();
            this.Close();
        }
        private void UpdateChildButton_Click(object sender, RoutedEventArgs e)
        {
            new UpdateChild().Show();
            this.Close();
        }
        private void UpdateContracButton_Click(object sender, RoutedEventArgs e)
        {
            new UpdateContract().Show();
            this.Close();
        }
    }
}
