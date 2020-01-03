using Microsoft.AspNetCore.Http;
using Palkkasovellus.Entity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Palkkasovellus.Models
{
    public class HenkiloEditViewModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Anna järjestelmän henkilönumero muotoa 'ABC123'"),
            RegularExpression(@"^[A-Z]{3,3}[0-9]{3}$")]
        public string HenkiloNro { get; set; }

        [Required(ErrorMessage = "Anna etunimi"), StringLength(50, MinimumLength = 2)]
        [RegularExpression(@"^[A-Ö][a-öA-Ö""'\s-]*$"), Display(Name = "Etunimi")]
        public string Etunimi { get; set; }

        [StringLength(50), Display(Name = "Toinen nimi")]
        public string ToinenNimi { get; set; }

        [Required(ErrorMessage = "Anna Sukunimi"), StringLength(50, MinimumLength = 2)]
        [RegularExpression(@"^[A-Ö][a-öA-Ö""'\s-]*$"), Display(Name = "Sukunimi")]
        public string Sukunimi { get; set; }

        public string Sukupuoli { get; set; }

        [Display(Name = "Kuva")]
        public IFormFile KuvaUrl { get; set; }

        [DataType(DataType.Date), Display(Name = "Syntymäaika")]
        public DateTime SyntymaAika { get; set; }

        [DataType(DataType.Date), Display(Name = "Aloitus pvm")]
        public DateTime AloitusPvm { get; set; } = DateTime.Now;

        [Required(ErrorMessage = "Anna työtehtävä"), StringLength(100)]
        public string Tehtava { get; set; }

        [DataType(DataType.EmailAddress)]
        public string Sahkoposti { get; set; }

        public string Puhelin { get; set; }

        //dd, mm, yy, A/+/- , nro*3, A-Z*1
        [Required, StringLength(50), Display(Name = "Sotu")]
        [RegularExpression(@"^(0[1-9]|[12]\d|3[01])(0[1-9]|1[0-2])\d\d[+\-A]\d{3,4}[\dA-Za-z]$")]
        public string SosTurvaTunnus { get; set; }

        public Maksutapa Maksutapa { get; set; }

        [Display(Name = "Liiton jäsen")]
        public LiitonJasen LiitonJasen { get; set; }

        [Required, StringLength(150)]
        public string Osoite { get; set; }

        [Required, StringLength(50)]
        public string Kaupunki { get; set; }

        [Required, StringLength(50)]
        public string Postinro { get; set; }
    }
}
