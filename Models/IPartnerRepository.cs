using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FacturaOnline.Models
{
    public interface IPartnerRepository
    {
        IEnumerable<Partner> GetAllPartners();

    }
}
