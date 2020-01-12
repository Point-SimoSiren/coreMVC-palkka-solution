using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Palkkasovellus.Entity;
using Palkkasovellus.Models;
using Palkkasovellus.Services;
//using Rotativa.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace Palkkasovellus.Controllers
{
    //[Authorize(Roles = "Admin,Manager")]
    public class MaksuController : Controller
    {
        private readonly ILaskentaService _laskentaService;
        private readonly IHenkiloService _henkiloService;
        private readonly IVeroService _veroService;
        private readonly IElakemaksuService _elakemaksuService;

        private readonly ISotumaksuService _sotumaksuService;
        private readonly ITyottomyysvakuutusService _tyottomyysvakuutusService;
        private readonly IJasenmaksuService _jasenmaksuService;

        private decimal ylityotunnit;
        private decimal saannollinenPalkka;
        private decimal ylityopalkka;
        private decimal palkkaYhteensa;

        private decimal vero;
        private decimal elakemaksu;
        private decimal jasenmaksu;
        private decimal sotumaksu;
        private decimal tyottomyysvakuutus;
        private decimal vahennyksetYhteensa;

        private decimal veroprosentti;
        private decimal elakemaksuprosentti;
        private decimal sotumaksuprosentti;
        private decimal tyottomyysvakuutusprosentti;
        private decimal jasenmaksuprosentti;

        public MaksuController(ILaskentaService laskentaService,
                            IHenkiloService henkiloService,
                            IVeroService veroService,
                            IElakemaksuService elakemaksuService,
                            ISotumaksuService sotumaksuService,
                            ITyottomyysvakuutusService tyottomyysvakuutusService,
                            IJasenmaksuService jasenmaksuService
                            )
        {
            _laskentaService = laskentaService;
            _henkiloService = henkiloService;
            _veroService = veroService;
            _elakemaksuService = elakemaksuService;
            _sotumaksuService = sotumaksuService;
            _tyottomyysvakuutusService = tyottomyysvakuutusService;
            _jasenmaksuService = jasenmaksuService;
        }

        public IActionResult Index()
        {
            //Select metodia käytetään suojaamaan viewModelit
            var maksutapahtuma = _laskentaService.GetAll().Select(maksu => new MaksuIndexViewModel
            {
                Id = maksu.Id,
                HenkiloId = maksu.HenkiloId,
                Kokonimi = maksu.Kokonimi,
                Maksupaiva = maksu.Maksupaiva,
                Maksukuukausi = maksu.Maksukuukausi,
                PalkkaYhteensa = maksu.PalkkaYhteensa,
                VahennuksetYhteensa = maksu.VahennyksetYhteensa,
                Nettopalkka = maksu.Nettopalkka,
                Henkilo = maksu.Henkilo
            });
            return View(maksutapahtuma);
        }

        //[Authorize(Roles = "Admin")]
        public IActionResult Create()
        {
            ViewBag.henkilot = _henkiloService.GetAllHenkilotPalkkatietoihin();
            var model = new MaksuCreateViewModel();
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        // [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Create(MaksuCreateViewModel model)
        {
            if (ModelState.IsValid)
            {
                var maksutapahtuma = new Maksutapahtuma()
                {
                    Id = model.Id,
                    HenkiloId = model.HenkiloId,
                    Kokonimi = _henkiloService.GetById(model.HenkiloId).Kokonimi,

                    Sotu = _henkiloService.GetById(model.HenkiloId).SosTurvaTunnus,
                    Maksupaiva = model.Maksupaiva,
                    Maksukuukausi = model.Maksukuukausi,
                    Veronumero = model.Veronumero,
                    Veroprosentti = model.Veroprosentti,
                    Lisaprosentti = model.Lisaprosentti,
                    Tuloraja = model.Tuloraja,
                    Elakemaksuprosentti = model.Elakemaksuprosentti,
                    Tyottomyysvakuutusprosentti = model.Tyottomyysvakuutusprosentti,
                    Sotumaksuprosentti = model.Sotumaksuprosentti,
                    Jasenmaksuprosentti = model.Jasenmaksuprosentti,
                    Tuntipalkka = model.Tuntipalkka,
                    Tuntimaara = model.TehdytTunnit,
                    SaannollisetTunnit = model.SaannollisetTunnit,

                    Ylityotunnit = ylityotunnit = _laskentaService.Ylityotunnit(model.TehdytTunnit, model.SaannollisetTunnit),

                    SaannolPalkka = saannollinenPalkka = _laskentaService.SaannolPalkka(model.SaannollisetTunnit, model.TehdytTunnit, model.Tuntipalkka),

                    Ylityopalkka = ylityopalkka = _laskentaService.Ylityotunnit(_laskentaService.YlityoTuntipalkka(model.Tuntipalkka), model.Ylityotunnit),

                    PalkkaYhteensa = palkkaYhteensa  = _laskentaService.PalkkaYhteensa(ylityopalkka, saannollinenPalkka),

                    VeronMaara = vero = _veroService.VeronMaara(model.PalkkaYhteensa, model.Tuloraja, model.Lisaprosentti, model.Veroprosentti),

                    Jasenmaksu = jasenmaksu = _jasenmaksuService.Jasenmaksu(model.PalkkaYhteensa, model.Jasenmaksuprosentti),

                    Elakemaksu = elakemaksu = _elakemaksuService.ElakemaksunMaara(model.PalkkaYhteensa, model.Elakemaksuprosentti),

                    Tyottomyysvakuutus = tyottomyysvakuutus = _tyottomyysvakuutusService.TyottomyysvakuutuksenMaara(model.PalkkaYhteensa, model.Tyottomyysvakuutusprosentti),

                    Sosiaaliturvamaksu = sotumaksu = _sotumaksuService.SotumaksunMaara(model.PalkkaYhteensa, model.Sotumaksuprosentti),

                    VahennyksetYhteensa = vahennyksetYhteensa = _laskentaService.VahennyksetYhteensa(vero, sotumaksu, elakemaksu, tyottomyysvakuutus, jasenmaksu),

                    Nettopalkka = _laskentaService.Nettopalkka(palkkaYhteensa, vahennyksetYhteensa)
                };
                await _laskentaService.CreateAsync(maksutapahtuma);
                return RedirectToAction(nameof(Index));
            }
            ViewBag.henkilot = _henkiloService.GetAllHenkilotPalkkatietoihin();
            return View();
        }

        public IActionResult Detail(int id)
        {
            var maksutapahtuma = _laskentaService.GetById(id);
            if (maksutapahtuma == null)
            {
                return NotFound();
            }

            var model = new MaksuDetailViewModel()
            {
                Id = maksutapahtuma.Id,
                HenkiloId = maksutapahtuma.HenkiloId,
                Kokonimi = maksutapahtuma.Kokonimi,
                Sotu = maksutapahtuma.Sotu,
                Maksupaiva = maksutapahtuma.Maksupaiva,
                Maksukuukausi = maksutapahtuma.Maksukuukausi,
                Veronumero = maksutapahtuma.Veronumero,
                Tuntipalkka = maksutapahtuma.Tuntipalkka,
                TehdytTunnit = maksutapahtuma.Tuntimaara,
                SaannolTunnit = maksutapahtuma.SaannollisetTunnit,
                Ylityotunnit = maksutapahtuma.Ylityotunnit,
                YlityoTuntipalkka = _laskentaService.YlityoTuntipalkka(maksutapahtuma.Tuntipalkka),
                SaannolPalkka = maksutapahtuma.SaannolPalkka,
                Ylityopalkka = maksutapahtuma.Ylityopalkka,
                Vero = maksutapahtuma.Vero,
                Sotumaksu = maksutapahtuma.Sosiaaliturvamaksu,
                Jasenmaksu = maksutapahtuma.Jasenmaksu,
                Elakemaksu = maksutapahtuma.Elakemaksu,
                Tyottomyysvakuutus= maksutapahtuma.Tyottomyysvakuutus,
                PalkkaYhteensa = maksutapahtuma.PalkkaYhteensa,
                VahennuksetYhteensa = maksutapahtuma.VahennyksetYhteensa,
                Henkilo = maksutapahtuma.Henkilo,
                Nettopalkka = maksutapahtuma.Nettopalkka
            };
            return View(model);
        }

        [HttpGet]
        [AllowAnonymous]
        public IActionResult Palkkatosite(int id)
        {
            var maksutapahtuma = _laskentaService.GetById(id);
            if (maksutapahtuma == null)
            {
                return NotFound();
            }

            var model = new MaksuDetailViewModel()
            {
                Id = maksutapahtuma.Id,
                HenkiloId = maksutapahtuma.HenkiloId,
                Kokonimi = maksutapahtuma.Kokonimi,
                Sotu = maksutapahtuma.Sotu,
                Maksupaiva = maksutapahtuma.Maksupaiva,
                Maksukuukausi = maksutapahtuma.Maksukuukausi,
                Veronumero = maksutapahtuma.Veronumero,
                Tuntipalkka = maksutapahtuma.Tuntipalkka,
                TehdytTunnit = maksutapahtuma.Tuntimaara,
                SaannolTunnit = maksutapahtuma.SaannollisetTunnit,
                Ylityotunnit = maksutapahtuma.Ylityotunnit,
                YlityoTuntipalkka = _laskentaService.YlityoTuntipalkka(maksutapahtuma.Tuntipalkka),
                SaannolPalkka = maksutapahtuma.SaannolPalkka,
                Ylityopalkka = maksutapahtuma.Ylityopalkka,
                Vero = maksutapahtuma.Vero,
                Sotumaksu = maksutapahtuma.Sosiaaliturvamaksu,
                Jasenmaksu = maksutapahtuma.Jasenmaksu,
                Elakemaksu = maksutapahtuma.Elakemaksu,
                Tyottomyysvakuutus = maksutapahtuma.Tyottomyysvakuutus,
                PalkkaYhteensa = maksutapahtuma.PalkkaYhteensa,
                VahennuksetYhteensa = maksutapahtuma.VahennyksetYhteensa,
                Henkilo = maksutapahtuma.Henkilo,
                Nettopalkka = maksutapahtuma.Nettopalkka
            };

            return View(model);

            // return new ViewAsPdf("Payslip", model);
        }

        /* public IActionResult GeneratePayslipPdf(int id)
         {
             var payslip = new ActionAsPdf("Payslip", new { id = id })
             {
                 FileName = "payslip.pdf"
             };
             return payslip;
         }*/
    }
}
