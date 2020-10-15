using System.ComponentModel.DataAnnotations;

namespace WolfPack.Dtos
{
    public class WolfUpdateDto
    {
        // public int Id { get; set; } not needed created by database
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