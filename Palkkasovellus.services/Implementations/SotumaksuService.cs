using System;
using System.Collections.Generic;
using System.Text;

namespace Palkkasovellus.Services.Implementations
{
    class SotumaksuService : ISotumaksuService
    {
        private decimal sotumaksunMaara;
        public decimal SotumaksunMaara(decimal kokonaisAnsio, decimal sotumaksuProsentti)
        {
            sotumaksunMaara = kokonaisAnsio * sotumaksuProsentti / 100;
            return sotumaksunMaara;
        }
    }
}
