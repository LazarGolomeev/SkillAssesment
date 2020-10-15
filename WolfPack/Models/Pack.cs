using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace WolfPack.Models
{
    public class Pack
    {
        [Key]
        public int Id{get; set;}
        public string Name { get; set; }
        [Required]
        public List<Wolf> Wolves { get; set; }

    }
}