using System.Collections.Generic;

namespace MagusWeb.Models
{
    public interface IMagusData
    {
        Species GetSpecieValues(int specie);
        List<Psi> GetPsis();
        Psi GetPsi(int id);
    }
}