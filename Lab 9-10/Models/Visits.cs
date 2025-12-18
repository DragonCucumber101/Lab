using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace Lab.Models
{
    /// <summary>
    /// Клиенты, посещающие больницы. Связано с таблицей "doctors" и "Patients"
    /// </summary>
    public class Visits
    {
        [Key]
        public int IdVisits { get; set; }
        
        [ForeignKey("IdPatients")]
        public int IdPatients { get; set; }
        
        [ForeignKey("IdDoctor")]
        public int IdDoctor { get; set; }
        
        [Column(TypeName = "VisitDatetime")]
        public DateTime VisitDatetime { get; set; }
        
        public string ChiefComplaint { get; set; }
    }
}
