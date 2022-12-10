using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PieceWorWorker.Models;
// WorkerContext.cs
//         Title: Pieceworkworker
//       Created: November 2, 2021
//      Modified: December 15, 2021
//    Written By: Onur Ozkanca
// Adapted from PieceworkWorker by Kyle Chapman, September 2019
// Context for our page.


namespace PieceWorWorker.Contexts
{
    public class WorkerContext : DbContext
    {

        /// <summary>
        /// Context Constructor
        /// </summary>  
        public WorkerContext(DbContextOptions<WorkerContext> options) : base(options)
        {
        }


        /// <summary>               
        /// Only one set in this database! Refers to PieceWorkWorker model.
        /// </summary>
        public DbSet<PieceWorkWorkerModel> Workers { get; set; }
    }
}
