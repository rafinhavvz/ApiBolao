
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace apiBolao.Model
{
    [Table("TramitacaoRodada")]
    public class TramitacaoRodada
    {
        [Key]
        [Column("ID")]
        [Display(Name = "ID")]
        public int ID { get; set; }

        [Column("IDBolao")]
        [Display(Name = "IDBolao")]
        public int IDBolao { get; set; }

        [Column("Round")]
        [Display(Name = "Round")]
        public int Round { get; set; }

        [Column("Recuperado")]
        [Display(Name = "Recuperado")]
        public decimal Recuperado { get; set; }

        [Column("Data")]
        [Display(Name = "Data")]
        public DateTime Data { get; set; }

    }
}
