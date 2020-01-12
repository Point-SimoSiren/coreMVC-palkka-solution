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

        public string Veronumero { get; set; } = "V13548";
        
        public decimal Tuntipalkka { get; set; }

        [Display(Name = "Tehdyt työtunnit")]
        public decimal TehdytTunnit { get; set; }

        [Display(Name = "Säännölliset tunnit")]
        public decimal SaannollisetTunnit { get; set; } = 144m;

        public decimal Ylityotunnit { get; set; }

        [Display(Name = "Säännöllisen ta palkka")]
        public decimal SaannolPalkka { get; set; }

        [Display(Name = "Ylityöpalkka")]
        public decimal Ylityopalkka { get; set; }

        public decimal Veroprosentti { get; set; }

        public decimal Tuloraja { get; set; }

        [Display(Name = "Lisäprosentti")]
        public decimal Lisaprosentti { get; set; }

        [Display(Name = "Eläkemaksu-%")]
        public decimal Elakemaksuprosentti { get; set; }

        [Display(Name = "Sotumaksu-%")]
        public decimal Sotumaksuprosentti { get; set; }

        [Display(Name = "Työttömyysvakuutus-%")]
        public decimal Tyottomyysvakuutusprosentti { get; set; }

        [Display(Name = "Jäsenmaksu-%")]
        public decimal Jasenmaksuprosentti { get; set; }


        public decimal Vero { get; set; }

        [Display(Name = "Eläkemaksu")]
        public decimal Elakemaksu { get; set; }

        [Display(Name = "Jäsenmaksu")]
        public decimal Jasenmaksu { get; set; }

        public decimal Sotumaksu { get; set; }

        [Display(Name = "Palkka yhteensä")]
        public decimal PalkkaYhteensa { get; set; }

        [Display(Name = "Pidätykset yhteensä")]
        public decimal VahennuksetYhteensa { get; set; }

        public decimal Nettopalkka { get; set; }
    }
}
