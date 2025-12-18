using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace Lab.Models
{
   /// <summary>
   /// Таблица для содержания специализаций у врачей
   /// </summary>
    public class Specialties
    {
        [Key]
        public int IdSpecialty { get; set; }

        public string Name { get; set; }

        public string description { get; set; }
    }
}

