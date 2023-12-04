using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Instacult.Repositories
{
    public class CultMembersRepository
    {
        private readonly IDbConnection _db;

        public CultMembersRepository(IDbConnection db)
        {
            _db = db;
        }
    }
}