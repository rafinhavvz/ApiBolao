using Microsoft.AspNetCore.Mvc;
using System.Security.Cryptography.X509Certificates;
using apiBolao.Model;

namespace apiBolao.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PartidasController : Controller
    {

        private Api_BLL.PartidasBLL _BLL;

        public PartidasController()
        {
            _BLL = new Api_BLL.PartidasBLL();
        }

        [HttpGet]
        public List<Partidas> GetAllItens()
        {
            return _BLL.GetAllItens();
        }

        [HttpGet]
        [Route("Id")]
        public ActionResult<Partidas> GetItemId(int oItemId)
        {
            var oItem = _BLL.GetItemId(oItemId);

            if (oItem == null)
            {
                return NotFound("ID Invalido");
            }

            return Ok(oItem);
        }

        [HttpPost]
        public IActionResult PostItem([FromBody] IEnumerable<Partidas> oItem)
        {
            try
            {
                if (oItem == null || !oItem.Any())
                {
                    return BadRequest("A lista de Partidas está vazia ou nula.");
                }

                // Chame o método para inserir o novo registro na tabela "Times"
                _BLL.PostItem(oItem);

                // Retorna uma resposta HTTP 200 OK com uma mensagem de sucesso
                return Ok(new { message = "Sucesso: Registros inseridos com êxito." });
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
            public IEnumerable<Partidas> UpdateItem(IEnumerable<Partidas> oItem)
            {
                return _BLL.UpdateItem(oItem);
            }
        }
    }
