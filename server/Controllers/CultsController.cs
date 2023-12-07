namespace Instacult.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CultsController : ControllerBase
    {
        private readonly CultsService _cultsService;
        private readonly CultMembersService _cultMembersService;
        private readonly Auth0Provider _a0;

        public CultsController(CultsService cultsService, Auth0Provider a0, CultMembersService cultMembersService)
        {
            _cultsService = cultsService;
            _a0 = a0;
            _cultMembersService = cultMembersService;
        }

        [HttpGet]
        public async Task<ActionResult<List<Cult>>> GetAllCults(string query)
        {
            try
            {
                Account userInfo = await _a0.GetUserInfoAsync<Account>(HttpContext);
                List<Cult> cults = _cultsService.GetAllCults(userInfo?.Id, query);
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

        [HttpGet("{cultId}/cultMembers")]
        public ActionResult<List<Cultist>> GetCultist(int cultId)
        {
            try
            {
                List<Cultist> cultists = _cultMembersService.GetCultist(cultId);
                return Ok(cultists);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}