
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace Bolao_API_MODEL
{
    [Table("Boloes")]
    public class Boloes
    {
        [Key]
        [Column("ID")]
        [Display(Name = "Codigo")]
        public int ID { get; set; }

        [Column("Logo")]
        [Display(Name = "Logo")]
        public string Logo { get; set; }

        [Column("Name")]
        [Display(Name = "Name")]
        public string Name { get; set; }

        [Column("Round")]
        [Display(Name = "Round")]
        public int Round { get; set; }


        [Column("IDTipo")]
        [Display(Name = "IDTipo")]
        public int IDTipo { get; set; }

        [Column("Valor")]
        [Display(Name = "Valor")]
        public decimal Valor { get; set; }

        [Column("Premio")]
        [Display(Name = "Premio")]
        public decimal Premio { get; set; }

        [Column("Acumulado")]
        [Display(Name = "Acumulado")]
        public decimal Acumulado { get; set; }

        [Column("AcumuladoBase")]
        [Display(Name = "AcumuladoBase")]
        public decimal AcumuladoBase { get; set; }

        [Column("Recuperado")]
        [Display(Name = "Recuperado")]
        public decimal Recuperado { get; set; }

        [Column("DataInicio")]
        [Display(Name = "DataInicio")]
        public DateTime DataInicio { get; set; }

        [Column("DataFim")]
        [Display(Name = "DataFim")]
        public DateTime DataFim { get; set; }
    }
}
