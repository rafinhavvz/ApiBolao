
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace Bolao_API_MODEL
{
    [Table("Campeonatos")]
    public class Campeonatos
    {
        [Key]
        [Column("ID")]
        [Display(Name = "Codigo")]
        public int ID { get; set; }

        [Column("Logo")]
        [Display(Name = "Logo")]
        public string? Logo { get; set; }

        [Column("Name")]
        [Display(Name = "Name")]
        public string? Name { get; set; }

        [Column("Pais")]
        [Display(Name = "Pais")]
        public string? Pais { get; set; }
    }
}
