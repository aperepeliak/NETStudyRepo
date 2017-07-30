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

        [HttpGet("{moniker}", Name = "CampGet")]
        public IActionResult Get(string moniker, bool includeSpeakers = false)
        {
            try
            {
                Camp camp = null;
                if (includeSpeakers) camp = _repo.GetCampByMonikerWithSpeakers(moniker);
                else camp = _repo.GetCampByMoniker(moniker);

                if (camp == null) return NotFound($"Camp {moniker} was not found");

                return Ok(_mapper.Map<CampModel>(camp));
            }
            catch
            {
            }

            return BadRequest();
        }

        [HttpPost("")]
        public async Task<IActionResult> Post([FromBody]CampModel model)
        {
            try
            {
                if (!ModelState.IsValid) return BadRequest(ModelState);

                _logger.LogInformation("Creating new Code Camp");

                var camp = _mapper.Map<Camp>(model);

                _repo.Add(camp);
                if (await _repo.SaveAllAsync())
                {
                    var newUri = Url.Link("CampGet", new { moniker = model.Moniker });
                    return Created(newUri, _mapper.Map<CampModel>(camp));
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

        [HttpPut("{moniker}")]
        public async Task<IActionResult> Put(string moniker, [FromBody] CampModel model)
        {
            try
            {
                if (!ModelState.IsValid) return BadRequest(ModelState);

                var oldCamp = _repo.GetCampByMoniker(moniker);
                if (oldCamp == null) return NotFound($"Couldn't find camp [{moniker}]");

                _mapper.Map(model, oldCamp);

                if (await _repo.SaveAllAsync())
                {
                    return Ok(_mapper.Map<CampModel>(oldCamp));
                }

            }
            catch (Exception ex) { var a = ex; throw; }

            return BadRequest("Could not update Camp");
        }

        [HttpDelete("{moniker}")]
        public async Task<IActionResult> Delete(string moniker)
        {
            try
            {
                var oldCamp = _repo.GetCampByMoniker(moniker);

                if (oldCamp == null) return NotFound($"Could found camp with id [{moniker}]");

                _repo.Delete(oldCamp);

                if (await _repo.SaveAllAsync())
                {
                    return Ok();
                }
            }
            catch
            {
            }

            return BadRequest("Could not delete camp");
        }
    }
}