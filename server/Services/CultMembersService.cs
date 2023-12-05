using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Instacult.Services
{
    public class CultMembersService
    {
        private readonly CultMembersRepository _cultMembersRepo;
        private readonly CultsService _cultsService;

        public CultMembersService(CultMembersRepository cultMembersRepo, CultsService cultsService)
        {
            _cultMembersRepo = cultMembersRepo;
            _cultsService = cultsService;
        }

        internal Cultist JoinCult(CultMember cultMemberData)
        {

            Cultist cultMember = _cultMembersRepo.JoinCult(cultMemberData);
            Cult cult = _cultsService.GetCultById(cultMember.CultId);
            cult.MemberCount++;
            _cultsService.UpdateMemberCount(cult);
            return cultMember;
        }

        internal CultMember GetById(int cultMemberId)
        {
            CultMember cultMember = _cultMembersRepo.GetById(cultMemberId);
            if (cultMember == null)
            {
                throw new Exception($"No Cult Member at ID {cultMemberId}");
            }
            return cultMember;
        }

        internal string LeaveCult(int cultMemberId, string userId)
        {
            CultMember cultMember = GetById(cultMemberId);
            Cult cult = _cultsService.GetCultById(cultMember.CultId);
            if (cultMember.AccountId != userId)
            {
                throw new Exception("Stay a little longer....");
            }
            _cultMembersRepo.LeaveCult(cultMemberId);
            cult.MemberCount--;
            _cultsService.UpdateMemberCount(cult);
            return "You might be free, we'll see about that!";
        }

        internal List<Cultist> GetCultist(int cultId)
        {
            Cult cult = _cultsService.GetCultById(cultId);
            List<Cultist> cultists = _cultMembersRepo.GetCultist(cultId);
            return cultists;
        }
    }
}