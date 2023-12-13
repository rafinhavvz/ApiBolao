
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace apiBolao.Model
{
    public class ResultadoAposta
    {
        public int Id { get; set; }
        public int IdPartida { get; set; }
        public int IdAposta { get; set; }
        public int IDBolao { get; set; }
        public int IDTeamHome { get; set; }
        public int IDTeamAway { get; set; }
        public DateTime Data { get; set; }
        public int ResultadoApost { get; set; }
        public int ResultadoReal { get; set; }
        public string Status { get; set; }
        public string NomeTimeHome { get; set; }
        public string NomeTimeAway { get; set; }
        public string LogoTimeHome { get; set; }
        public string LogoTimeAway { get; set; }
    }
}
