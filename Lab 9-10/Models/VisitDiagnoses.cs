using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace Lab.Models
{
    /// <summary>
    /// Связующая таблица для таблиц "Visit" и "Diagnoses"
    /// </summary>
    public class VisitDiagnoses
    {
        [Key]
        public int IdVisitDiagnoses { get; set; }

        [ForeignKey("IdVisit")]
        public int IdVisit { get; set; }

        [ForeignKey("IdDiagnoses")]
        public int IdDiagnoses { get; set; }
    }
}
