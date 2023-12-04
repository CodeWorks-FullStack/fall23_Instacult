using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Instacult.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CultMembersController : ControllerBase
    {
        private readonly CultMembersService _cultMembersService;
        private readonly Auth0Provider _a0;

        public CultMembersController(CultMembersService cultMembersService, Auth0Provider a0)
        {
            _cultMembersService = cultMembersService;
            _a0 = a0;
        }


    }
}