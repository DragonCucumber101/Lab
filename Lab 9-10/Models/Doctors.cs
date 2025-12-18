using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace Lab.Models
{
    /// <summary>
    /// Таблица со списком врачей. Связана с таблицей "Specialty" специализации
    /// </summary>
    public class Doctors
    {
        [Key]
        public int IdDoctors { get; set; }
        
        public string Surname { get; set; }
        
        public string Name { get; set; }        
        
        public string? LastName { get; set; }
        
        [Column(TypeName = "date")]
        public DateTime DateOfBirth { get; set; }
        
        [ForeignKey("SpecialtyId")]
        public int SpecialtyId { get; set; }

        public Specialties Specialty { get; set; } 

    }
}
