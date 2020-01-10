using Palkkasovellus.Entity;
using System;
using System.ComponentModel.DataAnnotations;

namespace Palkkasovellus.Models
{
    public class MaksuCreateViewModel
    {
        public int Id { get; set; }

        [Display(Name = "Nimi")]
        public int HenkiloId { get; set; }

        public Henkilo Henkilo { get; set; }

        public string Kokonimi { get; set; }

        public string Sotu { get; set; }

        [DataType(DataType.Date), Display(Name = "Maksupäivä")]
        public DateTime Maksupaiva { get; set; } = DateTime.UtcNow;

        public string Maksukuukausi { get; set; } = DateTime.Today.Month.ToString();

        [Display(Name = "Verovuosi")]
        public int VerovuosiId { get; set; }

        public Verovuosi Verovuosi { get; set; }

        public string Veronumero { get; set; } = "V13548";
        
        public decimal Tuntipalkka { get; set; }

        [Display(Name = "Tehdyt työtunnit")]
        public decimal TehdytTunnit { get; set; }
        
        public decimal SaannollisetTunnit { get; set; } = 144m;

        public decimal Ylityotunnit { get; set; }

        [Display(Name = "Säännöllisen ta palkka")]
        public decimal SaannolPalkka { get; set; }

        [Display(Name = "Ylityöpalkka")]
        public decimal YlityoPalkka { get; set; }

        public decimal Vero { get; set; }

        public decimal Elakemaksu { get; set; }


        //public decimal Jasenmaksu { get; set; }

        public decimal Sotumaksu { get; set; }

        public decimal PalkkaYhteensa { get; set; }

        public decimal VahennuksetYhteensa { get; set; }

        public decimal Nettopalkka { get; set; }
    }
}
