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
    /// Interaction logic for UpdateContract.xaml
    /// </summary>
    public partial class UpdateContract : Window
    {
        IBL BL;
        public UpdateContract()
        {
            InitializeComponent();
            BL = new BL_imp();

            foreach (Contract contract in BL.GetAllContracts())
            {
                ComboBoxItem item = new ComboBoxItem
                {
                    Content = contract.ContructNumber
                };

                this.contractNumberComboBox.Items.Add(item);
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Contract contract = new Contract();
            this.DataContext = contract;

            try
            {
                BL.UpdateContract(contract);
            }
            catch (Exception E)
            {
                MessageBox.Show(E.Message);
            }
        }
    }
}
