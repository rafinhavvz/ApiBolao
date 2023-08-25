using Microsoft.AspNetCore.Mvc;
using Bolao_API_MODEL;
using Bolao_API_BLL;
using System.Security.Cryptography.X509Certificates;

namespace apiBolao.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TimesController : Controller
    {

        private Bolao_API_BLL.TimesBLL _BLL;

        public TimesController()
        {
            _BLL = new Bolao_API_BLL.TimesBLL();
        }

        [HttpGet]
        public List<Times> GetAllItens()
        {
            return _BLL.GetAllItens();
        }

        [HttpGet]
        [Route("Id")]
        public ActionResult<Times> GetItemId(int oItemId)
        {
            var oItem = _BLL.GetItemId(oItemId);

            if(oItem == null)
            {
                return NotFound("ID Invalido");
            }

            return Ok(oItem);
        }

        [HttpPost]
        public IActionResult postItem(Times oItem)
        {           
            try
            {
                // Chame o método para inserir o novo registro na tabela "Times"
                _BLL.PostItem(oItem);

                // Retorna uma resposta HTTP 200 OK com uma mensagem de sucesso
                return Ok("Sucesso: Registro inserido com êxito.");
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
        public Times UpdateItem(Times oItem)
        {
           return _BLL.UpdateItem(oItem);
        }
    }
}
