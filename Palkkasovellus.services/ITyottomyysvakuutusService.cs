using System;
using System.Collections.Generic;
using System.Text;

namespace Palkkasovellus.Services
{
    public interface ITyottomyysvakuutusService
    {
        public decimal TyottomyysvakuutuksenMaara(decimal kokonaisAnsio,
            decimal tyottomuusvakuutusprosentti);
    }
}
