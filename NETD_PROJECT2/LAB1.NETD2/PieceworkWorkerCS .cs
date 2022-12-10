// PieceworkWorker.cs
// Title: IncInc Payroll (Piecework)
// Last Modified: 2021-10-29
// Written By: Onur Ozkanca
// Adapted from PieceworkWorker by Kyle Chapman, September 2019
// 
// This is a class representing individual worker objects. Each stores
// their own name and number of messages and the class methods allow for
// calculation of the worker's pay and for updating of shared summary
// values. Name and messages are received as strings.
// This is being used as part of a piecework payroll application.



using System;
using System.Collections.Generic; 
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Data;
namespace Lab1Netd // Ensure this namespace matches your own
{
    class PieceworkWorker
    {

        #region "Variable declarations"

        // Instance variables
        private string employeeName;
        private string employeelastName;
        private int employeeMessages;
        private decimal employeePay;
        private bool isValid = true;
        private DateTime employeeDate;

        // Consts for exception parameters
        public const string nameParameter = "Name";
        public const string lastnameParameter = "Last name";
        public const string messagesParameter = "Message";

        // Consts for the messages value check and rates according to messages count.
        private const int lowest = 1249;
        private const int lowerBetween = 1250;
        private const int lower = 2499;
        private const int lowBetween = 2500;
        private const int low = 3749;
        private const int highBetween = 3500;
        private const int high = 4999;
        private const int higher = 5000;
        private const int upperBound = 15000;
        private const decimal lowestRate = 0.02M;
        private const decimal lowerRate = 0.024M;
        private const decimal lowRate = 0.028M;
        private const decimal highRate = 0.034M;
        private const decimal higherRate = 0.04M;



        #endregion

        #region "Constructors"

        /// <summary>
        /// PieceworkWorker constructor: accepts a worker's name and number of
        /// messages, sets and calculates values as appropriate.
        /// </summary>
        /// <param name="nameValue">the worker's name</param>
        /// /// <param last="lastName">the worker's lane name</param>
        /// <param name="messageValue">a worker's number of messages sent</param>
        public PieceworkWorker(string firstName,string lastName, string messagesValue)
        {
            // Validate and set the worker's name 
            this.Name = firstName;
            // Validate and set the worker's last name.
            this.lastName = lastName;
            // Validate Validate and set the worker's number of messages
            this.Messages = messagesValue;
            // Calculcate the worker's pay and update all summary values
            findPay();
            // Setting the employee date.
            employeeDate = DateTime.Now;

            // Add this worker to the database.
            DataAccess.InsertNewRecord(this);

        }

        /// <summary>
        /// PieceworkWorker constructor: empty constructor used strictly for inheritance and instantiation
        /// </summary>
        public PieceworkWorker()
        {

        }

        #endregion

        #region "Class methods"

        /// <summary>
        /// Currently called in the constructor, the findPay() method is
        /// used to calculate a worker's pay using threshold values to
        /// change how much a worker is paid per message.
        /// 
        /// </summary>
        private void findPay()
        {

            if (isValid)
            {
                if (employeeMessages <= lowest)
                {

                    employeePay = employeeMessages * lowestRate;
                }
                else if (employeeMessages >= lowerBetween && employeeMessages <= lower)
                {
                    employeePay = employeeMessages * lowerRate;

                }
                else if (employeeMessages >= lowBetween && employeeMessages <= low)
                {
                    employeePay = employeeMessages * lowRate;

                }
                else if (employeeMessages >= highBetween && employeeMessages <= high)
                {
                    employeePay = employeeMessages * highRate;
                }
                else if (employeeMessages >= higher)
                {
                    employeePay = employeeMessages * higherRate;
                }
                
               
               
            }
        }
        #endregion

        #region "Property Procedures"

        /// <summary>
        /// Gets and sets a worker's name
        /// </summary>
        /// <returns>an employee's name</returns>
        public string Name
        {
            get
            {
                return employeeName;
            }
            set
            {

                if (string.IsNullOrEmpty(value) == true)
                {


                    isValid = false;
                    throw new ArgumentNullException(nameParameter, "You must enter a name");

                }




                employeeName = value;
            }
        }

