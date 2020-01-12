using System;
using System.Collections.Generic;
using System.Text;

namespace Palkkasovellus.Services.Implementations
{
    public class ElakemaksuService : IElakemaksuService
    {
        private decimal elakemaksunMaara;
        public decimal ElakemaksunMaara(decimal kokonaisAnsio, decimal elakemaksuProsentti)
        {
            
            elakemaksunMaara = kokonaisAnsio * elakemaksuProsentti / 100;
            return elakemaksunMaara;
        }
    }
}
