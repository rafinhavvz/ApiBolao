using Microsoft.AspNetCore.Mvc;
using apiBolao.Model;

namespace apiBolao.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ApostasPartidasController : Controller
    {

        private Api_BLL.ApostasPartidasBLL _BLL;

        public ApostasPartidasController()
        {
            _BLL = new Api_BLL.ApostasPartidasBLL();
        }

        [HttpGet]
        public List<ApostasPartidas> GetAllItens()
        {
            return _BLL.GetAllItens();
        }

        [HttpGet]
        [Route("Id")]
        public ActionResult<List<ResultadoAposta>> GetItemId(int oItemId)
        {
            List<ResultadoAposta> resultadosApostas = _BLL.GetItemId(oItemId);

            if (resultadosApostas.Count == 0)
            {
                return NotFound("ID Inválido");
            }

            return resultadosApostas;
        }

        [HttpPost]
        public IActionResult postItem(IEnumerable<ApostasPartidas> oItem)
        {           
            try
            {
                // Chame o método para inserir o novo registro na tabela "Times"
                _BLL.PostItem(oItem);

                // Retorna uma resposta HTTP 200 OK com uma mensagem de sucesso
                return Ok(new { message = "Sucesso: Registro atualizado com êxito." });
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
        public ApostasPartidas UpdateItem(ApostasPartidas oItem)
        {
           return _BLL.UpdateItem(oItem);
        }
    }
}
