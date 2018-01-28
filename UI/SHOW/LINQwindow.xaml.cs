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
        public ObservableCollection<Nanny> GetAllNannies { get; set; }
        public ObservableCollection<Child> GetAllChildren { get; set; }
        public ObservableCollection<Mother> GetAllMothers { get; set; }
        public ObservableCollection<Contract> GetAllContracts { get; set; }

        public ObservableCollection<Nanny> GroupByChildrenAge { get; set; }
        public ObservableCollection<Contract> ShowAllSignedContracts { get; set; }

        public ObservableCollection<Nanny> ShowAllTAMATNannies { get; set; }
        public ObservableCollection<Contract> GroupAllContractsByDistance { get; set; }
        public ObservableCollection<Child> ShowAllChildrenWithoutNanny { get; set; }
        #endregion
        public LINQwindow()
        {
            InitializeComponent();
            GroupByChildrenAge = new ObservableCollection<Nanny>();
            ShowAllSignedContracts = new ObservableCollection<Contract>();
            GroupAllContractsByDistance = new ObservableCollection<Contract>();
            ShowAllTAMATNannies = new ObservableCollection<Nanny>();
            ShowAllChildrenWithoutNanny = new ObservableCollection<Child>();
            GetAllChildren = new ObservableCollection<Child>();
            GetAllMothers = new ObservableCollection<Mother>();
            GetAllNannies = new ObservableCollection<Nanny>();
            GetAllContracts = new ObservableCollection<Contract>();

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
                    GetAllNannies.Clear();
                    foreach (var item in bl.GetAllNannys())
                        GetAllNannies.Add(item);
                    CleanGrid();
                    ShowAllNanniesListView.Visibility = Visibility.Visible;
                    break;
                case "Show all children":
                    GetAllChildren.Clear();
                    foreach (var item in bl.GetAllChildren())
                        GetAllChildren.Add(item);
                    CleanGrid();
                    ShowAllChildrenListView.Visibility = Visibility.Visible;
                    break;
                case "Show all mothers":
                    GetAllMothers.Clear();
                    foreach (var item in bl.GetAllMothers())
                        GetAllMothers.Add(item);
                    CleanGrid();
                    ShowAllMothersListView.Visibility = Visibility.Visible;
                    break;
                case "Show all contracts":
                    GetAllContracts.Clear();
                    foreach (var item in bl.GetAllContracts())
                        GetAllContracts.Add(item);
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
                    GroupByChildrenAge.Clear();
                    foreach (var item in bl.GetNannysGroupedByChildrenAge(true))
                        foreach (var nanny in item)
                            GroupByChildrenAge.Add(nanny);
                    CleanGrid();
                    GroupByChildrenAgeListView.Visibility = Visibility.Visible;
                    break;
                case "Show all signed contracts":
                    ShowAllSignedContracts.Clear();
                    foreach (var item in bl.GetContractsByCondition(x => x.IsSigned == true))
                        ShowAllSignedContracts.Add(item);                    
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
                    ShowAllTAMATNannies.Clear();
                    foreach (var item in bl.GetTamatNannys())
                        ShowAllTAMATNannies.Add(item);
                    CleanGrid();
                    ShowAllTamatListView.Visibility = Visibility.Visible;
                    break;
                case "Show all children without nanny":
                    ShowAllChildrenWithoutNanny.Clear();
                    foreach (var item in bl.GetChildrenWithoutNanny())
                        ShowAllChildrenWithoutNanny.Add(item);
                    CleanGrid();
                    GetAllChildrenWithoutNannyListView.Visibility = Visibility.Visible;
                    break;
                case "Group all contracts by distance":
                    GroupAllContractsByDistance.Clear();
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
