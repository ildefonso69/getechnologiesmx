using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TestSoftwareDeveloper.Contracts;
using TestSoftwareDeveloper.Entities;
using TestSoftwareDeveloper.Entities.Models;

namespace TestSoftwareDeveloper.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VentasController : ControllerBase
    {

        private ILoggerManager _logger;
        private IMapper _mapper;
        private IRepositoryWrapper _repository;
        public VentasController(ILoggerManager logger, IRepositoryWrapper repository, IMapper mapper)
        {
            _logger = logger;
            _repository = repository;
            _mapper = mapper;
        }

        [HttpPost]
        [Route("CreatePersona")]
        public IActionResult CreateFactura([FromBody] FacturaDto factura)
        {
            try
            {
                if (factura is null)
                {
                    _logger.LogError("El objeto enviado desde el cliente es null");
                    return BadRequest("El objeto Persona es null");
                }

                if (!ModelState.IsValid)
                {
                    _logger.LogError("El objeto enviado desde el cliente es null.");
                    return BadRequest("Invalido el objeto Model");
                }

                var facturaEntity = _mapper.Map<Factura>(factura);

                _repository.Factura.CreateFactura(facturaEntity);
                _repository.Save();

                var createdFactura = _mapper.Map<FacturaDto>(facturaEntity);

                return CreatedAtRoute("PersonaById", new { id = createdFactura.idFactura }, createdFactura);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Ocurrio una excpecion en el método CreatePersona: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }
        }
    }
}
