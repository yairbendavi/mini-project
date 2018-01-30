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
        IBL BL;
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
                mother.RequiredDays[0] = CB1.IsChecked.Value;
                mother.RequiredDays[1] = CB2.IsChecked.Value;
                mother.RequiredDays[2] = CB3.IsChecked.Value;
                mother.RequiredDays[3] = CB4.IsChecked.Value;
                mother.RequiredDays[4] = CB5.IsChecked.Value;
                mother.RequiredDays[5] = CB6.IsChecked.Value;
                mother.RequiredDays[6] = CB7.IsChecked.Value;

                if (CB1.IsChecked.Value)
                    mother.RequiredHours[0].BeginingTime = (DateTime)sundayBegT.Value;
                if (CB2.IsChecked.Value)
                    mother.RequiredHours[1].BeginingTime = (DateTime)mondayBegT.Value;
                if (CB3.IsChecked.Value)
                    mother.RequiredHours[2].BeginingTime = (DateTime)tuesdayBegT.Value;
                if (CB4.IsChecked.Value)
                    mother.RequiredHours[3].BeginingTime = (DateTime)wednesdayBegT.Value;
                if (CB5.IsChecked.Value)
                    mother.RequiredHours[4].BeginingTime = (DateTime)thursdayBegT.Value;
                if (CB6.IsChecked.Value)
                    mother.RequiredHours[5].BeginingTime = (DateTime)fridayBegT.Value;
                if (CB7.IsChecked.Value)
                    mother.RequiredHours[6].BeginingTime = (DateTime)saturdayBegT.Value;

                if (CB1.IsChecked.Value)
                    mother.RequiredHours[0].EndTime = (DateTime)sundayEndT.Value;
                if (CB2.IsChecked.Value)
                    mother.RequiredHours[1].EndTime = (DateTime)mondayEndT.Value;
                if (CB3.IsChecked.Value)
                    mother.RequiredHours[2].EndTime = (DateTime)tuesdayEndT.Value;
                if (CB4.IsChecked.Value)
                    mother.RequiredHours[3].EndTime = (DateTime)wednesdayEndT.Value;
                if (CB5.IsChecked.Value)
                    mother.RequiredHours[4].EndTime = (DateTime)thursdayEndT.Value;
                if (CB6.IsChecked.Value)
                    mother.RequiredHours[5].EndTime = (DateTime)fridayEndT.Value;
                if (CB7.IsChecked.Value)
                    mother.RequiredHours[6].EndTime = (DateTime)saturdayEndT.Value;
                
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
