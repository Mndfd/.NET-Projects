using System;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace LAB1.NETD2
{
    // Last Modified: 2021-09-24
    //Written By: Onur Ozkanca
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        // Calculate button is here, we don't do any calculation here, calculations are done in the class section this button is here for the populating form.
        private void btnCalculateClick(object sender, RoutedEventArgs e)
        {
            PieceworkWorker myWorker = new PieceworkWorker(txtWorkerName.Text, txtMessagesSent.Text);
            // If pay is equals to zero, 0 will be divided and it will break the probram so this is making sure when you enter a wrong data it doesn't let 0 divided by anything.
            if (myWorker.Pay != 0)
            {
                txtTotalWorkers.Text = PieceworkWorker.TotalWorkers.ToString();
                txtTotalPay.Text = PieceworkWorker.TotalPay.ToString("c");
                txtAveragePay.Text = (PieceworkWorker.TotalPay / PieceworkWorker.TotalWorkers).ToString("c");
                txtEmployeesPay.Text = myWorker.Pay.ToString("c");


                // Disable input controls (so that the user has to use "Clear" to continue)
                txtWorkerName.IsEnabled = false;
                txtMessagesSent.IsEnabled = false;
                btnCalculate.IsEnabled = false;
                btnClear.Focus();
            }
            else {
                txtWorkerName.Focus();
            }
        }
        // Clear click for removing the inputs and enabling the buttons
        private void ClearClick(object sender, RoutedEventArgs e)
        {
            txtEmployeesPay.Clear();
            txtMessagesSent.Clear();
            txtWorkerName.Clear();

            txtWorkerName.IsEnabled = true;
            txtMessagesSent.IsEnabled = true;
            btnCalculate.IsEnabled = true;
        }
    }
}
