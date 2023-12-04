using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Instacult.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CultsController : ControllerBase
    {
        private readonly CultsService _cultsService;
        private readonly Auth0Provider _a0;

        public CultsController(CultsService cultsService, Auth0Provider a0)
        {
            _cultsService = cultsService;
            _a0 = a0;
        }

        [HttpGet]
        public ActionResult<List<Cult>> GetAllCults()
        {
            try
            {
                List<Cult> cults = _cultsService.GetAllCults();
                return Ok(cults);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPost]
        [Authorize]
        public async Task<ActionResult<Cult>> CreateCult([FromBody] Cult cultData)
        {
            try
            {
                Account userInfo = await _a0.GetUserInfoAsync<Account>(HttpContext);
                cultData.LeaderId = userInfo.Id;
                Cult cult = _cultsService.CreateCult(cultData);
                return Ok(cult);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpGet("{cultId}")]

        public ActionResult<Cult> GetCultById(int cultId)
        {
            try
            {
                Cult cult = _cultsService.GetCultById(cultId);
                return Ok(cult);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}