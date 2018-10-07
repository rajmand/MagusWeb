using MagusWeb.Models;

namespace MagusWeb.Services
{
    public interface ICharacterValueService
    {
        CharacterValue GetCharacterValues(int specie, int? strength, int? stamina, int? agility, int? dexterity,
            int? health, int? beauty, int? intelligence, int? astral, int? willPower, int? detection);
    }
}