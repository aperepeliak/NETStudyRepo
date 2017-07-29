using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MyCodeCamp.Data;
using MyCodeCamp.Data.Entities;
using Microsoft.Extensions.Logging;
using AutoMapper;
using LearningApiCore.Models;
using System.Collections.Generic;

namespace LearningApiCore.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    public class CampsController : BaseController
    {
        private ICampRepository _repo;
        private ILogger<CampsController> _logger;
        private IMapper _mapper;

        public CampsController(ICampRepository repo,
                               ILogger<CampsController> logger,
                               IMapper mapper)
        {
            _repo = repo;
            _logger = logger;
            _mapper = mapper;
        }

        [HttpGet("")]
        public IActionResult Get()
        {
            var camps = _repo.GetAllCamps();

            return Ok(_mapper.Map<IEnumerable<CampModel>>(camps));
        }

        [HttpGet("{id}", Name = "CampGet")]
        public IActionResult Get(int id, bool includeSpeakers = false)
        {
            try
            {
                Camp camp = null;
                if (includeSpeakers) camp = _repo.GetCampWithSpeakers(id);
                else camp = _repo.GetCamp(id);

                if (camp == null) return NotFound($"Camp {id} was not found");

                return Ok(_mapper.Map<CampModel>(camp));
            }
            catch
            {
            }

            return BadRequest();
        }

        [HttpPost("")]
        public async Task<IActionResult> Post([FromBody]Camp model)
        {
            try
            {
                _logger.LogInformation("Creating new Code Camp");
                _repo.Add(model);
                if (await _repo.SaveAllAsync())
                {
                    var newUri = Url.Link("CampGet", new { id = model.Id });
                    return Created(newUri, model);
                }
                else
                {
                    _logger.LogWarning("Could not save camp to db");
                }
            }
            catch (Exception ex)
            {
                _logger.LogError($"Exception while saving camp: {ex}");
            }

            return BadRequest();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] Camp model)
        {
            try
            {
                var oldCamp = _repo.GetCamp(id);
                if (oldCamp == null) return NotFound($"Couldn't find camp [{id}]");

                // Mapping data
                oldCamp.Name = model.Name ?? oldCamp.Name;
                oldCamp.Description = model.Description ?? oldCamp.Description;
                oldCamp.Moniker = model.Moniker ?? oldCamp.Moniker;
                oldCamp.Location = model.Location ?? oldCamp.Location;
                oldCamp.Length = model.Length > 0 ? model.Length : oldCamp.Length;
                oldCamp.EventDate = model.EventDate != DateTime.MinValue ? model.EventDate : oldCamp.EventDate;

                if (await _repo.SaveAllAsync())
                {
                    return Ok(oldCamp);
                }

            }
            catch (Exception)
            {

                throw;
            }

            return BadRequest("Could not update Camp");
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var oldCamp = _repo.GetCamp(id);

                if (oldCamp == null) return NotFound($"Could found camp with id [{id}]");

                _repo.Delete(oldCamp);

                if (await _repo.SaveAllAsync())
                {
                    return Ok();
                }
            }
            catch
            {
            }

            return BadRequest("Could nit delete camp");
        }
    }
}