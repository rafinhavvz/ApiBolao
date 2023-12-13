
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace apiBolao.Model
{
    [Table("Apostas")]
    public class Apostas
    {
        [Key]
        [Column("ID")]
        [Display(Name = "Id")]
        public int ID { get; set; }

        [Column("IdBolao")]
        [Display(Name = "IdBolao")]
        public int IdBolao { get; set; }

        [Column("IdCliente")]
        [Display(Name = "IdCliente")]
        public int IdCliente { get; set; }

        [Column("Round")]
        [Display(Name = "Round")]
        public int Round { get; set; }

        [Column("Data")]
        [Display(Name = "Data")]
        public DateTime Data { get; set; }

        [Column(TypeName = "char(5)")]
        [Display(Name = "Cupons")]
        public string Cupons { get; set; }

        [Column("Status")]
        [Display(Name = "Status")]
        public string Status { get; set; }

        [Column("ValorApostado")]
        [Display(Name = "ValorApostado")]
        public decimal ValorApostado { get; set; }

        [Column("ValorGanho")]
        [Display(Name = "ValorGanho")]
        public decimal ValorGanho { get; set; }

        [Column("QtdCupom")]
        [Display(Name = "QtdCupom")]
        public int QtdCupom { get; set; }
    }
}
