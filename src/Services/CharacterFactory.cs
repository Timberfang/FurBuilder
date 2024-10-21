using FurBuilder.Configuration;
using FurBuilder.Models;

namespace CharacterFactory
{
	public enum CharacterType
	{
		// TODO: Support shifters (werewolves, shapeshifters, etc.) with more than one form
		// TODO: Support animal characters (non-anthro)
		Human,
		Humanoid
	}

	public class CharacterFactory
	{
		public ICharacter GetCharacter(IOwnerData OwnerData, CharacterType Type)
		{
			switch (Type)
			{
				case CharacterType.Human:
					return new Character(OwnerData, "Human", "Base");
				case CharacterType.Humanoid:
					return new Character(OwnerData, FormName: "Base");
				default:
					throw new IndexOutOfRangeException($"Unrecognized option: '{Type}'.");
			}
		}
	}
}