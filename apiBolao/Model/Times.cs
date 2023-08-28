
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace apiBolao.Model
{
    [Table("Times")]
    public class Times
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

        [Column("IDCamp")]
        [Display(Name = "IDCamp")]
        public int IDCamp { get; set; }

        [Serializable]
        public class TimesCollection : List<Times>
        {
            public TimesCollection() { }

            public TimesCollection(IEnumerable<Times> collection) : base(collection) { }
        }
    }
}
