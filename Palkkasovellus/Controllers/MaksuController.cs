using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Palkkasovellus.Entity;
using Palkkasovellus.Models;
using Palkkasovellus.Services;
//using RotativaCore;
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
        private readonly ITyottomuusvakuutusService _tyottomuusvakuutusService;
        private readonly IJasenmaksuService _jasenmaksuService;

        private decimal ylityotunnit;
        private decimal saannollinenPalkka;
        private decimal ylityoPalkka;
        private decimal kokonaisAnsio;
        private decimal vero;
        private decimal elakemaksu;
        private decimal jasenmaksu;
        private decimal sotumaksu;
        private decimal tyottomyysvakuutus;
        private decimal vahennyksetYhteensa;

        public MaksuController(ILaskentaService laskentaService,
                            IHenkiloService henkiloService,
                            IVeroService veroService,
                            IElakemaksuService elakemaksuService,
                            ISotumaksuService sotumaksuService,
                            ITyottomuusvakuutusService tyottomuusvakuutus,
                            IJasenmaksuService jasenmaksu
                            )
        {
            _laskentaService = laskentaService;
            _henkiloService = henkiloService;
            _veroService = veroService;
            _elakemaksuService = elakemaksuService;
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
                VerovuosiId = maksu.VerovuosiId,
                Vuosi = _laskentaService.GetVerovuosiById(maksu.VerovuosiId).Verotusvuosi,
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
            ViewBag.veroVuosi = _laskentaService.GetAllVerovuosi();
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
                var maksutapahtuma = new Maksuhistoria()
                {
                    Id = model.Id,
                    HenkiloId = model.HenkiloId,
                    Kokonimi = _henkiloService.GetById(model.HenkiloId).Kokonimi,
                    Sotu = _henkiloService.GetById(model.HenkiloId).SosTurvaTunnus,
                    Maksupaiva = model.Maksupaiva,
                    Maksukuukausi = model.Maksukuukausi,
                    VerovuosiId = model.VerovuosiId,
                    Veronumero = model.Veronumero,
                    Tuntipalkka = model.Tuntipalkka,
                    Tuntimaara = model.TehdytTunnit,
                    SaannollisetTunnit = model.SaannollisetTunnit,
                    Ylityotunnit = ylityotunnit = _laskentaService.Ylityotunnit(model.TehdytTunnit, model.SaannollisetTunnit),
                    SaannolPalkka = saannollinenPalkka = _laskentaService.SaannolPalkka(model.SaannollisetTunnit, model.TehdytTunnit, model.Tuntipalkka),
                    YlityoPalkka = ylityoPalkka = _laskentaService.Ylityotunnit(_laskentaService.YlityoTuntipalkka(model.Tuntipalkka), ylityotunnit),
                    PalkkaYhteensa = kokonaisAnsio = _laskentaService.PalkkaYhteensa(ylityoPalkka, saannollinenPalkka),
                   // VeronMaara = vero = _veroService.VeronMaara(kokonaisAnsio, Tuloraja, LisaProsentti, YlityoProsentti),
                    Jasenmaksu = jasenmaksu = _henkiloService.Jasenmaksut(model.HenkiloId),
                    //Tyoelakemaksu = elakemaksu = _henkiloService.ElakemaksunMaara(model.HenkiloId, kokonaisAnsio),
                    //Sosiaaliturvamaksu = sotumaksu = _sotumaksuService.SotumaksunMaara(kokonaisAnsio, sotumaksuProsentti),
                    VahennyksetYhteensa = vahennyksetYhteensa = _laskentaService.VahennyksetYhteensa(vero, sotumaksu, elakemaksu, tyottomyysvakuutus, jasenmaksu),
                    Nettopalkka = _laskentaService.Nettopalkka(kokonaisAnsio, vahennyksetYhteensa)
                };
                await _laskentaService.CreateAsync(maksutapahtuma);
                return RedirectToAction(nameof(Index));
            }
            ViewBag.henkilot = _henkiloService.GetAllHenkilotPalkkatietoihin();
            ViewBag.verov = _laskentaService.GetAllVerovuosi();
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
                EmployeeId = maksutapahtuma.HenkiloId,
                FullName = maksutapahtuma.Kokonimi,
                Sotumaksu = maksutapahtuma.Sosiaaliturvamaksu,
                PayDate = paymentRecord.PayDate,
                PayMonth = paymentRecord.PayMonth,
                TaxYearId = paymentRecord.TaxYearId,
                Year = _payComputationService.GetTaxYearById(paymentRecord.TaxYearId).YearOfTax,
                TaxCode = paymentRecord.TaxCode,
                HourlyRate = paymentRecord.HourlyRate,
                HoursWorked = paymentRecord.HoursWorked,
                ContractualHours = paymentRecord.ContractualHours,
                OvertimeHours = paymentRecord.OvertimeHours,
                OvertimeRate = _payComputationService.OvertimeRate(paymentRecord.HourlyRate),
                ContractualEarnings = paymentRecord.ContractualEarnings,
                OvertimeEarnings = paymentRecord.OvertimeEarnings,
                Tax = paymentRecord.Tax,
                NIC = paymentRecord.NIC,
                UnionFee = paymentRecord.UnionFee,
                SLC = paymentRecord.SLC,
                TotalEarnings = paymentRecord.TotalEarnings,
                TotalDeduction = paymentRecord.TotalDeduction,
                Employee = paymentRecord.Employee,
                TaxYear = paymentRecord.TaxYear,
                NetPayment = paymentRecord.NetPayment
            };
            return View(model);
        }

        [HttpGet]
        [AllowAnonymous]
        public IActionResult Payslip(int id)
        {
            var paymentRecord = _payComputationService.GetById(id);
            if (paymentRecord == null)
            {
                return NotFound();
            }

            var model = new PaymentRecordDetailViewModel()
            {
                Id = paymentRecord.Id,
                EmployeeId = paymentRecord.EmployeeId,
                FullName = paymentRecord.FullName,
                NiNo = paymentRecord.NiNo,
                PayDate = paymentRecord.PayDate,
                PayMonth = paymentRecord.PayMonth,
                TaxYearId = paymentRecord.TaxYearId,
                Year = _payComputationService.GetTaxYearById(paymentRecord.TaxYearId).YearOfTax,
                TaxCode = paymentRecord.TaxCode,
                HourlyRate = paymentRecord.HourlyRate,
                HoursWorked = paymentRecord.HoursWorked,
                ContractualHours = paymentRecord.ContractualHours,
                OvertimeHours = paymentRecord.OvertimeHours,
                OvertimeRate = _payComputationService.OvertimeRate(paymentRecord.HourlyRate),
                ContractualEarnings = paymentRecord.ContractualEarnings,
                OvertimeEarnings = paymentRecord.OvertimeEarnings,
                Tax = paymentRecord.Tax,
                NIC = paymentRecord.NIC,
                UnionFee = paymentRecord.UnionFee,
                SLC = paymentRecord.SLC,
                TotalEarnings = paymentRecord.TotalEarnings,
                TotalDeduction = paymentRecord.TotalDeduction,
                Employee = paymentRecord.Employee,
                TaxYear = paymentRecord.TaxYear,
                NetPayment = paymentRecord.NetPayment
            };
            //return View(model);
            //return new ViewAsPdf("Payslip", model);
        }

        //public IActionResult GeneratePayslipPdf(int id)
        //{
        //    var payslip = new ActionAsPdf("Payslip", new { id = id })
        //    {
        //        FileName = "payslip.pdf"
        //    };
        //    return payslip;
        //}
    }
}