using System;
using System.Web.Mvc;
using MagusWeb.Models;
using MagusWeb.Services.Entity;

namespace MagusWeb.Services
{
    public class PsiService : IPsiService
    {
        private readonly IMagusData _magusData;

        public PsiService(IMagusData magusData)
        {
            _magusData = magusData;
        }

        public SelectList GetPsi()
        {
            return new SelectList(_magusData.GetPsis(), "id", "Name");
        }

        public int GetPsiForLevel(int? psiType, int? level, int? intelligence)
        {
            if (psiType == null)
            {
                return 0;
            }

            var psiTypeEntity = _magusData.GetPsi((int)psiType);
            int psiLevel = level.GetValueOrDefault();

            if (psiTypeEntity.Base == null || psiTypeEntity.Further == null || psiLevel < 0) return 0;

            int basePsi = Convert.ToInt16(psiTypeEntity.Base.Value);
            int furtherPsi = psiTypeEntity.Further.Value;
            int fromIntelligence;
            if (intelligence.GetValueOrDefault() > 10)
            {
                fromIntelligence = intelligence.GetValueOrDefault() - 10;
            }
            else
            {
                fromIntelligence = 0;
            }

            if (psiLevel == 0 || psiLevel == 1)
            {
                return basePsi + fromIntelligence;
            }

            int sumPsi = basePsi + (psiLevel - 1) * furtherPsi + fromIntelligence;
            return sumPsi;

        }

        public PsiResistence GetAstralResistence(int? astral, int? staticResistence, int? dynamicResistence, int? other)
        {
            return GetPsiresistence(astral, staticResistence, dynamicResistence, other);
        }

        public PsiResistence GetMentalResistence(int? willPower, int? staticResistence, int? dynamicResistence, int? other)
        {
            return GetPsiresistence(willPower, staticResistence, dynamicResistence, other);
        }

        private PsiResistence GetPsiresistence(int? tmeBasedValue, int? staticResistence, int? dynamicResistence,
            int? other)
        {
            var resitence = new PsiResistence();
            if (tmeBasedValue != null && tmeBasedValue > 10)
            {
                resitence.Tme = (int)tmeBasedValue - 10;
            }
            else
            {
                resitence.Tme = 0;
            }

            resitence.Static = staticResistence ?? 0;
            resitence.Dynamic = dynamicResistence ?? 0;
            resitence.Other = other ?? 0;
            resitence.Sum = resitence.Tme + resitence.Dynamic + resitence.Static +
                            resitence.Other;

            return resitence;
        }
    }
}