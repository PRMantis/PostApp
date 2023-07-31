using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PostApp.Data;
using PostApp.Helpers;
using PostApp.Models;
using PostApp.Services;
using PostApp.Tables;
using System.Diagnostics;

namespace PostApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly HttpClient _client;
        private readonly IDataHandlingService _dataHandlingService;
        private readonly PostContext _dbContext;

        public HomeController(
            ILogger<HomeController> logger,
            HttpClient client,
            IDataHandlingService dataHandlingService,
            PostContext dbContext)
        {
            _logger = logger;
            _client = client;
            _dataHandlingService = dataHandlingService;
            _dbContext = dbContext;
        }


        [HttpGet]
        public IActionResult Index()
        {
            var klientaiFromDatabase = _dbContext.GetAll<Klientai>().Select(s => new KlientasModel(s)).ToList();
            var klientaiViewModel = new KlientaiViewModel()
            {
                Klientai = klientaiFromDatabase
            };
            klientaiViewModel.Addresses = klientaiFromDatabase.Select(s => new SelectListItem
            {
                Value = s.Address,
                Text = s.Address,
                Selected = false
            }).ToList();

            return View(klientaiViewModel);
        }

        [HttpPost]
        public async Task<IActionResult> ReadDataFromFile()
        {
            await _dataHandlingService.ReadFromFileToTable();
            _logger.Log(LogLevel.None, "Paspautas mygtukas nuskaityti duomenis is failo.");

            return RedirectToAction("Index");
        }

        [HttpPost]
        public async Task<IActionResult> MakeApiCallByAddress(KlientaiViewModel klientaiViewModel)
        {
            await CallApiAsyncAndReadRequestToTable(klientaiViewModel);

            return RedirectToAction("Index");
        }

        private async Task<IActionResult> CallApiAsyncAndReadRequestToTable(KlientaiViewModel klientaiViewModel)
        {
            var json = await _client.GetStringAsync(
                $"{ApiParameters.ApiAddress}?{ApiParameters.Term}={klientaiViewModel.SelectedAddress}&{ApiParameters.Key}={klientaiViewModel.ApiKey}");

            await _dataHandlingService.ReadFromApiCallToTable(json, klientaiViewModel);
            return Ok();
        }
    }
}