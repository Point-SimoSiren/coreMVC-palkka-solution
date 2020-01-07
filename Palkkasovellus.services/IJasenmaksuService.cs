using System;
using System.Collections.Generic;
using System.Text;

namespace Palkkasovellus.Services
{
    interface IJasenmaksuService
    {
        public decimal Jasenmaksu(decimal kokonaisAnsio, decimal jasenmaksuProsentti);
    
    }
}
