using Microsoft.EntityFrameworkCore;
using PostApp.Controllers;
using PostApp.Data;
using PostApp.Helpers;
using PostApp.Models;
using PostApp.Tables;
using System.IO;
using System.Text.Json;

namespace PostApp.Services
{
    public class DataHandlingService : IDataHandlingService
    {
        private readonly ILogger<DataHandlingService> _logger;
        private readonly PostContext _dbContext;

        public DataHandlingService(ILogger<DataHandlingService> logger, PostContext dbContext)
        {
            _logger = logger;
            _dbContext = dbContext;
        }

        public async Task ReadFromFileToTable()
        {
            var filename = "klientai.json";
            var filesLocation = "Files";

            var path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, filesLocation, filename);

            using FileStream stream = File.OpenRead(path);
            var result = await JsonSerializer.DeserializeAsync<Klientai[]>(stream);
            _logger.Log(LogLevel.None, $"Nuskaitytas klientu duomenu failas {filename}");
            await AddFromFileToTable(result);
        }

        public async Task ReadFromApiCallToTable(string requestJson, KlientaiViewModel klientaiViewModel)
        {
            var result = JsonSerializer.Deserialize<PostitApiModel>(requestJson);
            if(result.success)
            {
                await UpdateEntries(klientaiViewModel.SelectedAddress, result.data[0].post_code);
            }
        }

        private async Task AddFromFileToTable(Klientai[] clients)
        {
            var comparer = new KlientaiComparer();
            await _dbContext.AddEntitiesToDatabaseAsync(clients, comparer);
            _logger.Log(LogLevel.None, $"Failo duomenys irasyti i duomenu baze.");

        }

        private async Task UpdateEntries(string addressToUpdate, string newPostCode)
        {
            var client = _dbContext.GetAll<Klientai>().SingleOrDefault(s => s.Address == addressToUpdate);
            client.PostCode = newPostCode;

            await _dbContext.UpdateEntityAsync(client);
            _logger.Log(LogLevel.None, $"Pasto indeksas atnaujintas adresui {addressToUpdate} su {newPostCode}.");
        }

    }
}
