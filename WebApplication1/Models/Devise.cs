using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WSConvertisseur.Models
{
    public class Devise
    {
        public int Id { get; set; }
        [Required]
        public String NomDevise { get; set; }
        public double Taux { get; set; }
        public Devise()
        {

        }
        public Devise(int id, string nomDevise, double taux)
        {
            Id = id;
            NomDevise = nomDevise;
            Taux = taux;
        }
    }


}
