using System;
using System.Collections.Generic;
using System.Text;

namespace Palkkasovellus.Services
{
    interface ISotumaksuService
    {
        decimal SotumaksunMaara(decimal kokonaisAnsio, decimal sotumaksuProsentti);
    }
}