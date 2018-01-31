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
using System.Threading;
using System.ComponentModel;

namespace UI
{
    /// <summary>
    /// Interaction logic for AddContract.xaml
    /// </summary>
    public partial class AddContract : Window
    {
        IBL BL;
        Contract contract;
        BackgroundWorker BackgroundWorker;
        int NannyId;
        int MotherId;
        int ChildId;

        public AddContract()
        {
            InitializeComponent();

            BL = new BL_imp();
            contract = new Contract();
            BackgroundWorker = new BackgroundWorker();
            this.DataContext = contract;
            BackgroundWorker.DoWork += BackgroundWorker_DoWork;
            BackgroundWorker.RunWorkerCompleted += BackgroundWorker_RunWorkerCompleted;            
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            NannyId = int.Parse(nannyIdTextBox.Text);
            MotherId = int.Parse(motherIdTextBox.Text);
            ChildId = int.Parse(childIdTextBox.Text);

            contract.Nanny = BL.GetAllNannys().ToList().Find(x => x.Id == NannyId);
            contract.Child = BL.GetAllChildren().ToList().Find(x => x.Id == ChildId);
            contract.Mother = BL.GetAllMothers().ToList().Find(x => x.Id == MotherId);

            BackgroundWorker.RunWorkerAsync();
            this.Close();
        }
        private void BackgroundWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            try
            {
                BL.AddContract(contract);
                e.Result = false;
            }
            catch (Exception exc)
            {
                e.Result = exc;
            }
        }
        private void BackgroundWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (!(e.Result is bool))
                MessageBox.Show(((Exception)e.Result).Message);
        }


    }
}


