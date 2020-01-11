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
        Task CreateAsync(Maksutapahtuma maksutapahtuma);
        
        Maksutapahtuma GetById(int id);

        IEnumerable<Maksutapahtuma> GetAll();

        decimal Ylityotunnit(decimal tehdytTunnit, decimal SaannollisetTunnit);

        decimal SaannolPalkka(decimal saannollisetTunnit, decimal tehdytTunnit, decimal tuntipalkka);

        decimal YlityoTuntipalkka(decimal tuntipalkka);

        decimal Ylityopalkka(decimal ylityoTuntipalkka, decimal ylityotunnit);

        decimal PalkkaYhteensa(decimal saannolPalkka, decimal ylityopalkka);

        decimal VahennyksetYhteensa(decimal vero, decimal tyoelakemaksu, decimal sotumaksu, decimal tyottomuusvakuutus, decimal jasenmaksu);

        decimal Nettopalkka(decimal palkkaYhteensa, decimal vahennyksetYhteensa);

    }
}
