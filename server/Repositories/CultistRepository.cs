

namespace Instacult.Repositories
{
    public class CultistRepository
    {
        private readonly IDbConnection _db;

        public CultistRepository(IDbConnection db)
        {
            _db = db;
        }

        internal List<Cultist> GetCultist(int cultId)
        {
            string sql = @"
            SELECT
            cultMembers.*,
            accounts.*
            FROM cultMembers
            JOIN accounts ON cultMembers.accountId = accounts.id
            WHERE cultMembers.cultId = @cultId
            ;";
            List<Cultist> cultists = _db.Query<CultMember, Cultist, Cultist>(sql, (cultMember, cultist) =>
            {
                cultist.CultMemberId = cultMember.Id;
                cultist.CultId = cultMember.CultId;
                return cultist;
            }, new { cultId }).ToList();
            return cultists;
        }
    }
}