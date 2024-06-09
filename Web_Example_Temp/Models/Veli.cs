using System.ComponentModel.DataAnnotations;

namespace Web_Example_Temp.Models
{
    public class Veli
    {
        [Key]
        public int Id { get; set; } 

        [Required]
        [MaxLength(20)]
        public string Ad { get; set; } 

        [Required]
        [MaxLength(20)]
        public string Soyad { get; set; } 

        public ICollection<ÖğrenciVeli> ÖğrenciVeliler { get; set; } 
    }
}
