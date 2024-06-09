using System.ComponentModel.DataAnnotations.Schema;

namespace Web_Example_Temp.Models
{
    public class ÖğrenciVeli
    {
        [ForeignKey("Öğrenci")]
        public int ÖğrenciId { get; set; } 
        public Öğrenci Öğrenci { get; set; } 

        [ForeignKey("Veli")]
        public int VeliId { get; set; } 
        public Veli Veli { get; set; } 
    }
}
