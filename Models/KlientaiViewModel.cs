using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using PostApp.Tables;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace PostApp.Models
{
    public class KlientaiViewModel
    {
        public List<KlientasModel> Klientai { get; set; } = new List<KlientasModel>();
        [Required]
        public string ApiKey { get; set; } = "postit.lt-examplekey";
        public List<SelectListItem> Addresses { get; set; } = new List<SelectListItem>();
        [Required]
        public string SelectedAddress { get; set; }
    }

    public class KlientasModel
    {

        [Required]
        public string Name { get; set; }

        [Required]
        public string Address { get; set; }

        public string PostCode { get; set; }

        public KlientasModel(Klientai klientai)
        {
            Name = klientai.Name;
            Address = klientai.Address;
            PostCode = klientai.PostCode;
        }
    }
}