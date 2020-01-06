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
        public decimal Saannolpalkka(decimal saannollisetTunnit, decimal tehdytTunnit, decimal tuntipalkka)
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

        //Yksittäinen tapahtuma lisätään monikolliseen maksuhistoriat kokoelmaan
        public async Task CreateAsync(Maksuhistoria maksuhistoria)
        {
            await _context.Maksuhistoriat.AddAsync(maksuhistoria);
            await _context.SaveChangesAsync();
        }

        public IEnumerable<Maksuhistoria> GetAll() => _context.Maksuhistoriat.OrderBy(mh => mh.HenkiloId);


        public IEnumerable<SelectListItem> GetAllVerovuosi()
        {
            //verov edustaa monikollista verovuosien kokoelmaa. Nimi voisi olla ennemmin verovuodet.
            var AllVerovuosi = _context.Verov.Select(verov => new SelectListItem 
            {
                Text = verov.Verotusvuosi,
                Value = verov.Id.ToString()
            });
            return AllVerovuosi;
        }

        //Yksittäisen maksutpahtuman haku ID:llä
        public Maksuhistoria GetById(int id) =>
            _context.Maksuhistoriat.Where(maksu => maksu.Id == id).FirstOrDefault();


        public decimal Nettopalkka(decimal palkkaYhteensa, decimal vahennyksetYhteensa)
            => palkkaYhteensa - vahennyksetYhteensa;


        public decimal YlityoPalkka(decimal ylityoTuntipalkka, decimal ylityotunnit)
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

        public decimal VahennyksetYhteensa(decimal ennakonpidatys, decimal tyoelakemaksu,
            decimal sosiaaliturvamaksu, decimal tyottomyysvakuutus, decimal jasenmaksu)
        => ennakonpidatys + tyoelakemaksu + sosiaaliturvamaksu + tyottomyysvakuutus + jasenmaksu;

        public decimal PalkkaYhteensa(decimal ylityoPalkka, decimal saannolPalkka)
        => ylityoPalkka + saannolPalkka;

        public Verovuosi GetVerovuosiById(int id)
        => _context.Verov.Where(vuosi => vuosi.Id == id).FirstOrDefault();

        public decimal SaannolPalkka(decimal saannollisetTunnit, decimal tehdytTunnit, decimal tuntipalkka)
        {
            throw new NotImplementedException();
        }

        public decimal YlityoTuntipalkka(decimal tuntipalkka, decimal ylityotunnit)
        {
            throw new NotImplementedException();
        }
    }
}