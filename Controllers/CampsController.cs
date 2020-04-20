using CoreCodeCamp.Data;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace CoreCodeCamp.Controllers
{
    [Route("api/[controller]")]
    public class CampsController : ControllerBase
    {
        private readonly ICampRepository campRepository;

        public CampsController(ICampRepository campRepository)
        {
            this.campRepository = campRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetCamps()
        {
            try
            {
                var results = await campRepository.GetAllCampsAsync();
                return Ok(results);
            }
            catch (System.Exception)
            {
                return StatusCode(500, "Database Failure");
            }
        }
    }
}