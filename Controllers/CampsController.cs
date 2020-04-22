using AutoMapper;
using CoreCodeCamp.Data;
using CoreCodeCamp.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Internal;
using System;
using System.Threading.Tasks;

namespace CoreCodeCamp.Controllers
{
    [Route("api/[controller]")]
    public class CampsController : ControllerBase
    {
        private readonly ICampRepository _campRepository;
        private readonly IMapper _mapper;

        public CampsController(ICampRepository campRepository, IMapper mapper)
        {
            _campRepository = campRepository;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetCamps(bool includeTalks = false)
        {
            try
            {
                var results = await _campRepository.GetAllCampsAsync(includeTalks);
                var models = _mapper.Map<CampModel[]>(results);
                return Ok(models);
            }
            catch (Exception)
            {
                return StatusCode(500, "Database Failure");
            }
        }

        [HttpGet("{Moniker}")]
        public async Task<ActionResult<CampModel>> Get(string Moniker)
        {
            try
            {
                var results = await _campRepository.GetCampAsync(Moniker);
                if (results == null)
                {
                    return NotFound();
                }
                return _mapper.Map<CampModel>(results);
            }
            catch (Exception)
            {
                return StatusCode(500, "Database Failure");
            }
        }

        [HttpGet("search")]
        public async Task<ActionResult<CampModel[]>> SearchByDate(DateTime theDate, bool includeTalks = false)
        {
            try
            {
                var results = await _campRepository.GetAllCampsByEventDate(theDate, includeTalks);
                if (!results.Any())
                {
                    return NotFound();
                }
                return _mapper.Map<CampModel[]>(results);
            }
            catch (Exception)
            {
                return StatusCode(500, "Database Failure");
            }
        }
    }
}