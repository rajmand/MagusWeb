using System.Web.Mvc;
using MagusWeb.Services.Entity;

namespace MagusWeb.Services
{
    public interface IPsiService
    {
        SelectList GetPsi();
        int GetPsiForLevel(int? psiType, int? level, int? intelligence);
        PsiResistence GetAstralResistence(int? astral, int? staticResistence, int? dynamicResistence, int? other);
        PsiResistence GetMentalResistence(int? willPower, int? staticResistence, int? dynamicResistence, int? other);
    }
}