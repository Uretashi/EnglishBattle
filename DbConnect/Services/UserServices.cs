using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DbConnect.Data
{
    public class UserServices
    {
        private EnglishBattleEntities context;

        public UserServices(EnglishBattleEntities context)
        {
            this.context = context;
        }

        /// <summary>
        /// Recherche un utilisateur ayant comme ID celui donné en paramètre
        /// </summary>
        /// <param name="id">ID de l'utilisateur</param>
        /// <returns>Renvoie l'utilisateur avec l'ID donné en paramètre</returns>
        public Joueur GetJoueur(int id)
        {
            using (context)
            {
                return context.Joueur.Find(id);
            }
        }

        /// <summary>
        /// Renvoi un utilisateur si l'email et le mdp corresponde
        /// </summary>
        /// <param name="email">email</param>
        /// <param name="mdp">mot de passe</param>
        /// <returns>Renvoie un utilisateur</returns>
        public Joueur GetJoueur(string email, string mdp)
        {
            using (context)
            {
                IQueryable<Joueur> utilisateurs = from joueur in context.Joueur
                                                       where joueur.email == email
                                                       && joueur.motDePasse == mdp
                                                       select joueur;
                return utilisateurs.FirstOrDefault();
            }
        }

        /// <summary>
        /// Ajoute un utilisateur
        /// </summary>
        /// <param name="joueur"></param>
        public void Insert(Joueur joueur)
        {
            using (context)
            {
                context.Joueur.Add(joueur);
                context.SaveChanges();
            }
        }

        /// <summary>
        /// Met à jour un utilisateur
        /// </summary>
        /// <param name="joueur"></param>
        public void Update(Joueur joueur)
        {
            using (context)
            {
                context.Entry(joueur).State = System.Data.Entity.EntityState.Modified;
                context.SaveChanges();
            }
        }

        /// <summary>
        /// Supprime un utilisateur
        /// </summary>
        /// <param name="joueur"></param>
        public void Delete(Joueur joueur)
        {
            using (context)
            {
                context.Entry(joueur).State = System.Data.Entity.EntityState.Deleted;
                context.SaveChanges();
            }
        }
    }
}
