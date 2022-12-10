using Ajito.Server.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ajito.Models
{
    internal class LocalAdsService : IAdsService
    {
        private AdsController controller;

        public List<Ad> GetAds()
        {
            return controller.GetAds();
        }

        public LocalAdsService(AdsController controller)
        {
            this.controller = controller;
        }
    }
}
