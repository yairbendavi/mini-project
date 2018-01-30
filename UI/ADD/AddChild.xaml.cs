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
using System.Globalization;

namespace UI
{
    /// <summary>
    /// Interaction logic for AddChild.xaml
    /// </summary>
    public partial class AddChild : Window
    {
        IBL BL;
        Child child;
        public AddChild()
        {
            InitializeComponent();

            BL = new BL_imp();
            child = new Child();
            this.DataContext = child;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                BL.AddChild(child);
                child = new Child();
                this.DataContext = child;
                this.Close();
            }
            catch (Exception E)
            {
                MessageBox.Show(E.Message);
            }
        }
    }
}
