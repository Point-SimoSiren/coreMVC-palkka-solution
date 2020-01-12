using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Palkkasovellus.Entity
{
    public class Maksutapahtuma
    {
        public int Id { get; set; }

        [ForeignKey("Henkilo")]
        public int HenkiloId { get; set; }

        public Henkilo Henkilo { get; set; }

        [MaxLength(100)]
        public string Kokonimi { get; set; }

        public string Sotu { get; set; }

        public DateTime Maksupaiva { get; set; }

        public string Maksukuukausi { get; set; }

        public string Veronumero { get; set; }

        [Column(TypeName = "decimal(18, 2)")]
        public decimal Veroprosentti { get; set; }

        [Column(TypeName = "decimal(18, 2)")]
        public decimal Elakemaksuprosentti { get; set; }

        [Column(TypeName = "decimal(18, 2)")]
        public decimal Sotumaksuprosentti { get; set; }

        [Column(TypeName = "decimal(18, 2)")]
        public decimal Tyottomyysvakuutusprosentti { get; set; }

        [Column(TypeName = "decimal(18, 2)")]
        public decimal Jasenmaksuprosentti { get; set; }

        [Column(TypeName = "Money")]
        public decimal Tuloraja { get; set;  }

        [Column(TypeName = "decimal(18, 2)")]
        public decimal Lisaprosentti { get; set;  }

        [Column(TypeName = "money")]
        public decimal Tuntipalkka { get; set; }

        [Column(TypeName = "decimal(18, 2)")]
        public decimal Tuntimaara { get; set; }

        [Column(TypeName = "decimal(18, 2)")]
        public decimal SaannollisetTunnit { get; set; }

        [Column(TypeName = "decimal(18, 2)")]
        public decimal Ylityotunnit { get; set; }

        [Column(TypeName = "Money")]
        public decimal SaannolPalkka { get; set; }

        [Column(TypeName = "Money")]
        public decimal Ylityopalkka { get; set; }

        [Column(TypeName = "Money")]
        public decimal Vero { get; set; }

        [Column(TypeName = "Money")]
        public decimal Sosiaaliturvamaksu { get; set; }

        [Column(TypeName = "Money")]
        public decimal Tyottomyysvakuutus { get; set; }

        [Column(TypeName = "Money")]
        public decimal Jasenmaksu { get; set; }

        [Column(TypeName = "Money")]
        public decimal PalkkaYhteensa { get; set; }

        [Column(TypeName = "Money")]
        public decimal VahennyksetYhteensa { get; set; }

        [Column(TypeName = "Money")]
        public decimal Nettopalkka { get; set; }

        public decimal VeronMaara { get; set; }

        public decimal Elakemaksu { get; set; }
    }
}
