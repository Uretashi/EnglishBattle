using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DbConnect;
using DbConnect.Data;
using DbConnect.Services;
using EnglishBattle.Models;

namespace EnglishBattle.Controllers
{
    public class AccountController : Controller
    {

        // GET: Account
        public ActionResult Register()
        {
            InscriptionViewModel model = new InscriptionViewModel();
            VilleServices villes = new VilleServices(new DbConnect.EnglishBattleEntities());

            model.Level = new List<System.Web.Mvc.SelectListItem>()
            {
                new SelectListItem { Value = "1", Text = "Débutant" },
                new SelectListItem { Value = "2", Text = "Intermédiaire" },
                new SelectListItem { Value = "3", Text = "Avancé" }
            };

            model.VillesList = villes.GetVilles().ConvertAll(x => new SelectListItem { Text = x.Nom, Value = x.CodePostal.ToString() });

            return View(model);
        }
        //POST : Account (formulaire)
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public ActionResult Register(InscriptionViewModel model)
        {
            //validation Formulaire côté serveur
            if (ModelState.IsValid)
            {
                UserServices userServices = new UserServices(new DbConnect.EnglishBattleEntities());

                Joueur joueur = new Joueur();

                //Ajout compte BDD
                joueur.nom = model.Nom;
                joueur.prenom = model.Prenom;
                joueur.email = model.Email;
                joueur.motDePasse = model.Password;
                joueur.niveau = model.LevelValue;
                joueur.idVille = int.Parse(model.VilleCodePostal);

                userServices.Insert(joueur);

                //Renvoie à l'accueuil
                return RedirectToAction("Index", "Home");
            }

            return View();
        }
        public ActionResult Login(ConnexionViewModel model)
        {
            UserServices userServices = new UserServices(new DbConnect.EnglishBattleEntities());

            Joueur joueur = userServices.GetJoueur(model.email, model.mdp);

            if (joueur != null)
            {
                Session["utilisateurId"] = joueur.id;
                Session["utilisateurName"] = joueur.prenom + " " + joueur.nom;

                Session.Remove("verbes");
                Session.Remove("preterit");
                Session.Remove("participePasse");

                return RedirectToAction("Game", "Game");
            }
            else
            {
                ViewBag.Error = "Le Email/Mot de passe est incorrect";
            }

            return View();
        }
        public ActionResult SessionEnd()
        {
            Session.Abandon();
            return RedirectToAction("Index", "Home");
        }
    }
}