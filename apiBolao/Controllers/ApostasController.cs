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
        public Apostas UpdateItem(Apostas oItem)
        {
           return _BLL.UpdateItem(oItem);
        }
    }
}
