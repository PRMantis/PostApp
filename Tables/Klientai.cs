using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace PostApp.Tables
{
    [PrimaryKey(nameof(Name), nameof(Address))]
    public class Klientai
    {
        [Required, Key]
        public required string Name { get; set; }

        [Required, Key]
        public required string Address { get; set; }

        public string PostCode { get; set; }
    }
}
