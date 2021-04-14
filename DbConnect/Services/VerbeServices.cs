using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DbConnect.Services
{
    public class VerbeServices
    {
        private EnglishBattleEntities context;

        public VerbeServices(EnglishBattleEntities context)
        {
            this.context = context;
        }

        public List<Verbe> GetVerbes()
        {
            using (context)
            {
                IQueryable<Verbe> verbes = context.Verbe.Select(verbe => verbe);
                return verbes.ToList();
            }
        }
    }
}
