using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Palkkasovellus.Models;
using Palkkasovellus.Services;

namespace Palkkasovellus.Controllers
{
    public class HenkiloController : Controller
    {
        private readonly IHenkiloService _henkiloService;
        public HenkiloController(IHenkiloService henkiloService)
        {
            _henkiloService = henkiloService;
        }
        
        public IActionResult Index()
        {
            var henkilot = _henkiloService.GetAll().Select(henkilo => new HenkiloIndexViewModel
            {
                Id = henkilo.Id,
                HenkiloNro = henkilo.HenkiloNro,
                KuvaUrl = henkilo.KuvaUrl,
                Kokonimi = henkilo.Kokonimi,
                Sukupuoli = henkilo.Sukupuoli,
                Tehtava = henkilo.Tehtava,
                Kaupunki = henkilo.Kaupunki,
                AloitusPvm = henkilo.AloitusPvm
            }).ToList();
            return View(henkilot);
        }
    }
}
