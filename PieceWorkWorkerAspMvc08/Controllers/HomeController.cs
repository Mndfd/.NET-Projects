using PieceWorkWorkerAspMvc08.Models;
using PieceWorkWorkerAspMvc08.Classes;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace PieceWorkWorkerAspMvc08.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        /// <summary>
        /// The Index action for the Home controller.
        /// Sets the totals for the PieceWorkWorker (using a class) to be rendered to the page.
        /// </summary>
        public IActionResult Index()
        {
            var modelInstance = new PieceWorkWorkerModel();

            PieceWorkWorkerModel.Pay = 0M;
            PieceWorkWorkerModel.TotalWorkers = Worker.TotalWorkers;
            PieceWorkWorkerModel.TotalMessages = Worker.TotalMessages;
            PieceWorkWorkerModel.TotalPay = Worker.TotalPay;
            PieceWorkWorkerModel.AveragePay = Worker.AveragePay;
          



            return View(modelInstance);
        }

        /// <summary>
        /// The Index action for the Home controller when a model is passed in on a Post action.
        /// Determines whether the worker is senior or not, determines their pay using one of two classes and assigned other values to the model using those classes to be displayed in the view.
        /// </summary>
        [HttpPost]
        public IActionResult Index(PieceWorkWorkerModel modelInstance)
        {
            // If there are no validation considerations in the model...
            if (ModelState.IsValid)
            {
                // Create but don't instantiate a worker object.
                Worker workerInstance;

                // If the worker is a senior worker...
                if (modelInstance.IsSenior)
                {
                    // Make a new senior worker object and calculate its pay. This also updates the totals.
                    workerInstance = new SeniorWorker(modelInstance.FirstName, modelInstance.LastName, modelInstance.Messages.ToString());
                }
                // If the worker is NOT a senior worker, it's an normal worker.
                else
                {
                    // Make a new normal worker object and calculate its pay. This also updates the totals.
                    workerInstance = new PieceWorkWorker(modelInstance.FirstName, modelInstance.LastName, modelInstance.Messages.ToString());
                }

                // Regardless of the type of worker, get its pay and assign it to the model.
                PieceWorkWorkerModel.Pay = workerInstance.Pay;
            }
            // If the model state isn't valid, set the pay equal to 0 just so that it doesn't display.
            else
            {
                PieceWorkWorkerModel.Pay = 0M;
            }

            // Take all of the totals from the class (or classes) and assign those to the model.
            PieceWorkWorkerModel.TotalWorkers = Worker.TotalWorkers;
            PieceWorkWorkerModel.TotalMessages = PieceWorkWorker.TotalMessages;
            PieceWorkWorkerModel.TotalPay = Worker.TotalPay;
            PieceWorkWorkerModel.AveragePay = Worker.AveragePay;
            



            return View(modelInstance);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult About()
        {
            return View();
        }

        

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
