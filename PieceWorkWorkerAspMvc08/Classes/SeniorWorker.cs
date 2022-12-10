// NormalWorker.cs
//         Title: Piecework Worker
//       Created: November 9, 2021
//      Modified: November 9, 2021
//    Written By: Onur Ozkanca
// Adapted from PieceworkWorker by Kyle Chapman, November 2019
// 
// This is a class representing individual worker objects. Workers have their
// own names, messages count, and calculated pay values. As well,
// summary values/properties are available for things like total workers,
// total pay among all workers and the average pay among workers.



using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PieceWorkWorkerAspMvc08.Classes
{
    public class SeniorWorker : PieceWorkWorker
    {

        #region "Variable declarations"

        // Instance variables
        private int employeeMessages;
        private bool isValid = true;
       



        // Consts for the messages value check and rates according to messages count.
        private const int lowest = 1249;
        private const int lowerBetween = 1250;
        private const int lower = 2499;
        private const int lowBetween = 2500;
        private const int low = 3749;
        private const int highBetween = 3500;
        private const int high = 4999;
        private const int higher = 5000;
      

        private const decimal lowestRate = 0.018M;
        private const decimal lowerRate = 0.021M;
        private const decimal lowRate = 0.024M;
        private const decimal highRate = 0.027M;
        private const decimal higherRate = 0.03M;
        private const decimal basePay = 270.00M;

        

        #endregion

        #region "Constructors"

        /// <summary>
        /// SeniorWorker constructor: empty constructor used strictly for inheritance and instantiation
        /// </summary>
        public SeniorWorker()
        {
        }

        /// <summary>
        /// SenirWorker constructor: takes basic parameters, sets values for the instance (including validation) and calculates pay.
        /// </summary>
        /// <param name="nameValue">The worker's first name</param>
        /// <param name="lastName">The worker's last name</param>
        /// <param name="messagesValue">The worker's messages</param>
        public SeniorWorker(string nameValue, string lastName, string messagesValue)
        {
            // Validate and set the worker's name.
            FirstName = nameValue;
            LastName = lastName;
            // Validate and set the worker's Messages.
            Messages = messagesValue;


            // Calculcate the worker's pay and update all summary values.
            FindPay();
        }

        #endregion

        #region "Class methods"

        /// <summary>
        /// Currently called in the constructor, the FindPay() method is
        /// used to calculate a worker's pay using the worker's messages count
        /// and rate according to date count. This also updates all summary values.
        /// </summary>
        protected override void FindPay()
        {
            if (isValid)
            {
                if (employeeMessages <= lowest)
                {

                    employeePay = basePay + (employeeMessages * lowestRate);
                }
                else if (employeeMessages >= lowerBetween && employeeMessages <= lower)
                {
                    employeePay = basePay + (employeeMessages * lowerRate);

                }
                else if (employeeMessages >= lowBetween && employeeMessages <= low)
                {
                    employeePay = basePay + (employeeMessages * lowRate);

                }
                else if (employeeMessages >= highBetween && employeeMessages <= high)
                {
                    employeePay = basePay + (employeeMessages * highRate);
                }
                else if (employeeMessages >= higher)
                {
                    employeePay = basePay + (employeeMessages * higherRate);
                }
                // after the validations it will increase the employee number overall messages and overall payroll.
                overallEmployees++;
                overallMessages += employeeMessages;
                overallPayroll += employeePay;
            }
        }

        /// <summary>
        /// Returns a string that represents the current worker.
        /// </summary>
        /// <returns>the object formatted as a descriptive string</returns>
        public override string ToString()
        {
            return FirstName + " " + LastName + " - " + Pay.ToString("c") + " - " + employeePay + " - Senior Worker. " ;
        }

        #endregion

        #region "Properties"

        /// <summary>
        /// Gets and sets a worker's Messages
        /// </summary>
        new protected internal string Messages
        {
            get
            {
                return employeeMessages.ToString();
            }
            set
            {
                // TO DO
                // Add validation for the number of messages based on the
                // requirements document
                // If the pay rate is not a decimal value, the worker is not valid
                if (int.TryParse(value.Trim(), out employeeMessages))
                {
                    if (employeeMessages <= 0)
                    {

                        isValid = false;
                        throw new ArgumentException(MessagesParameter, "The messages sent must be higher than 0.");
                    }
                }
                // employeeMessages = Convert.ToInteger(value); // This line is dangerous and should probably never appear in your code. Can you explain why? Post about it on the Q&A board and I'll give you a stock.
                else if (value.Trim() == String.Empty)
                {


                    isValid = false;
                    throw new ArgumentNullException(MessagesParameter, "Please enter messages value.");

                }


            }
        }

     

        #endregion
    }
}
