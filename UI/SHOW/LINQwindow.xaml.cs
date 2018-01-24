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
using System.Globalization;
using System.Collections.ObjectModel;

namespace UI
{
    /// <summary>
    /// Interaction logic for LINQwindow.xaml
    /// </summary>

    public partial class LINQwindow : Window
    {
        IBL bl = new BL_imp();
        #region Lists
        public List<Nanny> GetAllNannies { get; set; }
        public List<Child> GetAllChildren { get; set; }
        public List<Mother> GetAllMothers { get; set; }
        public List<Contract> GetAllContracts { get; set; }

        public List<Nanny> GroupByChildrenAge { get; set; }
        public List<Contract> ShowAllSignedContracts { get; set; }

        public List<Nanny> ShowAllTAMATNannies { get; set; }
        public List<Contract> GroupAllContractsByDistance { get; set; }
        public List<Child> ShowAllChildrenWithoutNanny { get; set; }
        #endregion
        public LINQwindow()
        {
            InitializeComponent();
            GroupByChildrenAge = new List<Nanny>();
            GroupAllContractsByDistance = new List<Contract>();

            GetAllChildrenWithoutNannyListView.DataContext = this;
            GroupAllContractsByDistanceListView.DataContext = this;
            GroupByChildrenAgeListView.DataContext = this;
            ShowAllChildrenListView.DataContext = this;
            ShowAllContractsListView.DataContext = this;
            ShowAllMothersListView.DataContext = this;
            ShowAllNanniesListView.DataContext = this;
            ShowAllTamatListView.DataContext = this;
            SignedContractsListView.DataContext = this;
        }

        private void Button1_Click(object sender, RoutedEventArgs e)
        {
            switch (Button1.Content.ToString())
            {
                case "Show all nannies":
                    GetAllNannies = bl.GetAllNannys();
                    CleanGrid();
                    ShowAllNanniesListView.Visibility = Visibility.Visible;
                    break;
                case "Show all children":
                    //GetAllChildren = bl.GetAllChildren();
                    CleanGrid();
                    ShowAllChildrenListView.Visibility = Visibility.Visible;
                    break;
                case "Show all mothers":
                    GetAllMothers = bl.GetAllMothers();
                    CleanGrid();
                    ShowAllMothersListView.Visibility = Visibility.Visible;
                    break;
                case "Show all contracts":
                    GetAllContracts = bl.GetAllContracts();
                    CleanGrid();
                    ShowAllContractsListView.Visibility = Visibility.Visible;
                    break;
            }
        }
        private void Button2_Click(object sender, RoutedEventArgs e)
        {         
            switch (Button2.Content.ToString())
            {
                case "Group by children age":
                    foreach (var item in bl.GetNannysGroupedByChildrenAge(true))
                        foreach (var nanny in item)
                            GroupByChildrenAge.Add(nanny);
                    CleanGrid();
                    GroupByChildrenAgeListView.Visibility = Visibility.Visible;
                    break;
                case "Show all signed contracts":
                    ShowAllSignedContracts = bl.GetContractsByCondition(x => x.IsSigned == true).ToList<Contract>();
                    CleanGrid();
                    SignedContractsListView.Visibility = Visibility.Visible;
                    break;
            }
        }
        private void Button3_Click(object sender, RoutedEventArgs e)
        {
            switch (Button3.Content.ToString())
            {
                case "Show all TAMAT nannies":
                    ShowAllTAMATNannies = bl.GetTamatNannys().ToList<Nanny>();
                    CleanGrid();
                    ShowAllTamatListView.Visibility = Visibility.Visible;
                    break;
                case "Show all children without nanny":
                    ShowAllChildrenWithoutNanny = bl.GetChildrenWithoutNanny().ToList<Child>();
                    CleanGrid();
                    GetAllChildrenWithoutNannyListView.Visibility = Visibility.Visible;
                    break;
                case "Group all contracts by distance":
                    foreach (var item in bl.GetContractsGroupedByDistance())
                        foreach (var ctr in item)
                            GroupAllContractsByDistance.Add(ctr);
                    CleanGrid();
                    GroupAllContractsByDistanceListView.Visibility = Visibility.Visible;
                    break;
            }
        }
        private void CleanGrid()
        {
            GetAllChildrenWithoutNannyListView.Visibility = Visibility.Collapsed;
            GroupAllContractsByDistanceListView.Visibility = Visibility.Collapsed;
            GroupByChildrenAgeListView.Visibility = Visibility.Collapsed;
            ShowAllChildrenListView.Visibility = Visibility.Collapsed;
            ShowAllContractsListView.Visibility = Visibility.Collapsed;
            ShowAllMothersListView.Visibility = Visibility.Collapsed;
            ShowAllNanniesListView.Visibility = Visibility.Collapsed;
            ShowAllTamatListView.Visibility = Visibility.Collapsed;
            SignedContractsListView.Visibility = Visibility.Collapsed;
        }
    }

    #region IValueConverters
    public class Button1ComboBoxConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            switch (value.ToString())
            {
                case "System.Windows.Controls.ComboBoxItem: Nanny": return "Show all nannies";
                case "System.Windows.Controls.ComboBoxItem: Mother": return "Show all mothers";
                case "System.Windows.Controls.ComboBoxItem: Child": return "Show all children";
                case "System.Windows.Controls.ComboBoxItem: Contract": return "Show all contracts";
                default: return "ERROR";
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }

    }

    public class Button2ComboBoxConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            switch (value.ToString())
            {
                case "System.Windows.Controls.ComboBoxItem: Nanny": return "Group by children age";
                case "System.Windows.Controls.ComboBoxItem: Mother": return Visibility.Collapsed;
                case "System.Windows.Controls.ComboBoxItem: Child": return Visibility.Collapsed;
                case "System.Windows.Controls.ComboBoxItem: Contract": return "Show all signed contracts";
                default: return "ERROR";
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }

    public class Button3ComboBoxConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            switch (value.ToString())
            {
                case "System.Windows.Controls.ComboBoxItem: Nanny": return "Show all TAMAT nannies";
                case "System.Windows.Controls.ComboBoxItem: Mother": return Visibility.Collapsed;
                case "System.Windows.Controls.ComboBoxItem: Child": return "Show all children without nanny";
                case "System.Windows.Controls.ComboBoxItem: Contract": return "Group all contracts by distance";
                default: return "ERROR";
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
    #endregion
}
