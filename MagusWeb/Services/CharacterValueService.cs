using MagusWeb.Models;

namespace MagusWeb.Services
{
    public class CharacterValueService : ICharacterValueService
    {
        private readonly IMagusData _magusData;

        public CharacterValueService(IMagusData magusData)
        {
            _magusData = magusData;
        }

        public CharacterValue GetCharacterValues(int specie, int? strength, int? stamina, int? agility, int? dexterity, int? health, int? beauty, int? intelligence, int? astral, int? willPower, int? detection)
        {
            var values = new CharacterValue();
            var specieValues = _magusData.GetSpecieValues(specie);

            values.Strength = (strength.GetValueOrDefault() + specieValues.StrengthModifier.GetValueOrDefault()).LimitToMax(specieValues.StrengthMax);
            values.Stamina = (stamina.GetValueOrDefault() + specieValues.StaminaModifier.GetValueOrDefault()).LimitToMax(specieValues.StaminaMax);
            values.Agility = (agility.GetValueOrDefault() + specieValues.AgilityModifier.GetValueOrDefault()).LimitToMax(specieValues.AgilityMax);
            values.Dexterity =
                (dexterity.GetValueOrDefault() + specieValues.DexterityModifier.GetValueOrDefault()).LimitToMax(
                    specieValues.DexterityMax);
            values.Health =
                (health.GetValueOrDefault() + specieValues.HealthModifier.GetValueOrDefault()).LimitToMax(specieValues
                    .HealthMax);
            values.Beauty = (beauty.GetValueOrDefault() + specieValues.BeautyModifier.GetValueOrDefault()).LimitToMax(specieValues
                .BeautyMax);
            values.Intelligence = (intelligence.GetValueOrDefault() + specieValues.IntelligenceModifier.GetValueOrDefault()).LimitToMax(specieValues
                .IntelligenceMax);
            values.Astral = (astral.GetValueOrDefault() + specieValues.AstralModifier.GetValueOrDefault()).LimitToMax(specieValues
                .AstralMax);
            values.WillPower = (willPower.GetValueOrDefault() + specieValues.WillPowerModifier.GetValueOrDefault()).LimitToMax(specieValues
                .WillPowerMax);
            values.Detection = detection.GetValueOrDefault().LimitToMax(specieValues.DetectionMax);

            values.Average = values.Strength + values.Stamina + values.Agility + values.Dexterity + values.Health +
                              values.Beauty + values.Intelligence + values.Astral + values.WillPower +
                              values.Detection;
            values.Average = values.Average / 10;

            return values;
        }
    }
}