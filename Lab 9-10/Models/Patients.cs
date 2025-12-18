using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace Lab.Models
{
    /// <summary>
    /// Таблица со списком пациентов
    /// </summary>
    public class Patients
    {
        [Key]
        public int IdPatients { get; set; }

        public string Surname { get; set; }

        public string Name { get; set; }

        public string LastName { get; set; } = string.Empty;

        [Column(TypeName = "date")]
        public DateTime DateOfBirth { get; set; }

        public string Adress { get; set; } = string.Empty;

        public string PhoneNumber { get; set; } = string.Empty;
    }
}
