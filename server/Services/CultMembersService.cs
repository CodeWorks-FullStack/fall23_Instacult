using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Instacult.Services
{
    public class CultMembersService
    {
        private readonly CultMembersRepository _cultMembersRepo;

        public CultMembersService(CultMembersRepository cultMembersRepo)
        {
            _cultMembersRepo = cultMembersRepo;
        }
    }
}