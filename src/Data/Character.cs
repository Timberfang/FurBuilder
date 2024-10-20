using System.Text.Json;

namespace FurBuilder.Data
{
    public class Character : ICharacter
    {
        public ICharacterMetadata Metadata { get; set; } = new CharacterMetadata();
        public ICharacterBasicInfo BasicInfo { get; set; } = new CharacterBasicInfo();
        public IList<IAppearance> Forms { get; set; } = [];
        public IList<string> Personality { get; set; } = [];
        public string Background { get; set; } = "";
        public string Notes { get; set; } = "";

        public override string ToString()
        {
            throw new NotImplementedException();
        }
        public string ToJson()
        {
            return JsonSerializer.Serialize(this, CharacterJsonContext.Default.Character);
        }
        public string ToMarkdown()
        {
            throw new NotImplementedException();
        }
    }
}