        /// <summary>
        /// Gets and sets a worker's last name
        /// </summary>
        /// <returns>an employee's last name</returns>
        public string lastName
        {
            get
            {
                return employeelastName;
            }
            set
            {

                if (string.IsNullOrEmpty(value) == true)
                {


                    isValid = false;
                    throw new ArgumentNullException(lastnameParameter, "You must enter a last name");

                }




                employeelastName = value;
            }
        }

        /// <summary>
        /// Gets and sets the number of messages sent by a worker
        /// </summary>
        /// <returns>an employee's number of messages</returns>
        public string Messages
        {
            get
            {
                return employeeMessages.ToString();
            }
            set
            {

                if (int.TryParse(value.Trim(), out employeeMessages))
                {
                    if (employeeMessages <= 0)
                    {

                        isValid = false;
                        throw new ArgumentOutOfRangeException(messagesParameter, "The messages sent must be higher than 0.");
                    }
                    else if (employeeMessages >= upperBound)
                    {
                        isValid = false;
                        throw new ArgumentOutOfRangeException(messagesParameter, "The messages sent upper bound is 15000.");
                    }
                }
                // employeeMessages = Convert.ToInteger(value); // This line is dangerous and should probably never appear in your code. Can you explain why? Post about it on the Q&A board and I'll give you a stock.
                else
                {


                    isValid = false;
                    throw new ArgumentNullException(messagesParameter, "Please enter messages value.");

                }

            }
        }

        /// <summary>
        /// Gets the worker's pay
        /// </summary>
        /// <returns>a worker's pay</returns>
        public decimal Pay
        {
            get
            {
                return Convert.ToDecimal(employeePay);
            }
        }

        /// <summary>
        /// Gets the overall total pay among all workers
        /// </summary>
        /// <returns>the overall total pay among all workers</returns>
        public static decimal TotalPay
        {
            get
            {   // Trying to see if the value is 0 if yes, I will manually say it is 0 otherwise it will throw an exception.
                if (Convert.ToInt32(DataAccess.GetTotalEmployees()) != 0)
                {
                    return Convert.ToDecimal(DataAccess.GetTotalPay());
                }
                else 
                {
                    return 0M;
                }
            }
        }


        /// <summary>
        /// Get the worker's entry date.
        /// </summary>
        /// <returns>Entry Date</returns>
        public  DateTime EntryDate
        {
            get
            {
                return employeeDate;
            }
        }


        /// <summary>
        /// Gets the overall number of workers
        /// </summary>
        /// <returns>the overall number of workers</returns>
        public static int TotalWorkers
        {
            get
            {   // Trying to see if the value is 0 if yes, I will manually say it is 0 otherwise it will throw an exception.
                if (Convert.ToInt32(DataAccess.GetTotalEmployees()) != 0)
                {
                    return Convert.ToInt32(DataAccess.GetTotalEmployees());
                }
                else {
                    return 0;
                }
            }
        }

        /// <summary>
        /// Gets the overall number of messages sent
        /// </summary>
        /// <returns>the overall number of messages sent</returns>
        public static int TotalMessages
        {
            get
            {   // Trying to see if the value is 0 if yes, I will manually say it is 0 otherwise it will throw an exception.
                if (Convert.ToInt32(DataAccess.GetTotalEmployees()) != 0)
                {
                    return Convert.ToInt32(DataAccess.GetTotalMessages());
                }
                else {
                    return 0;
                }
            }
        }

        /// <summary>
        /// Calculates and returns an average pay among all workers
        /// </summary>
        /// <returns>the average pay among all workers</returns>
        public static decimal AveragePay
        {
            get
            {   // Trying to see if the value is 0 if yes, I will manually say it is 0 otherwise it will throw an exception.
                if (Convert.ToInt32(DataAccess.GetTotalEmployees()) != 0) 
                {

                    return TotalPay / TotalWorkers;
                }

                return 0M;               
            }
        }

        /// <summary>
        ///Returns the employee list
        /// </summary>
        /// <returns>Employee List</returns>
        public static System.Data.DataTable AllWorkers
        {
            get 
            {
                return DataAccess.GetEmployeeList();
            }
        }

        #endregion

    }
}
