using System;
using System.Collections.Generic;
using System.Text;

namespace Palkkasovellus.Services
{
    interface ITyottomuusvakuutusService
    {
        public decimal TyottomuusvakuutuksenMaara(decimal kokonaisAnsio,
            decimal tyottomuusvakuutusProsentti);
    }
}
