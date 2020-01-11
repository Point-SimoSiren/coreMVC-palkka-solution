using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Rendering;
using Palkkasovellus.Entity;
using Palkkasovellus.Persistence;

namespace Palkkasovellus.Services.Implementation
{
    public class LaskentaService : ILaskentaService
    {
        private decimal saannolPalkka;
        private decimal ylityotunnit;
        private readonly ApplicationDbContext _context;

        public LaskentaService(ApplicationDbContext context)
        {
            _context = context;
        }
        //Säännöllisen työajan palkka yhteensä
        public decimal SaannolPalkka(decimal saannollisetTunnit, decimal tehdytTunnit, decimal tuntipalkka)
        {
            if (tehdytTunnit < saannollisetTunnit)
            {
                saannolPalkka = tehdytTunnit * tuntipalkka;
            }
            else
            {
                saannolPalkka = saannollisetTunnit * tuntipalkka;
            }
            return saannolPalkka;
        }

        public async Task CreateAsync(Maksutapahtuma maksutapahtuma)
        {
            await _context.Maksutapahtumat.AddAsync(maksutapahtuma);
            await _context.SaveChangesAsync();
        }

        public IEnumerable<Maksutapahtuma> GetAll() => _context.Maksutapahtumat.OrderBy(mt => mt.HenkiloId);

        public Maksutapahtuma GetById(int id) =>
            _context.Maksutapahtumat.Where(maksu => maksu.Id == id).FirstOrDefault();


        public decimal Nettopalkka(decimal palkkaYhteensa, decimal vahennyksetYhteensa)
            => palkkaYhteensa - vahennyksetYhteensa;

        //-----Ylityöpalkat---------------------------------------------------------

        public decimal Ylityopalkka(decimal ylityoTuntipalkka, decimal ylityotunnit)
            => ylityotunnit * ylityoTuntipalkka;

        public decimal Ylityotunnit(decimal tehdytTunnit, decimal saannolTunnit)
        {
            if (tehdytTunnit <= saannolTunnit)
            {
                ylityotunnit = 0.00m;
            }
            else if (tehdytTunnit > saannolTunnit)
            {
                ylityotunnit = tehdytTunnit - saannolTunnit;
            }
            return ylityotunnit;
        }

        public decimal YlityoTuntipalkka(decimal tuntipalkka) => tuntipalkka * 1.5m;

        public decimal VahennyksetYhteensa(decimal vero, decimal tyoelakemaksu,
            decimal sotumaksu, decimal tyottomyysvakuutus, decimal jasenmaksu)
        => vero + tyoelakemaksu + sotumaksu + tyottomyysvakuutus + jasenmaksu;

        public decimal PalkkaYhteensa(decimal ylityopalkka, decimal saannolPalkka)
        => ylityopalkka + saannolPalkka;

    }
}