using System;
using System.ComponentModel.DataAnnotations;

namespace WolfPack.Models
{
    public class Wolf
    {
        

        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Gender { get; set; }
        [Required]
        public string BirthDate { get; set; }
        [Required]
        public string Location { get; set; }
        // public int PackId{get;set;}
    }
}