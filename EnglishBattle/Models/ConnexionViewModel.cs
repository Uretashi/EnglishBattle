using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace EnglishBattle.Models
{
    public class ConnexionViewModel
    {
        [Required]
        [Display(Name = "Votre Email")]
        public string email { get; set; }

        [Required]
        [Display(Name = "Votre Mot de Passe")]
        [DataType(DataType.Password)]
        public string mdp { get; set; }
    }
}