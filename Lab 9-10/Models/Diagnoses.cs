using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace Lab.Models
{
    /// <summary>
    /// Таблица, что содержит в себе варианты диагнозов пациенотв
    /// </summary>
    public class Diagnoses
    {
        [Key]
        public int IdDiagnoses { get; set; }

        public string name { get; set; }

        public string description { get; set; }
    }
}
