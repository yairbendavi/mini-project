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
    /// Interaction logic for UpdateChild.xaml
    /// </summary>
    public partial class UpdateChild : Window
    {
        IBL BL;
        public UpdateChild()
        {
            InitializeComponent();
            BL = new BL_imp();

            if (BL.GetAllChildren().Count > 0)
            {
                foreach (Child child in BL.GetAllChildren())
                {
                    ComboBoxItem item = new ComboBoxItem
                    {
                        Content = child.FirstName
                    };

                    this.firstNameCoboBox.Items.Add(item);
                }
            }
            else
            {
                MessageBox.Show("The system has no children, update is imposible.");
                this.Close();
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Child child = new Child();
            this.DataContext = child;

            try
            {
                BL.UpdateChild(child);
            }
            catch(Exception E)
            {
                MessageBox.Show(E.Message);
            }
        }
    }
}
