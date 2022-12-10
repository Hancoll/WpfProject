using Ajito.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Ajito.ViewModels
{
    public class HomeViewModel
    {
        public ObservableCollection<Ad> Ads { get; set; }

        public HomeViewModel(IAdsService dataService)
        {
            Ads = new ObservableCollection<Ad>(dataService.GetAds());
        }
    }
}
