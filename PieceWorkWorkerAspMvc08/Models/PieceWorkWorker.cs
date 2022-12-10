// PieceWorkWorkerModel.cs
//         Title: IncInc Payroll
//       Created: November 2, 2021
//      Modified: November 9, 2021
//    Written By: Onur Ozkanca
// Adapted from PieceworkWorker by Kyle Chapman, September 2019
//
// This is a model for the data required by the pages.
// It effectively holds and validates all the user input so that
// a worker object can be created by the controller.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using PieceWorkWorkerAspMvc08.Classes;


namespace PieceWorkWorkerAspMvc08.Models
{
    public class PieceWorkWorkerModel
    {
        /// <summary>
        /// The worker's first name.
        /// </summary>
        [Required(AllowEmptyStrings = false, ErrorMessage = "The worker must have a first name")]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        /// <summary>
        /// The worker's last name.
        /// </summary>
        [Required(AllowEmptyStrings = false, ErrorMessage = "The worker must have a last name")]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        /// <summary>
        /// The worker's messages.
        /// </summary>
        [Required(AllowEmptyStrings = false, ErrorMessage = "You must enter the employee messages")]
        [Range((double)PieceWorkWorker.minimumMessages, (double)PieceWorkWorker.upperBound, ErrorMessage = "The messages must be between 1-15000 range.")]
        [Display(Name = "Messages Sent")]
        public decimal Messages { get; set; }
    


        /// <summary>
        /// Last worker's pay.
        /// </summary>
        public static decimal Pay { get; set; }

        /// <summary>
        /// The total number of workers.
        /// </summary>
        public static decimal TotalWorkers { get; set; }

        /// <summary>
        /// The total pay among all workers.
        /// </summary>
        public static decimal TotalPay { get; set; }

        /// <summary>
        /// The average pay among all workers.
        /// </summary>
        public static decimal AveragePay { get; set; }

        /// <summary>
        /// The total messages among all workers.
        /// </summary>
        public static decimal TotalMessages { get; set; }


        /// <summary>
        /// A property that indicates which class the worker belongs to.
        /// </summary>
        public bool IsSenior { get; set; }
      

        public PieceWorkWorkerModel(string nameValue, string rateValue, string hoursValue)
        {

        }

        public PieceWorkWorkerModel()
        {

        }
    }
}
