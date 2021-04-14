using DbConnect;
using DbConnect.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EnglishBattle.Controllers
{
    public class GameController : Controller
    {
        public ActionResult Game()
        {
            List<Verbe> verbes;
            if (Session["verbes"] == null) {
                verbes = new VerbeServices(new DbConnect.EnglishBattleEntities()).GetVerbes();
            } else {
                verbes = (List<Verbe>) Session["verbes"];
            }

            // Genere un chiffre aleatoire pour le verbe choisi
            int index = new Random().Next(verbes.Count() - 1);
            // verbeAEnvoye = verbes[idAleatoire]
            Verbe choosenVerb = verbes[index];
            // Supprimer le verbe choisi
            verbes.Remove(choosenVerb);
            Session["verbes"] = verbes;

            ViewBag.infinitif = choosenVerb.baseVerbale;
            ViewBag.preterit = choosenVerb.preterit;
            ViewBag.participePasse = choosenVerb.participePasse;

            return View();
        }
    }
}
