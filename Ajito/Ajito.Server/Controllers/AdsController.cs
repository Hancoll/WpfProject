using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ajito.Models;
using Ajito.Server.Data;

namespace Ajito.Server.Controllers
{
    public class AdsController
    {
        private AppDbContext context;

        public List<Ad> GetAds()
        {
            return context.Ads.ToList();
        }

        internal AdsController(AppDbContext context)
        {
            this.context = context;
        }
    }
}
