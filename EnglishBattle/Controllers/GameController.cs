using DbConnect;
using DbConnect.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EnglishBattle.Models;

namespace EnglishBattle.Controllers
{
    public class GameController : Controller
    {
        public ActionResult Game(GameViewModel model)
        {
            if (Session["utilisateurId"] == null)
            {
                Response.Redirect("/");
            }

            // Liste des verbes
            List<Verbe> verbes;

            // Si la variable de session "verbes" est null
            if (Session["verbes"] == null) {
                // Contient le nombre de fois ou le joueur trouve les verbes correspondants
                Session["gameWinCount"] = 0;
                Session["errorCount"] = 0;
                // Récupère les verbes afin d'initier le jeu
                verbes = new VerbeServices(new DbConnect.EnglishBattleEntities()).GetVerbes();
            } else {
                if (model.ParticipePasse == Session["participePasse"].ToString() && model.Preterit == Session["preterit"].ToString())
                {
                    Session["gameWinCount"] = (int)Session["gameWinCount"] + 1;
                    if ((int)Session["gameWinCount"] % 5 == 0)
                    {
                        ViewBag.congratulation = "5 réponses valides en plus !";
                    } 
                }
                else
                {
                    Session["errorCount"] = (int)Session["errorCount"] + 1;
                }

                ModelState.Clear();
                
                verbes = (List<Verbe>) Session["verbes"];
            }

            // TODO - game end ? Redirection ?

            // Genere un chiffre aleatoire pour le verbe choisi
            int index = new Random().Next(verbes.Count() - 1);
            // verbeAEnvoye = verbes[idAleatoire]
            Verbe choosenVerb = verbes[index];
            // Supprimer le verbe choisi
            verbes.Remove(choosenVerb);

            // Ajoute aux variables de session les verbes correspondants
            Session["verbes"] = verbes;
            ViewBag.infinitif = choosenVerb.baseVerbale;
            // Les verbes sont inversés
            Session["preterit"] = choosenVerb.participePasse;
            Session["participePasse"] = choosenVerb.preterit;

            return View();
        }
    }
}
