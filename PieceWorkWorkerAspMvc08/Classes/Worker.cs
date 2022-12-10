// Worker.cs
//         Title: Piecework Worker
//       Created: November 2, 2021
//      Modified: November 2, 2021
//    Written By: Onur Ozkanca
// Adapted from PieceworkWorker by Kyle Chapman, September 2019
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
    public abstract class Worker
    {

        #region "Variable declarations"

        // Instance variables
        protected decimal employeePay;

        // Shared class variables
        protected static int overallEmployees;
        protected static int overallMessages;
        protected static decimal overallPayroll;



        public const string NameParameter = "name";


        #endregion

        #region "Constructors"

        /// <summary>
        /// Worker constructor: empty constructor used strictly for inheritance and instantiation
        /// </summary>
        public Worker()
        {
        }

        #endregion

        #region "Class methods"

        /// <summary>
        /// All worker objects must have a method of determining their pay.
        /// </summary>
        protected abstract void FindPay();

        /// <summary>
        /// Returns a string that represents the current worker.
        /// </summary>
        /// <returns>the object formatted as a descriptive string</returns>
        public override string ToString()
        {
            return FirstName + " " + LastName + " - " + Pay.ToString("c");
        }

        #endregion

        #region "Property Procedures"

        /// <summary>
        /// Gets and sets a worker's first name
        /// </summary>
        /// <returns>an employee's first name</returns>
        protected internal string FirstName { get; set; }




        /// <summary>
        /// Gets and sets a worker's last name
        /// </summary>
        /// <returns>an employee's last name</returns>
        protected internal string LastName { get; set; }


  

        /// <summary>
        /// Return a worker's calculated pay
        /// </summary>
        protected internal decimal Pay
        {
            get
            {
                return employeePay;
            }
        }

        /// <summary>
        /// Return the total number of workers.
        /// </summary>
        protected internal static int TotalWorkers { get { return overallEmployees; } }

        /// <summary>
        /// Return the total pay among all workers.
        /// </summary>
        protected internal static decimal TotalPay { get { return overallPayroll; } }

        /// <summary>
        /// Return the total hours worked among all workers.
        /// </summary>
        protected internal static decimal TotalMessages { get { return overallMessages; } }


        /// <summary>
        /// Return the total overtime hours among all workers.
        /// </summary>
        protected internal static decimal AveragePay
        {
            get
            {
                if (overallEmployees != 0)
                {

                    return overallPayroll / overallEmployees;
                }
                else
                {
                    return 0M;
                }
            }
        }

        #endregion
    }
}
