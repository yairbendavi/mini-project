﻿using System;
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
    /// Interaction logic for UpdateNanny.xaml
    /// </summary>
    public partial class UpdateNanny : Window
    {
        IBL BL;
        public UpdateNanny()
        {
            InitializeComponent();
            BL = new BL_imp();

            foreach (Nanny nanny in BL.GetAllNannys())
            {
                ComboBoxItem item = new ComboBoxItem
                {
                    Content = nanny.FirstName
                };

                this.firstNameComboBox.Items.Add(item);
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Nanny nanny = new Nanny();
            this.DataContext = nanny;

            try
            {
                BL.UpdateNanny(nanny);
            }
            catch (Exception E)
            {
                MessageBox.Show(E.Message);
            }
        }
    }
}
