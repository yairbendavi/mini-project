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
    /// Interaction logic for AddContract.xaml
    /// </summary>
    public partial class AddContract : Window
    {
        IBL BL;
        Contract contract;
        public AddContract()
        {
            InitializeComponent();

            BL = new BL_imp();
            contract = new Contract();
            this.DataContext = contract;

            foreach (var nanny in BL.GetAllNannys())
            {
                ComboBoxItem item = new ComboBoxItem
                {
                    Content = nanny.Id
                };

                this.NannyIdComboBox.Items.Add(item);
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                BL.AddContract(contract);
                contract = new Contract();
                this.DataContext = contract;
                this.Close();
            }
            catch (Exception E)
            {
                MessageBox.Show(E.Message);
            }

        }
    }
}
