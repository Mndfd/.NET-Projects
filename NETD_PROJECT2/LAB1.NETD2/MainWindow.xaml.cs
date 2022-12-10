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

namespace Lab1Netd
{
    //Last Modified: 2021-10-28
    //Written By: Onur Ozkanca
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            UpdateStatus("Application running");
        }
        



        // Calculate button is here, we don't do any calculation here, calculations are done in the class section this button is here for the populating form.
        private void btnCalculateClick(object sender, RoutedEventArgs e)
        {
            try
            {
                // Every Time button calcualate is clicked it will make the error labels empty and if the error is still there, it will show it again.
                labelNameError.Content = String.Empty;
                labelMessagesError.Content = String.Empty;
                
                PieceworkWorker myWorker = new PieceworkWorker(txtWorkerName.Text,txtWorkerLastName.Text, txtMessagesSent.Text);
            
                // Employee pay textbox population
                txtEmployeesPay.Text = myWorker.Pay.ToString("c");
                UpdateStatus("Worker: " + myWorker.Name.ToString() + " entered with " + myWorker.Messages.ToString() + " messages, paid " + myWorker.Pay.ToString("c"));


                // Disable input controls (so that the user has to use "Clear" to continue)
                    txtWorkerName.IsEnabled = false;
                    txtWorkerLastName.IsEnabled = false;
                    txtMessagesSent.IsEnabled = false;
                    btnCalculate.IsEnabled = false;
                    
                btnClear.Focus();
              

            }
            catch (ArgumentException error)
            {
                //We are going to check the error param and see which error we got by comparing it to our class parameter.
                if (error.ParamName == PieceworkWorker.nameParameter)
                {
                    labelNameError.Content = error.Message;
                    txtWorkerName.BorderBrush = Brushes.Red;
                    txtWorkerName.SelectAll();
                    txtWorkerName.Focus();
                }
                else if (error.ParamName == PieceworkWorker.lastnameParameter) 
                {
                    labelNameError.Content = error.Message;
                    txtWorkerLastName.BorderBrush = Brushes.Red;
                    txtWorkerLastName.SelectAll();
                    txtWorkerLastName.Focus();
                }
                else if (error.ParamName == PieceworkWorker.messagesParameter)
                {
                    labelMessagesError.Content = error.Message;
                    txtMessagesSent.BorderBrush = Brushes.Red;
                    txtMessagesSent.SelectAll();
                    txtMessagesSent.Focus();

                }

            }
            catch (Exception error)
            {
                //Reporting if it catches something different
                MessageBox.Show("An unexpected error has occured! Please contact your IT department and provide the following information.\n" +
                    "\nType:"+ error.GetType() + 
                    "\nSource:" + error.Source +
                    "\nMessage" + error.Message +
                    "\nStack Trace: " + error.StackTrace);
            }
            
        }

        // Clear click for removing the inputs, error labels, and enabling the buttons. It resets the brushes as well.
        private void ClearClick(object sender, RoutedEventArgs e)
        {
            btnCalculate.Focus();
            txtEmployeesPay.Clear();
            txtMessagesSent.Clear();
            txtWorkerName.Clear();
            txtWorkerLastName.Clear();
            txtWorkerName.BorderBrush = Brushes.Black;
            txtMessagesSent.BorderBrush = Brushes.Black;
            txtWorkerLastName.BorderBrush = Brushes.Black;
            labelNameError.Content = String.Empty;
            labelMessagesError.Content = String.Empty;
            
            txtWorkerName.IsEnabled = true;
            txtMessagesSent.IsEnabled = true;
            btnCalculate.IsEnabled = true;
            txtWorkerLastName.IsEnabled = true;
        }
     
   

        private void ExitClick(object sender, RoutedEventArgs e)
        { 
            if (MessageBox.Show("Are you sure you want to exit?", "Confirm Close", MessageBoxButton.YesNo) == MessageBoxResult.Yes) 
            {
                Close();
            }
            else
            {
                UpdateStatus("User misclicked the exit button.");
            }

          
           
        }

        // Perform a set of actions such a populating fields when different tabs are selected in
        // the tab control.
        private void TabChanged(object sender, SelectionChangedEventArgs e)
        {   
            // When you are looking at the payroll entry tab focus will be on clear button
            if (tabControlInterface.SelectedItem == tabPayrollEntry)
            {
                btnClear.Focus();
                UpdateStatus("Accessed the payroll entry interface.");
            } // When you are looking at the payroll entry tab, it will populate the summary tab
            else if (tabControlInterface.SelectedItem == tabSummary)
            {
                txtTotalWorkers.Text = PieceworkWorker.TotalWorkers.ToString();
                txtTotalPay.Text = PieceworkWorker.TotalPay.ToString("c");
                txtAveragePay.Text = PieceworkWorker.AveragePay.ToString("c");
                txtTotalMessages.Text = PieceworkWorker.TotalMessages.ToString();
                UpdateStatus("Accessed the summary window");

            } // It will retrieve the table from our database when the user clicks the employee list tab.
            else if (tabControlInterface.SelectedItem == tabEmployeeList) 
            {
                dataGridEmployees.ItemsSource = PieceworkWorker.AllWorkers.DefaultView;
                UpdateStatus("Accessed the employee list.");
            }
            
        }
       // Current program status and updates it.
        private void UpdateStatus(string status) 
        {
            labelStatus.Content = "Current Status: " + status + " (" + DateTime.Now + ")";
            labelTime.Content = DateTime.Now;
        }

    }
    
}
