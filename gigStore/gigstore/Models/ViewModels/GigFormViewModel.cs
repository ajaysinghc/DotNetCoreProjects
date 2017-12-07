using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace gigstore.Models.ViewModels
{
    public class GigFormViewModel
    {
        [Required]
        public string Venue { get; set; }
        [Required]
        public string Date{get;set;}
        [Required]
        public string Time { get; set; }
        [Required]
        public byte Genre { get; set; }
        
        public IEnumerable<Genre> Genres { get; set; }
    }
}