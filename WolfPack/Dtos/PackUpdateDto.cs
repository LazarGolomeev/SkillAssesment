using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using WolfPack.Models;

namespace WolfPack.Dtos
{
    public class PackUpdateDto
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public List<Wolf> Wolves { get; set; }

    }
}