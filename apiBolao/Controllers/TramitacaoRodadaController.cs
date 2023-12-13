using apiBolao.Model;
using Microsoft.AspNetCore.Mvc;
using System.Security.Cryptography.X509Certificates;

namespace apiBolao.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TramitacaoRodadaController : Controller
    {

        private Api_BLL.TramitacaoRodadaBLL _BLL;

        public TramitacaoRodadaController()
        {
            _BLL = new Api_BLL.TramitacaoRodadaBLL();
        }

        [HttpGet]
        public List<TramitacaoRodada> GetAllItens()
        {
            return _BLL.GetAllItens();
        }

        [HttpGet]
        [Route("Id")]
        public ActionResult<TramitacaoRodada> GetItemIdBolao(int oItemId)
        {
            var oItem = _BLL.GetItemIdBolao(oItemId);

            if(oItem == null)
            {
                return NotFound("ID Invalido");
            }

            return Ok(oItem);
        }

        [HttpGet]
        [Route("IdBolaoList")]
        public List<TramitacaoRodada> GetItemIdBolaoList(int oItemId)
        {
            return _BLL.GetItemIdBolaoList(oItemId);
        }


    }
}
