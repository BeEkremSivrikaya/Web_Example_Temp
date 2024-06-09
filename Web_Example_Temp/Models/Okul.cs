using System.ComponentModel.DataAnnotations;

namespace Web_Example_Temp.Models
{
    public class Okul
    {
        [Key]
        public int Id { get; set; } 

        [Required]
        [MaxLength(20)]
        public string Ad { get; set; } 

        public ICollection<Öğrenci> Öğrenciler { get; set; } 
    }
}
