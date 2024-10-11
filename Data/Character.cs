using System.Text.Json;

namespace FurBuilder.Data
{
    public class Character : ICharacter
    {
        // Metadata
        public Guid Id { get; }
        public string Owner { get; set; }
        public DateTime CreatedAt { get; }
        public IList<string> Tags { get; set; }

        // Basic information
        public string ProfileImage { get; set; }
        public string Name { get; set; }
        public string Species { get; set; }
        public string Gender { get; set; }
        public int Age { get; set; }

        // Detailed information
        public IList<IAppearance> Forms { get; set; }
        public IList<string> Personality { get; set; }
        public string Background { get; set; }
        public string Notes { get; set; }

        public Character(string Owner, string Name, string Species, IList<string>? Tags = null, string ProfileImage = "", string Gender = "", int Age = 0)
        {
            Id = Guid.NewGuid();
            this.Owner = Owner;
            CreatedAt = DateTime.Now;
            this.Tags = Tags ?? [];

            this.ProfileImage = ProfileImage;
            this.Name = Name;
            this.Species = Species;
            this.Gender = Gender;
            this.Age = Age;

            Forms = [];
            Personality = [];
            Background = "";
            Notes = "";
        }

        // Methods
        public override string ToString()
        {
            throw new NotImplementedException();
        }
        public string ToJson()
        {
            return JsonSerializer.Serialize(this, CharacterJsonContext.Default.ICharacter);
        }

        public string ToMarkdown()
        {
            throw new NotImplementedException();
        }
    }
}
