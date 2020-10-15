using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using WolfPack.Models;

namespace WolfPack.Dtos
{
    public class PackReadDto
    {
        [Key]
        public int Id{get; set;}
        public string Name { get; set; }
        [Required]
        public List<Wolf> Wolves { get; set; }

    }
}