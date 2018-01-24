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
    /// Interaction logic for UpdateMother.xaml
    /// </summary>
    public partial class UpdateMother : Window
    {
        IBL BL;
        public UpdateMother()
        {
            InitializeComponent();
            BL = new BL_imp();

            foreach (Mother mother in BL.GetAllMothers())
            {
                ComboBoxItem item = new ComboBoxItem
                {
                    Content = mother.Id
                };

                this.firstNameComboBox.Items.Add(item);
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Mother mother = new Mother();
            this.DataContext = mother;

            try
            {
                BL.UpdateMother(mother);
            }
            catch (Exception E)
            {
                MessageBox.Show(E.Message);
            }
        }
    }
}