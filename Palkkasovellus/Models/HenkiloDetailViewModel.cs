using Palkkasovellus.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Palkkasovellus.Models
{
    public class HenkiloDetailViewModel
    {
        public int Id { get; set; }
        
        public string HenkiloNro { get; set; }

        public string Kokonimi { get; set; } // näytetään detail view modelissa vain koko nimi

        public string Sukupuoli { get; set; }

        public string KuvaUrl { get; set; }

        public DateTime SyntymaAika { get; set; }

        public DateTime AloitusPvm { get; set; }

        public string Tehtava { get; set; }

        public string Sahkoposti { get; set; }

        public string Puhelin { get; set; }
        
        public string SosTurvaTunnus { get; set; }

        public Maksutapa Maksutapa { get; set; }

        public LiitonJasen LiitonJasen { get; set; }
        
        public string Osoite { get; set; }
        
        public string Kaupunki { get; set; }
        
        public string Postinro { get; set; }
    }
}
