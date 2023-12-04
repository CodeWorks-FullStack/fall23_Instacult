
namespace Instacult.Services
{
    public class CultistService
    {
        private readonly CultistRepository _cultistRepo;
        private readonly CultsService _cultsService;

        public CultistService(CultistRepository cultistRepo, CultsService cultsService)
        {
            _cultistRepo = cultistRepo;
            _cultsService = cultsService;
        }

        internal List<Cultist> GetCultist(int cultId)
        {
            Cult cult = _cultsService.GetCultById(cultId);
            List<Cultist> cultists = _cultistRepo.GetCultist(cultId);
            return cultists;
        }
    }
}