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
    /// Interaction logic for DeleteEntity.xaml
    /// </summary>
    public partial class DeleteEntity : Window
    { 
        IBL BL;
        public DeleteEntity()
        {
            InitializeComponent();

            BL = new BL_imp();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (this.EntityPicker.Text == "System.Windows.Controls.ComboBoxItem: Nanny")
            {
                try
                {
                    BL.DeleteNanny(uint.Parse(this.idTextBox.Text));
                }
                catch (Exception E)
                {
                    MessageBox.Show(E.Message);
                }
            }
            else if (this.EntityPicker.Text == "System.Windows.Controls.ComboBoxItem: Mother")
            {
                try
                {
                    BL.DeleteMother(uint.Parse(this.idTextBox.Text));
                }
                catch (Exception E)
                {
                    MessageBox.Show(E.Message);
                }
            }
            else if (this.EntityPicker.Text == "System.Windows.Controls.ComboBoxItem: Child")
            {
                try
                {
                    BL.DeleteChild(uint.Parse(this.idTextBox.Text));
                }
                catch (Exception E)
                {
                    MessageBox.Show(E.Message);
                }
            }
            else if (this.EntityPicker.Text == "System.Windows.Controls.ComboBoxItem: Contract")
            {
                try
                {
                    BL.DeleteContract(uint.Parse(this.idTextBox.Text));
                }
                catch (Exception E)
                {
                    MessageBox.Show(E.Message);
                }
            }
            else
            {
                MessageBox.Show("No such entity exists.");
            }
        }
    }
}
