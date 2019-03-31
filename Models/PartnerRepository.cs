using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FacturaOnline.Models
{
    public class PartnerRepository : IPartnerRepository
    {
        private readonly AppDbContext _appDbContext;

        public PartnerRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public IEnumerable<Partner> GetAllPartners()
        {
            return _appDbContext.Partners;
        }
    }
}
