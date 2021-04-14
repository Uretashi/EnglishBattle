using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DbConnect.Services
{
    public class PartieServices
    {
        private EnglishBattleEntities context;

        public PartieServices(EnglishBattleEntities context)
        {
            this.context = context;
        }

        public void Insert(Partie partie)
        {
            using (context)
            {
                context.Partie.Add(partie);
                context.SaveChanges();
            }
        }

        public Partie GetUserBestScore(int idUser)
        {
            using (context)
            {
                IQueryable<Partie> LastPartie = from partie in context.Partie
                                                  where partie.idJoueur == idUser
                                                  select partie;
                return LastPartie.LastOrDefault();
            }
        }
    }
}
