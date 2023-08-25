
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace Bolao_API_MODEL
{
    [Table("ApostasPartidas")]
    public class ApostasPartidas
    {
        [Key]
        [Column("ID")]
        [Display(Name = "Codigo")]
        public int ID { get; set; }

        [Column("IdAposta")]
        [Display(Name = "IdAposta")]
        public int IdAposta { get; set; }

        [Column("IdPartida")]
        [Display(Name = "IdPartida")]
        public int IdPartida { get; set; }

        [Column("Status")]
        [Display(Name = "Status")]
        public string Status { get; set; }


        [Column("Resultado")]
        [Display(Name = "Resultado")]
        public int Resultado { get; set; }
    }
}
