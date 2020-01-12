using System;
using System.Collections.Generic;
using System.Text;

namespace Palkkasovellus.Services.Implementations
{
    public class JasenmaksuService : IJasenmaksuService
    {
        private decimal jasenmaksu;
        public decimal Jasenmaksu(decimal kokonaisAnsio, decimal jasenmaksuProsentti)
        {
            jasenmaksu = kokonaisAnsio * jasenmaksuProsentti / 100;
            return jasenmaksu;
        }
    }
}
