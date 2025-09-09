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
    public class DirectorioRestServiceController : ControllerBase
    {
        private ILoggerManager _logger;
        private IMapper _mapper;
        private IRepositoryWrapper _repository;
        public DirectorioRestServiceController(ILoggerManager logger, IRepositoryWrapper repository, IMapper mapper)
        {
            _logger = logger;
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet]

        public IActionResult GetAllPersonas()
        {
            try
            {
                var personas = _repository.Persona.GetAllPersonas();
                _logger.LogInfo($"Regreso todos los registros de Personas de la bd.");

                var ownersResult = _mapper.Map<IEnumerable<PersonaDto>>(personas);
                return Ok(ownersResult);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Ocurrio una excepcion en el metodo GetAllOwners, de la clase  DirectorioRestServiceController: {ex.Message}");

                return StatusCode(500, "Internal server error");
            }
        }

        [HttpGet("{idPersona}/GetPersonaById")]

        public IActionResult GetPersonaById(Guid idPersona)
        {
            try
            {
                var persona = _repository.Persona.GetPersonaById(idPersona);
                if (persona is null)
                {
                    _logger.LogError($"La persona con id: {idPersona}, no se encuentra en la bd.");
                    return NotFound();
                }
                else
                {
                    _logger.LogInfo($"Se regreso la persona con id: {idPersona}");

                    var personaResult = _mapper.Map<PersonaDto>(persona);
                    return Ok(personaResult);
                }
            }
            catch (Exception ex)
            {
                _logger.LogError($"Ocurrio una excepción en GetPersonaById: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpGet("{idPersona}/GetPersonaWithDetails")]
        
        public IActionResult GetPersonaWithDetails(Guid idPersona)
        {
            try
            {
                var persona = _repository.Persona.GetPersonaWithDetails(idPersona);
                if (persona == null)
                {
                    _logger.LogError($"La persona con id: {idPersona}, no fue encontrada en la bd");
                    return NotFound();
                }
                else
                {
                    _logger.LogInfo($"Se regreso informacion de la persona con id: {idPersona}");

                    var personaResult = _mapper.Map<PersonaDto>(persona);
                    return Ok(personaResult);
                }
            }
            catch (Exception ex)
            {
                _logger.LogError($"Ocurrio una excepción en el método GetPersonaWithDetails: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpPost]
        [Route("CreatePersona")]
        public IActionResult CreatePersona([FromBody] PersonaForCreationDto persona)
        {
            try
            {
                if (persona is null)
                {
                    _logger.LogError("El objeto enviado desde el cliente es null");
                    return BadRequest("El objeto Persona es null");
                }

                if (!ModelState.IsValid)
                {
                    _logger.LogError("El objeto enviado desde el cliente es null.");
                    return BadRequest("Invalido el objeto Model");
                }

                var personaEntity = _mapper.Map<Persona>(persona);

                _repository.Persona.CreatePersona(personaEntity);
                _repository.Save();

                var createdPersona = _mapper.Map<PersonaDto>(personaEntity);

                return CreatedAtRoute("PersonaById", new { id = createdPersona.idPersona }, createdPersona);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Ocurrio una excpecion en el método CreatePersona: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpPut("{idPersona}")]
        public IActionResult UpdatePersona(Guid idPersona, [FromBody] PersonaForUpdateDto persona)
        {
            try
            {
                if (persona is null)
                {
                    _logger.LogError("El objeto Persona enviado por el cliente es null.");
                    return BadRequest("El objeto persona es null");
                }

                if (!ModelState.IsValid)
                {
                    _logger.LogError("El objeto Persona enviado por el cliente es invalido.");
                    return BadRequest("el modelo de obejto es invalido");
                }

                var personEntity = _repository.Persona.GetPersonaById(idPersona);
                if (personEntity is null)
                {
                    _logger.LogError($"La persona con id: {idPersona}, no se encuentra en la bd.");
                    return NotFound();
                }

                _mapper.Map(persona, personEntity);

                _repository.Persona.UpdatePersona(personEntity);
                _repository.Save();

                return NoContent();
            }
            catch (Exception ex)
            {
                _logger.LogError($"Ocurrio una excepción en en le método UpdatePersona : {ex.Message}");
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpDelete("{idPersona}")]
        public IActionResult DeletePersona(Guid idPersona)
        {
            try
            {
                var persona = _repository.Persona.GetPersonaById(idPersona);
                if (persona == null)
                {
                    _logger.LogError($"La Persona con id: {idPersona}, no se encuentra en la bd");
                    return NotFound();
                }

                if (_repository.Factura.FacturasByPersona(idPersona).Any())
                {
                    _logger.LogError($"No se puede eliminar la persona con id: {idPersona}. esta relacionado con la Factura, favor de Eliminar primero la factura");
                    return BadRequest("No se puede eliminar la persona. tiene una factura relacionada. Elimine primero la factura");
                }

                _repository.Persona.DeletePersona(persona);
                _repository.Save();

                return NoContent();
            }
            catch (Exception ex)
            {
                _logger.LogError($"Ocurrio una excepción en el método DeletePersona: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }
        }
    }

}
