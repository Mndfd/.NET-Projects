// PieceWorksWorkerModel.cs
//         Title: Pieceworkworker
//       Created: November 2, 2021
//     Modified: December 15, 2021
//    Written By: Onur Ozkanca
// Adapted from PieceworkWorker by Kyle Chapman, September 2019
//


using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace PieceWorWorker.Models
{
    public class PieceWorkWorkerModel
    {
        /// <summary>
        /// ID for use with entity framework.
        /// </summary>
        public int ID { get; set; }


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
        [Range((int)1, (int)15000, ErrorMessage = "The messages must be between 1-15000 range.")]
        [Display(Name = "Messages Sent")]
        public int Messages { get; set; }


        /// <summary>
        /// A property that indicates if the worker is a senior worker.
        /// </summary>
        public bool IsSenior { get; set; }

        /// <summary>
        /// This calculates a worker's pay based on their pay rate and hours worked.
        /// </summary>
        /// <returns>A worker's calculated pay.</returns>
        public decimal GetPay() 
        {
            //Constants
            const int lowest = 1249;
            const int lowerBetween = 1250;
            const int lower = 2499;
            const int lowBetween = 2500;
            const int low = 3749;
            const int highBetween = 3500;
            const int high = 4999;
            const int higher = 5000;
            const int basePay = 270;
            decimal lowestRate = 0.025M;
            decimal lowerRate = 0.03M;
            decimal lowRate = 0.035M;
            decimal highRate = 0.041M;
            decimal higherRate = 0.048M;
            // Worker's pay return value.
            decimal pay = 0M;
            if (IsSenior.Equals(true))
            {
                lowestRate = 0.018M;
                lowerRate = 0.021M;
                lowRate = 0.024M;
                highRate = 0.027M;
                higherRate = 0.03M;

                // Calculation
                if (Messages <= lowest)
                {

                    pay = (Messages * lowestRate) + basePay;
                }
                else if (Messages >= lowerBetween && Messages <= lower)
                {
                    pay = (Messages * lowerRate) + basePay;

                }
                else if (Messages >= lowBetween && Messages <= low)
                {
                    pay = (Messages * lowRate) + basePay;

                }
                else if (Messages >= highBetween && Messages <= high)
                {
                    pay = (Messages * highRate) + basePay;
                }
                else if (Messages >= higher)
                {
                    pay = (Messages * higherRate) + basePay;
                }
                return pay;

            }
            else
            {

                // Calculation
                if (Messages <= lowest)
                {

                    pay = Messages * lowestRate;
                }
                else if (Messages >= lowerBetween && Messages <= lower)
                {
                    pay = Messages * lowerRate;

                }
                else if (Messages >= lowBetween && Messages <= low)
                {
                    pay = Messages * lowRate;

                }
                else if (Messages >= highBetween && Messages <= high)
                {
                    pay = Messages * highRate;
                }
                else if (Messages >= higher)
                {
                    pay = Messages * higherRate;
                }

                return pay;
            }

         
           

        }


    }

      
}
