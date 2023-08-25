﻿
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace Bolao_API_MODEL
{
    [Table("Tipos")]
    public class Tipos
    {
        [Key]
        [Column("ID")]
        [Display(Name = "Codigo")]
        public int ID { get; set; }

        [Column("Name")]
        [Display(Name = "Name")]
        public string Name { get; set; }
    }
}
