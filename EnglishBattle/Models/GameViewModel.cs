using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;


namespace EnglishBattle.Models
{
    public class GameViewModel
    {
        [Required]
        [Display(Name = "Pretérit")]
        public string Preterit { get; set; }

        [Required]
        [Display(Name = "Participe passé")]
        public string ParticipePasse { get; set; }


    }
}