using Microsoft.AspNetCore.Mvc;
using Bolao_API_MODEL;
using Bolao_API_BLL;
using System.Security.Cryptography.X509Certificates;

namespace apiBolao.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BoloesController : Controller
    {

        private Bolao_API_BLL.BoloesBLL _BLL;

        public BoloesController()
        {
            _BLL = new Bolao_API_BLL.BoloesBLL();
        }

        [HttpGet]
        public List<Boloes> GetAllItens()
        {
            return _BLL.GetAllItens();
        }

        [HttpGet]
        [Route("Id")]
        public ActionResult<Boloes> GetItemId(int oItemId)
        {
            var oItem = _BLL.GetItemId(oItemId);

            if(oItem == null)
            {
                return NotFound("ID Invalido");
            }

            return Ok(oItem);
        }

        [HttpPost]
        public IActionResult postItem(Boloes oItem)
        {           
            try
            {
                // Chame o método para inserir o novo registro na tabela "Times"
                _BLL.PostItem(oItem);

                // Retorna uma resposta HTTP 200 OK com uma mensagem de sucesso
                return Ok(new { message = "Sucesso: Registro incluido com êxito." });
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
        public IActionResult UpdateItem(Boloes oItem, [FromQuery] int acumulado)
        {           
            try
            {
                if(acumulado > 0)
                {
                   if( oItem.Recuperado == oItem.AcumuladoBase)
                    {
                        oItem.Acumulado = acumulado;
                    }
                    else
                    {
                        oItem.Recuperado = acumulado;
                    }
                }
                // Chame o método para inserir o novo registro na tabela "Times"
                _BLL.UpdateItem(oItem);

                // Retorna uma resposta HTTP 200 OK com uma mensagem de sucesso em formato JSON
                return Ok(new { message = "Sucesso: Registro atualizado com êxito." });

            }            
            catch (Exception ex)
            {
                // Retorna uma resposta HTTP 500 Internal Server Error com a mensagem de erro em formato JSON
                return StatusCode(500, new { error = $"Erro: {ex.Message}" });
            }
        }
    }
}
