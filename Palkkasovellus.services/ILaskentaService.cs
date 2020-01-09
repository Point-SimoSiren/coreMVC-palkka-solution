using Microsoft.AspNetCore.Mvc.Rendering;
using Palkkasovellus.Entity;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Palkkasovellus.Services
{
    public interface ILaskentaService
    {
        Task CreateAsync(Maksuhistoria maksuhistoria);
        
        Maksuhistoria GetById(int id); //Vastaa yhtä maksutapahtumaa

        IEnumerable<Maksuhistoria> GetAll();

        IEnumerable<SelectListItem> GetAllVerovuosi();

        decimal Ylityotunnit(decimal tuntimaara, decimal SaannollisetTunnit);

        decimal SaannolPalkka(decimal saannollisetTunnit, decimal tehdytTunnit, decimal tuntipalkka);

        decimal YlityoTuntipalkka(decimal tuntipalkka, decimal ylityotunnit);

        decimal YlityoPalkka(decimal ylityoTuntipalkka, decimal ylityotunnit);

        decimal PalkkaYhteensa(decimal saannolPalkka, decimal ylityoPalkka);

        decimal VahennyksetYhteensa(decimal ennakonpidatys, decimal tyoelakemaksu, decimal sosiaaliturvamaksu, decimal tyottomuusvakuutus, decimal jasenmaksu);

        decimal Nettopalkka(decimal palkkaYhteensa, decimal vahennyksetYhteensa);

        Verovuosi GetVerovuosiById(int verovuosiId);
        decimal YlityoTuntipalkka(decimal tuntipalkka);
    }
}
