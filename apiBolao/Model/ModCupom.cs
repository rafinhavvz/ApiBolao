using apiBolao.Model;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace apiBolao.Model
{
    public class Partida
    {
        public int Id { get; set; }
        public DateTime Data { get; set; }
        public int IdAposta { get; set; }
        public int IdBolao { get; set; }
        public int IdPartida { get; set; }
        public int IdTeamAway { get; set; }
        public int IdTeamHome { get; set; }
        public string LogoTimeAway { get; set; }
        public string LogoTimeHome { get; set; }
        public string NomeTimeAway { get; set; }
        public string NomeTimeHome { get; set; }
        public int ResultadoApost { get; set; }
        public int ResultadoReal { get; set; }
        public string Status { get; set; }
    }

    public class ModCupom
    {
        public string Cupons { get; set; }
        public DateTime Data { get; set; }
        public int Id { get; set; }
        public int IdBolao { get; set; }
        public int IdCliente { get; set; }
        public int QtdCupom { get; set; }
        public int Round { get; set; }
        public string Status { get; set; }
        public decimal ValorApostado { get; set; }
        public decimal ValorGanho { get; set; }
        public List<Partida> Partidas { get; set; }
    }
}