using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ajito.Models
{
    public interface IAdsService
    {
        List<Ad> GetAds();
    }
}
