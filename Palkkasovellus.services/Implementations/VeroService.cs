using System;
using System.Collections.Generic;
using System.Text;

namespace Palkkasovellus.Services.Implementations
{
    public class VeroService : IVeroService
    {
        private decimal veronMaara1;
        private decimal veronMaara2;

        public decimal VeronMaara(decimal KokonaisAnsio, decimal Veroprosentti,
            decimal Tuloraja, decimal LisaProsentti)
        {
            if (KokonaisAnsio <= Tuloraja)
            {
                veronMaara1 = (KokonaisAnsio * Veroprosentti / 100);
                return veronMaara1;
            }
            else
            {
                veronMaara1 = (Tuloraja * Veroprosentti / 100);
                veronMaara2 = ((KokonaisAnsio - Tuloraja) * LisaProsentti / 100);
                return veronMaara1 + veronMaara2;
            }
        }
        
    }
}
