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
    /// Interaction logic for AddNanny.xaml
    /// </summary>
    public partial class AddNanny : Window
    {
        BL_imp BL;
        Nanny nanny;

        public AddNanny()
        {
            InitializeComponent();

            nanny = new Nanny();
            this.DataContext = nanny;
            BL = new BL_imp();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                nanny.WorkingHours[0].BeginingTime += sundayBegT.TimeInterval;
                nanny.WorkingHours[1].BeginingTime = (DateTime)mondayBegT.Value;
                nanny.WorkingHours[2].BeginingTime = (DateTime)tuesdayBegT.Value;
                nanny.WorkingHours[3].BeginingTime = (DateTime)wednesdayBegT.Value;
                nanny.WorkingHours[4].BeginingTime = (DateTime)thursdayBegT.Value;
                nanny.WorkingHours[5].BeginingTime = (DateTime)fridayBegT.Value;
                nanny.WorkingHours[6].BeginingTime = (DateTime)saturdayBegT.Value;

                nanny.WorkingHours[0].EndTime = (DateTime)sundayEndT.Value;
                nanny.WorkingHours[1].EndTime = (DateTime)mondayEndT.Value;
                nanny.WorkingHours[2].EndTime = (DateTime)tuesdayEndT.Value;
                nanny.WorkingHours[3].EndTime = (DateTime)wednesdayEndT.Value;
                nanny.WorkingHours[4].EndTime = (DateTime)thursdayEndT.Value;
                nanny.WorkingHours[5].EndTime = (DateTime)fridayEndT.Value;
                nanny.WorkingHours[6].EndTime = (DateTime)saturdayEndT.Value;

                BL.AddNanny(nanny);
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
