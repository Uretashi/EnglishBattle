using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using DbConnect;

namespace EnglishBattle.Models
{
    public class InscriptionViewModel
    {
        [Required]
        [Display(Name = "Nom")]
        public string Nom { get; set; }

        [Required]
        [Display(Name = "Prénom")]
        public string Prenom { get; set; }

        [Required]
        [Display(Name = "Email")]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [Display(Name = "Mot de passe")] // label
        [DataType(DataType.Password)] // type de l'input
        [StringLength(12, MinimumLength = 6, ErrorMessage = "Le mot de passe doit se situer entre 6 et 14 caractères... Stupid motherfucker")]
        public string Password { get; set; }

        [Required]
        [Display(Name = "Confirmer le mot de passe")]
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "Le mot de passe ne correspond pas")]
        public string ConfirmPassword { get; set; }

        [Display(Name = "Veuillez indiqué votre niveau")]
        public List<System.Web.Mvc.SelectListItem> Level { get; set; }

        [Required]
        [Display(Name = "Veuillez indiqué votre niveau")]
        public int LevelValue { get; set; }

        [Display(Name = "Veuillez indiqué votre ville")]
        public List<System.Web.Mvc.SelectListItem> VillesList { get; set; }

        [Required]
        [Display(Name = "Veuillez indiqué votre ville")]
        public string VilleCodePostal { get; set; }
    }
}