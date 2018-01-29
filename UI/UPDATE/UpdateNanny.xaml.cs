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
    /// Interaction logic for UpdateNanny.xaml
    /// </summary>
    public partial class UpdateNanny : Window
    {
        IBL BL;
        Nanny nanny;
        public UpdateNanny()
        {
            InitializeComponent();

            nanny = new Nanny();
            this.DataContext = nanny;

            BL = BL.FactoryBL();

            foreach (Nanny nany in BL.GetAllNannys())
            {
                ComboBoxItem item = new ComboBoxItem
                {
                    Content = nany.FirstName
                };

                this.firstNameComboBox.Items.Add(item);
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                nanny.DaysOfWork[0] = CB1.IsChecked.Value;
                nanny.DaysOfWork[1] = CB2.IsChecked.Value;
                nanny.DaysOfWork[2] = CB3.IsChecked.Value;
                nanny.DaysOfWork[3] = CB4.IsChecked.Value;
                nanny.DaysOfWork[4] = CB5.IsChecked.Value;
                nanny.DaysOfWork[5] = CB6.IsChecked.Value;
                nanny.DaysOfWork[6] = CB7.IsChecked.Value;

                if (CB1.IsChecked.Value)
                    nanny.WorkingHours[0].BeginingTime = (DateTime)sundayBegT.Value;
                if (CB2.IsChecked.Value)
                    nanny.WorkingHours[1].BeginingTime = (DateTime)mondayBegT.Value;
                if (CB3.IsChecked.Value)
                    nanny.WorkingHours[2].BeginingTime = (DateTime)tuesdayBegT.Value;
                if (CB4.IsChecked.Value)
                    nanny.WorkingHours[3].BeginingTime = (DateTime)wednesdayBegT.Value;
                if (CB5.IsChecked.Value)
                    nanny.WorkingHours[4].BeginingTime = (DateTime)thursdayBegT.Value;
                if (CB6.IsChecked.Value)
                    nanny.WorkingHours[5].BeginingTime = (DateTime)fridayBegT.Value;
                if (CB7.IsChecked.Value)
                    nanny.WorkingHours[6].BeginingTime = (DateTime)saturdayBegT.Value;

                if (CB1.IsChecked.Value)
                    nanny.WorkingHours[0].EndTime = (DateTime)sundayEndT.Value;
                if (CB2.IsChecked.Value)
                    nanny.WorkingHours[1].EndTime = (DateTime)mondayEndT.Value;
                if (CB3.IsChecked.Value)
                    nanny.WorkingHours[2].EndTime = (DateTime)tuesdayEndT.Value;
                if (CB4.IsChecked.Value)
                    nanny.WorkingHours[3].EndTime = (DateTime)wednesdayEndT.Value;
                if (CB5.IsChecked.Value)
                    nanny.WorkingHours[4].EndTime = (DateTime)thursdayEndT.Value;
                if (CB6.IsChecked.Value)
                    nanny.WorkingHours[5].EndTime = (DateTime)fridayEndT.Value;
                if (CB7.IsChecked.Value)
                    nanny.WorkingHours[6].EndTime = (DateTime)saturdayEndT.Value;

                BL.UpdateNanny(nanny);
                nanny = new Nanny();
                this.DataContext = nanny;
                this.Close();
            }
            catch (Exception E)
            {
                MessageBox.Show(E.Message);
            }
        }
    }
}
