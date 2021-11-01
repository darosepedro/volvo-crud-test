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
    public class ModeloController : ControllerBase
    {
  
        private readonly ILogger<ModeloController> _logger;
        private readonly IModeloRepository _modeloRepository;

        public ModeloController(
            ILogger<ModeloController> logger,
            IModeloRepository modeloRepository
        )
        {
            _logger = logger;
            _modeloRepository = modeloRepository;
        }

        [HttpGet]
        public async Task<ActionResult<ModeloResponse>> Get(int Id)
        {
            try
            {
                Modelo response = await _modeloRepository.Get(Id);
                return Ok(response.AsModeloResponse());
            }
            catch (Exception ex)
            {
                _logger.LogError($"ModeloController::Get - Erro inesperado: {ex}");
                return BadRequest(new { message = ex.ToString() });
            }
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ModeloResponse>>> GetList()
        {
            try
            {
                IEnumerable<Modelo> response = (await _modeloRepository.GetList());
                return Ok(response.AsModeloResponseList());
            }
            catch (Exception ex)
            {
                _logger.LogError($"ModeloController::GetList - Erro inesperado: {ex}");
                return BadRequest(new { message = ex.ToString() });
            }
        }

        [HttpPost]
        public async Task<ActionResult<ModeloResponse>> Insert([FromBody] ModeloRequest request)
        {
            try
            {
                Modelo response = await _modeloRepository.Insert(
                    new Modelo(request.Descricao)
                );

                return Ok(response.AsModeloResponse());
            }
            catch (Exception ex)
            {
                _logger.LogError($"ModeloController::Insert - Erro inesperado: {ex}");
                return BadRequest(new { message = ex.ToString() });
            }
        }

        [HttpDelete]
        public async Task<ActionResult<ModeloResponse>> Delete(int Id)
        {
            try
            {
                Modelo response = await _modeloRepository.Delete(Id);
                return Ok(response.AsModeloResponse());
            }
            catch (Exception ex)
            {
                _logger.LogError($"ModeloController::Delete - Erro inesperado: {ex}");
                return BadRequest(new { message = ex.ToString() });
            }
        }

        [HttpPut]
        public async Task<ActionResult<ModeloResponse>> Update([FromBody] ModeloRequest request)
        {
            try
            {
                Modelo response = await _modeloRepository.Update(request.AsModelo());
                return Ok(response.AsModeloResponse());
            }
            catch (Exception ex)
            {
                _logger.LogError($"ModeloController::Update - Erro inesperado: {ex}");
                return BadRequest(new { message = ex.ToString() });
            }
        }
    }
}
