using PostApp.Models;
using System.Text.Json;

namespace PostApp.Services
{
    public interface IDataHandlingService
    {
        public Task ReadFromFileToTable();

        public Task ReadFromApiCallToTable(string requestJson, KlientaiViewModel klientaiViewModel);
    }
}
