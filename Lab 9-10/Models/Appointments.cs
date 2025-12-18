using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace Lab.Models
{
    /// <summary>
    /// Таблица с назначениями. Связана с таблицей "Patients" и "Doctor"
    /// </summary>
    public class Appointments
    {
        [Key]
        public int IdAppointment { get; set; }

        [ForeignKey("IdPatients")]
        public int IdPatients { get; set; }

        [ForeignKey("IdDoctor")]
        public int IdDoctor { get; set; }

        [Column(TypeName = "date")]
        public DateTime AppointmentDatetime { get; set; }

        public string ReasonForVisit { get; set; }

        public Patients Patient { get; set; } 

        public Doctors Doctor { get; set; }
    }
}
