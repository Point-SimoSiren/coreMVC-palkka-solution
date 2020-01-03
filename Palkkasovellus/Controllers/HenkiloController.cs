using System;
using System.IO;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting.Internal;
using Palkkasovellus.Entity;
using Palkkasovellus.Models;
using Palkkasovellus.Services;
using System.Threading.Tasks;

namespace Palkkasovellus.Controllers
{
    public class HenkiloController : Controller
    {
        private readonly IHenkiloService _henkiloService;
        private readonly HostingEnvironment _hostingEnvironment;
        public HenkiloController(IHenkiloService henkiloService, HostingEnvironment hostingEnvironment)
        {
            _henkiloService = henkiloService;
            _hostingEnvironment = hostingEnvironment;
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

        [HttpGet]
        public IActionResult Create()
        {
            var model = new HenkiloCreateViewModel();
            return View(model);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(HenkiloCreateViewModel model)
        {
            if (ModelState.IsValid)
            {
                var henkilo = new Henkilo
                {
                    Id = model.Id,
                    HenkiloNro = model.HenkiloNro,
                    Etunimi = model.Etunimi,
                    ToinenNimi = model.ToinenNimi,
                    Sukunimi = model.Sukunimi,
                    Kokonimi = model.Kokonimi,
                    Sukupuoli = model.Sukupuoli,
                    Sahkoposti = model.Sahkoposti,
                    Puhelin = model.Puhelin,
                    SyntymaAika = model.SyntymaAika,
                    AloitusPvm = model.AloitusPvm,
                    SosTurvaTunnus = model.SosTurvaTunnus,
                    Tehtava = model.Tehtava,
                    Maksutapa = model.Maksutapa,
                    LiitonJasen = model.LiitonJasen,
                    Osoite = model.Osoite,
                    Kaupunki = model.Kaupunki,
                    Postinro = model.Postinro

                };

                if (model.KuvaUrl != null && model.KuvaUrl.Length > 0)
                {
                    var uploadDir = @"kuvat/henkilo";
                    var fileName = Path.GetFileNameWithoutExtension(model.KuvaUrl.FileName);
                    var extension = Path.GetExtension(model.KuvaUrl.FileName);

                    //Esim. oli _hostingEnvironment.WebRootPath, mutta antaa herjan minulla.
                    var webRootPath = _hostingEnvironment.ContentRootPath;

                    fileName = DateTime.Now.ToString("yymmssfff") + fileName + extension;
                    var path = Path.Combine(webRootPath, uploadDir, fileName);
                    await model.KuvaUrl.CopyToAsync(new FileStream(path, FileMode.Create));
                    henkilo.KuvaUrl = "/" + uploadDir + "/" + fileName;
                }
                await _henkiloService.CreateAsync(henkilo);
                return RedirectToAction(nameof(Index));
            }
            return View();
        }

        //get on oletuksena. Tehtävä on hakea tämä ja välittää view modelille alempana (post)
        public IActionResult Edit(int id)
        {
            var henkilo = _henkiloService.GetById(id);
            if (henkilo == null)
            {
                return NotFound();
            }
            var model = new HenkiloEditViewModel()
            {
                Id = henkilo.Id,
                HenkiloNro = henkilo.HenkiloNro,
                Etunimi = henkilo.Etunimi,
                ToinenNimi = henkilo.ToinenNimi,
                Sukunimi = henkilo.Sukunimi,
                Sukupuoli = henkilo.Sukupuoli,
                Sahkoposti = henkilo.Sahkoposti,
                Puhelin = henkilo.Puhelin,
                SyntymaAika = henkilo.SyntymaAika,
                AloitusPvm = henkilo.AloitusPvm,
                SosTurvaTunnus = henkilo.SosTurvaTunnus,
                Tehtava = henkilo.Tehtava,
                Maksutapa = henkilo.Maksutapa,
                LiitonJasen = henkilo.LiitonJasen,
                Osoite = henkilo.Osoite,
                Kaupunki = henkilo.Kaupunki,
                Postinro = henkilo.Postinro
            };
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(HenkiloEditViewModel model)
        {
            if (ModelState.IsValid)
            {
                var henkilo = _henkiloService.GetById(model.Id);
                if (henkilo == null)
                {
                    return NotFound();
                }
                henkilo.HenkiloNro = model.HenkiloNro;
                henkilo.Etunimi = model.Etunimi;
                henkilo.ToinenNimi = model.ToinenNimi;
                henkilo.Sukunimi = model.Sukunimi;
                henkilo.SosTurvaTunnus = model.SosTurvaTunnus;
                henkilo.Sukupuoli = model.Sukupuoli;
                henkilo.Sahkoposti = model.Sahkoposti;
                henkilo.SyntymaAika = model.SyntymaAika;
                henkilo.AloitusPvm = model.AloitusPvm;
                henkilo.Puhelin = model.Puhelin;
                henkilo.Tehtava = model.Tehtava;
                henkilo.Maksutapa = model.Maksutapa;
                henkilo.LiitonJasen = model.LiitonJasen;
                henkilo.Osoite = model.Osoite;
                henkilo.Kaupunki = model.Kaupunki;
                henkilo.Postinro = model.Postinro;
                if (model.KuvaUrl != null && model.KuvaUrl.Length > 0)
                {
                    var uploadDir = @"kuvat/henkilo";
                    var fileName = Path.GetFileNameWithoutExtension(model.KuvaUrl.FileName);
                    var extension = Path.GetExtension(model.KuvaUrl.FileName);
                    var webRootPath = _hostingEnvironment.ContentRootPath;
                    fileName = DateTime.Now.ToString("yymmssfff") + fileName + extension;
                    var path = Path.Combine(webRootPath, uploadDir, fileName);
                    await model.KuvaUrl.CopyToAsync(new FileStream(path, FileMode.Create));
                    henkilo.KuvaUrl = "/" + uploadDir + "/" + fileName;
                }
                await _henkiloService.UpdateAsync(henkilo);
                return RedirectToAction(nameof(Index));
            }
            return View();
        }
    }
}
