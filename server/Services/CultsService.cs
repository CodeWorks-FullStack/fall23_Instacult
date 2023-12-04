using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Instacult.Services
{
    public class CultsService
    {
        private readonly CultsRepository _cultsRepo;

        public CultsService(CultsRepository cultsRepo)
        {
            _cultsRepo = cultsRepo;
        }

        internal Cult CreateCult(Cult cultData)
        {
            Cult cult = _cultsRepo.CreateCult(cultData);
            return cult;
        }

        internal List<Cult> GetAllCults()
        {
            List<Cult> cults = _cultsRepo.GetAllCults();
            return cults;
        }

        internal Cult GetCultById(int cultId)
        {
            Cult cult = _cultsRepo.GetCultById(cultId);
            if (cult == null)
            {
                throw new Exception($"There was not a cult at [ID] {cultId}");
            }
            return cult;
        }
    }
}