using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DbConnect.Services
{
    public class VilleServices
    {
        public class VilleInfos
        {
            public string Nom { get; set; }
            public int CodePostal { get; set; }
        }

        private EnglishBattleEntities context;

        public VilleServices(EnglishBattleEntities context)
        {
            this.context = context;
        }

        public List<VilleInfos> GetVilles()
        {
            using (context)
            {
                var villes = from ville in context.Ville
                                select new VilleInfos { Nom = ville.nom, CodePostal = ville.id };

                return villes.ToList();
            }
        }
    }
}
