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
    /// Interaction logic for AddMother.xaml
    /// </summary>
    public partial class AddMother : Window
    {
        BL_imp BL;
        Mother mother;
        public AddMother()
        {
            InitializeComponent();

            BL = new BL_imp();
            mother = new Mother();
            this.DataContext = mother;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                BL.AddMother(mother);
                mother = new Mother();
                this.DataContext = mother;
                this.Close();
            }
            catch (Exception E)
            {
                MessageBox.Show(E.Message);
            }
        }
    }
}
