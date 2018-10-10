using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WSConvertisseur.Models
{
    /// <summary>
    /// Classe comportant toutes les informations d'une devise
    /// </summary>
    public class Devise
    {
        public int Id { get; set; }
        [Required]
        public String NomDevise { get; set; }
        public double Taux { get; set; }
        public Devise()
        {

        }
        /// <summary>
        /// Propriété devise contenant les informations d'une devise
        /// </summary>
        /// <param name="id"></param>
        /// <param name="nomDevise"></param>
        /// <param name="taux"></param>
        public Devise(int id, string nomDevise, double taux)
        {
            Id = id;
            NomDevise = nomDevise;
            Taux = taux;
        }

        public override bool Equals(object obj)
        {
            var devise = obj as Devise;
            return devise != null &&
                   Id == devise.Id &&
                   NomDevise == devise.NomDevise &&
                   Taux == devise.Taux;
        }
    }


}
