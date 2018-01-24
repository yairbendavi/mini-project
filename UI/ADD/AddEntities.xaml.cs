using System;
using BE;
using BL;
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
    /// Interaction logic for AddEntities.xaml
    /// </summary>
    public partial class AddEntities : Window
    {
        public AddEntities()
        {
            InitializeComponent();
        }

        private void AddNannyButton_Click(object sender, RoutedEventArgs e)
        {
            new AddNanny().Show();
            this.Close();
        }
        private void AddMotherButton_Click(object sender, RoutedEventArgs e)
        {
            new AddMother().Show();
            this.Close();
        }
        private void AddChildButton_Click(object sender, RoutedEventArgs e)
        {
            new AddChild().Show();
            this.Close();
        }
        private void AddContractButton_Click(object sender, RoutedEventArgs e)
        {
            new AddContract().Show();
            this.Close();
        }
    }
}
