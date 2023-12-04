using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Instacult.Repositories
{
    public class CultsRepository
    {
        private readonly IDbConnection _db;

        public CultsRepository(IDbConnection db)
        {
            _db = db;
        }

        internal Cult CreateCult(Cult cultData)
        {
            string sql = @"
            INSERT INTO 
            cults(name, description, coverImg, fee, invitationRequired, leaderId)
            VALUES
            (@Name, @Description, @CoverImg, @Fee, @InvitationRequired, @LeaderId);

            SELECT
            cults.*,
            accounts.*
            FROM cults
            JOIN accounts ON cults.leaderId = accounts.id
            WHERE cults.id = LAST_INSERT_ID()
            ;";
            Cult cult = _db.Query<Cult, Profile, Cult>(sql, (cult, profile) =>
            {
                cult.Leader = profile;
                return cult;
            }, cultData).FirstOrDefault();
            return cult;
        }

        internal List<Cult> GetAllCults()
        {
            string sql = @"
            SELECT
            cults.*,
            accounts.*
            FROM cults
            JOIN accounts ON accounts.id = cults.leaderId
            ;";
            List<Cult> cults = _db.Query<Cult, Profile, Cult>(sql, (cult, profile) =>
           {
               cult.Leader = profile;
               return cult;
           }).ToList();
            return cults;
        }

        internal Cult GetCultById(int cultId)
        {
            string sql = @"
            SELECT
            cults.*,
            accounts.*
            FROM cults
            JOIN accounts ON accounts.id = cults.leaderId
            WHERE cults.id = @cultId
            ;";
            Cult cult = _db.Query<Cult, Profile, Cult>(sql, (cult, profile) =>
            {
                cult.Leader = profile;
                return cult;
            }, new { cultId }).FirstOrDefault();
            return cult;

        }

        internal Cult UpdateCult(Cult cultData)
        {
            string sql = @"
            UPDATE cults
            SET
            name = @Name,
            description = @Description,
            coverImg = @CoverImg,
            fee = @Fee,
            invitationRequired = @InvitationRequired,
            memberCount = @MemberCount
            WHERE id = @Id;

            SELECT 
            cults.*,
            accounts.*
            FROM cults
            JOIN accounts ON accounts.id = cults.leaderId
            WHERE cults.id = @Id
            ;";

            Cult cult = _db.Query<Cult, Profile, Cult>(sql, (cult, profile) =>
            {
                cult.Leader = profile;
                return cult;
            }, cultData).FirstOrDefault();
            return cult;
        }
    }
}