using apiBolao.Api_BLL;
using apiBolao.Model;
using Microsoft.AspNetCore.Mvc;
using System.Security.Cryptography.X509Certificates;

namespace apiBolao.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ApostasController : Controller
    {

        private Api_BLL.ApostasBLL _BLL;

        public ApostasController()
        {
            _BLL = new Api_BLL.ApostasBLL();
        }

        [HttpGet]
        public List<Apostas> GetAllItens()
        {
            return _BLL.GetAllItens();
        }

        [HttpGet]
        [Route("Id")]
        public ActionResult<Apostas> GetItemId(int oItemId)
        {
            var oItem = _BLL.GetItemId(oItemId);

            if(oItem == null)
            {
                return NotFound("ID Invalido");
            }

            return Ok(oItem);
        }

        [HttpGet]
        [Route("IdBolao")]
        public ActionResult<Apostas> GetItemIdBolao(int oItemId)
        {
            var oItem = _BLL.GetItemIdBolao(oItemId);

            if (oItem == null)
            {
                return NotFound("ID Invalido");
            }

            return Ok(oItem);
        }

        [HttpPost]
        public IActionResult postItem(Apostas oItem)
        {           
            try
            {
                // Chame o método para inserir o novo registro na tabela "Times"
                var idGerado = _BLL.PostItem(oItem);

                // Retorna uma resposta HTTP 200 OK com uma mensagem de sucesso em formato JSON
                return Ok(new { message = "Sucesso: Registro atualizado com êxito.", IdAposta = idGerado });
            }
            catch (Exception ex)
            {
                // Retorna uma resposta HTTP 500 Internal Server Error com a mensagem de erro
                return StatusCode(500, $"Erro: {ex.Message}");
            }
        }

        [HttpDelete]
        public IActionResult DeleteItem(int oItemId)
        {
            try
            {
                // Chame o método para inserir o novo registro na tabela "Times"
                _BLL.DeleteItem(oItemId);

                // Retorna uma resposta HTTP 200 OK com uma mensagem de sucesso
                return Ok("Sucesso: Registro excluido com êxito.");
            }
            catch (Exception ex)
            {
                // Retorna uma resposta HTTP 500 Internal Server Error com a mensagem de erro
                return StatusCode(500, $"Erro: {ex.Message}");
            }
        }

        [HttpPut]
        [Route("Update")]
        public IActionResult UpdateItem(List<ModCupom> oItems)
        {
            try
            { // Mapear as propriedades de ModCupom para Apostas e Partidas
                List<Apostas> apostasList = new List<Apostas>();
                List<ApostasPartidas> partidasList = new List<ApostasPartidas>();
                Boloes oBolao = new Boloes();
                foreach (var modCupom in oItems)
                {
                    Apostas apostas = new Apostas
                    {
                        ID = modCupom.Id,
                        IdBolao = modCupom.IdBolao,
                        IdCliente = modCupom.IdCliente,
                        Round = modCupom.Round,
                        Data = modCupom.Data,
                        Cupons = modCupom.Cupons,
                        Status = modCupom.Status,
                        ValorApostado = modCupom.ValorApostado,
                        ValorGanho = modCupom.ValorGanho,
                        QtdCupom = modCupom.QtdCupom
                        // Mapeie outras propriedades conforme necessário
                    };
                   
                        foreach (var partid in modCupom.Partidas)
                        {
                            ApostasPartidas partidas = new ApostasPartidas
                            {
                                ID = partid.Id,
                                IdAposta = modCupom.Id,
                                IdPartida = partid.IdPartida,
                                Status = partid.Status,
                                Resultado = partid.ResultadoApost
                                // Mapeie outras propriedades conforme necessário
                            };

                            partidasList.Add(partidas);
                        
                        }
                    



                        apostasList.Add(apostas);
                   
                }


                ApostasBLL oApostaBLL = new ApostasBLL();
                BoloesBLL oBoloesBLL = new BoloesBLL();
                ApostasPartidasBLL oApostaPartidaBLL = new ApostasPartidasBLL();
                
                oApostaBLL.UpdateItemArray(apostasList);
                oApostaPartidaBLL.UpdateItemArray(partidasList);

                 oBolao = oBoloesBLL.GetItemId(apostasList[0].IdBolao);

                oBolao.Status = "FINALIZADO";

                oBoloesBLL.UpdateItem(oBolao);

                // Retorna uma resposta HTTP 200 OK com uma mensagem de sucesso em formato JSON
                return Ok(new { message = "Sucesso: Registros atualizados com êxito." });
            }
            catch (Exception ex)
            {
                // Retorna uma resposta HTTP 500 Internal Server Error com a mensagem de erro
                return StatusCode(500, $"Erro: {ex.Message}");
            }
        }


    }
}
