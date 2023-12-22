using apiBolao.Api_BLL;
using apiBolao.Model;
using Microsoft.AspNetCore.Mvc;
using System.IO;
using System.Reflection;
using System.Security.Cryptography.X509Certificates;
using static System.Net.Mime.MediaTypeNames;

namespace apiBolao.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BoloesController : Controller
    {

        private Api_BLL.BoloesBLL _BLL;

        public BoloesController()
        {
            _BLL = new Api_BLL.BoloesBLL();
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

            if (oItem == null)
            {
                return NotFound("ID Invalido");
            }

            return Ok(oItem);
        }

        [HttpPost]
        public IActionResult PostItem([FromBody] Boloes oItem)
        {
            try
            {
                oItem.Acumulado = oItem.AcumuladoBase;

                // Chame o método para inserir o novo registro na tabela "Boloes" (ou como sua tabela se chama)
                var oIdGerado = _BLL.PostItem(oItem);

                TramitacaoRodada otramitacaoRodada = new TramitacaoRodada();

                TramitacaoRodadaBLL tramitacaoRodadaBLL = new TramitacaoRodadaBLL();

                otramitacaoRodada.IDBolao = oIdGerado;
                otramitacaoRodada.Recuperado = oItem.Recuperado;
                otramitacaoRodada.Round = oItem.Round;
                otramitacaoRodada.Data = oItem.DataFim;

                tramitacaoRodadaBLL.PostItem(otramitacaoRodada);
                if (oIdGerado > 0)
                {
                    // Retorna uma resposta HTTP 200 OK com uma mensagem de sucesso
                    return Ok(new { message = "Sucesso: Registro incluído com êxito.", idGerado = oIdGerado });
                }
                return StatusCode(500, $"Erro ao gerar Bolao");

            }
            catch (Exception ex)
            {
                // Retorna uma resposta HTTP 500 Internal Server Error com a mensagem de erro
                return StatusCode(500, $"Erro: {ex.Message}");
            }
        }

        [HttpGet]
        [Route("GetImage")]
        public IActionResult GetImage(string fileName)
        {

            // Nome da pasta dentro do diretório do projeto
            var pastaDeArmazenamento = "1.BoloesImagens";

            // Combine o caminho da pasta de armazenamento com o diretório do projeto
            var projetoDiretorio = Directory.GetCurrentDirectory();
            var pastaCompleta = Path.Combine(projetoDiretorio, pastaDeArmazenamento);
            // Combine o caminho da pasta onde as imagens estão armazenadas com o fileName
            string imagePath = Path.Combine(pastaCompleta, fileName); // Certifique-se de que fileName contenha a extensão da imagem

            if (System.IO.File.Exists(imagePath))
            {
                // Carregue a imagem e defina o tipo de conteúdo
                byte[] imageBytes = System.IO.File.ReadAllBytes(imagePath);
                return File(imageBytes, "image/jpeg"); // Substitua "image/jpeg" pelo tipo de conteúdo apropriado para o formato da imagem
            }
            else
            {
                return NotFound(); // Retorna 404 se a imagem não for encontrada
            }
        }

        [HttpPost]
        [Route("Image")]
        public async Task<ActionResult> PostImage(IFormFile Imagem)
        {
            try
            {

                // Verifique se uma imagem foi enviada
                if (Imagem == null || Imagem.Length == 0)
                {
                    return BadRequest("Erro");
                }

                // Nome da pasta dentro do diretório do projeto
                var pastaDeArmazenamento = "1.BoloesImagens";

                // Combine o caminho da pasta de armazenamento com o diretório do projeto
                var projetoDiretorio = Directory.GetCurrentDirectory();
                var pastaCompleta = Path.Combine(projetoDiretorio, pastaDeArmazenamento);

                // Verifique se a pasta existe, e se não existir, crie-a
                if (!Directory.Exists(pastaCompleta))
                {
                    Directory.CreateDirectory(pastaCompleta);
                }
                // Gere um nome de arquivo único (por exemplo, usando Guid.NewGuid())
                var uniqueFileName = GenerateUniqueFileName(Imagem.FileName);

                // Combine o caminho da pasta de armazenamento com o nome de arquivo único
                var filePath = Path.Combine(pastaCompleta, uniqueFileName);

                // Salve o arquivo no sistema de arquivos
                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    Imagem.CopyTo(fileStream);
                }

                var imageUrl = $"/Boloes/GetImage?fileName={uniqueFileName}";

                return Ok(new { urlImage = imageUrl });

            }
            catch
            {
                return BadRequest("Erro");
            }
           

        }

        private string GenerateUniqueFileName(string originalFileName)
        {
            var timestamp = DateTime.Now.Ticks;
            var randomValue = Guid.NewGuid().ToString("N").Substring(0, 10); // Valor aleatório de 10 caracteres
            var fileExtension = Path.GetExtension(originalFileName);
            var uniqueFileName = $"{timestamp}_{randomValue}{fileExtension}";
            return uniqueFileName;
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
                TramitacaoRodada otramitacaoRodada = new TramitacaoRodada();
                TramitacaoRodadaBLL tramitacaoRodadaBLL = new TramitacaoRodadaBLL();

                otramitacaoRodada = tramitacaoRodadaBLL.GetItemIdBolao(oItem.ID);

                if (acumulado > 0)
                {
                    if (oItem.Recuperado < oItem.AcumuladoBase)
                    {
                        // Atualize oItem.Recuperado com base no valor de acumulado
                        oItem.Recuperado = acumulado;
                        otramitacaoRodada.Recuperado = acumulado;

                        // Verifique se oItem.Recuperado ultrapassou oItem.AcumuladoBase
                        if (oItem.Recuperado >= oItem.AcumuladoBase)
                        {
                            // Se oItem.Recuperado alcançou ou ultrapassou oItem.AcumuladoBase,
                            // atualize oItem.Acumulado com o valor restante
                            oItem.Acumulado = acumulado;
                            oItem.Recuperado = oItem.AcumuladoBase; // O Recuperado agora iguala o AcumuladoBase
                            otramitacaoRodada.Recuperado = oItem.AcumuladoBase;
                        }
                    }
                    else
                    {
                        // Se oItem.Recuperado já é maior ou igual a oItem.AcumuladoBase,
                        // atualize oItem.Acumulado com base no valor de acumulado
                        oItem.Acumulado = acumulado;
                    }
                }
                // Chame o método para inserir o novo registro na tabela "Times"
                _BLL.UpdateItem(oItem);

                otramitacaoRodada.Round = oItem.Round;
                tramitacaoRodadaBLL.UpdateItem(otramitacaoRodada);


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
