using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VolvoCrudApi.Models;
using VolvoCrudApi.Repositories;
using VolvoCrudApi.Requests;

namespace VolvoCrudApi.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    [Produces("application/json")]
    [Consumes("application/json")]
    public class CaminhaoController : ControllerBase
    {
  
        private readonly ILogger<CaminhaoController> _logger;
        private readonly ICaminhaoRepository _caminhaoRepository;

        public CaminhaoController(
            ILogger<CaminhaoController> logger,
            ICaminhaoRepository caminhaoRepository
        )
        {
            _logger = logger;
            _caminhaoRepository = caminhaoRepository;
        }

        [HttpGet]
        public async Task<ActionResult<CaminhaoResponse>> Get(int Id)
        {
            try
            {
                Caminhao response = await _caminhaoRepository.Get(Id);
                return Ok(response.AsCaminhaoResponse());
            }
            catch (Exception ex)
            {
                _logger.LogError($"CaminhaoController::Get - Erro inesperado: {ex}");
                return BadRequest(new { message = ex.ToString() });
            }
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<CaminhaoResponse>>> GetList()
        {
            try
            {
                IEnumerable<Caminhao> response = (await _caminhaoRepository.GetList());
                return Ok(response.AsCaminhaoResponseList());
            }
            catch (Exception ex)
            {
                _logger.LogError($"CaminhaoController::GetList - Erro inesperado: {ex}");
                return BadRequest(new { message = ex.ToString() });
            }
        }

        [HttpPost]
        public async Task<ActionResult<CaminhaoResponse>> Insert([FromBody] CaminhaoInsertRequest request)
        {
            try
            {                
                Caminhao response = await _caminhaoRepository.Insert(request.AsCaminhao());

                return Ok(response.AsCaminhaoResponse());
            }
            catch (Exception ex)
            {
                _logger.LogError($"CaminhaoController::Insert - Erro inesperado: {ex}");
                return BadRequest(new { message = ex.Message });
            }
        }

        [HttpDelete]
        public async Task<ActionResult<CaminhaoResponse>> Delete(int Id)
        {
            try
            {
                Caminhao response = await _caminhaoRepository.Delete(Id);
                return Ok(response.AsCaminhaoResponse());
            }
            catch (Exception ex)
            {
                _logger.LogError($"CaminhaoController::Delete - Erro inesperado: {ex}");
                return BadRequest(new { message = ex.ToString() });
            }
        }

        [HttpPut]
        public async Task<ActionResult<CaminhaoResponse>> Update([FromBody] CaminhaoUpdateRequest request)
        {
            try
            {
                Caminhao response = await _caminhaoRepository.Update(request.AsCaminhao());
                return Ok(response.AsCaminhaoResponse());
            }
            catch (Exception ex)
            {
                _logger.LogError($"ModeloController::Update - Erro inesperado: {ex}");
                return BadRequest(new { message = ex.ToString() });
            }
        }
    }
}
