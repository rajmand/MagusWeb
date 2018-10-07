using System.Collections.Generic;
using System.Linq;

namespace MagusWeb.Models
{
    public class MagusData : IMagusData
    {
        public Species GetSpecieValues(int specie)
        {
            using (var context = new MagusEntities())
            {
                return context.Species.FirstOrDefault(x => x.id == specie);
            }
        }

        public List<Psi> GetPsis()
        {
            using (var context = new MagusEntities())
            {
                return context.Psi.ToList();
            }
        }

        public Psi GetPsi(int id)
        {
            using (var conext = new MagusEntities())
            {
                return conext.Psi.FirstOrDefault(x => x.id == id);
            }
        }
    }
}