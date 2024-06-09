using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Web_Example_Temp.Models
{
    public class Öğrenci
    {
        [Key]
        public int Id { get; set; } 

        [Required]
        [MaxLength(20)]
        public string Ad { get; set; } 

        [Required]
        [MaxLength(20)]
        public string Soyad { get; set; } 

        [ForeignKey("Okul")]
        public int OkulId { get; set; }
        public Okul Okul { get; set; } 

        public ICollection<ÖğrenciVeli> ÖğrenciVeliler { get; set; } 
    }
}
