using System;
using System.Collections.Generic;
using System.Text;

namespace Palkkasovellus.Services
{
    public interface IJasenmaksuService
    {
        public decimal Jasenmaksu(decimal kokonaisAnsio, decimal jasenmaksuProsentti);
    
    }
}
