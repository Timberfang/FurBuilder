using System.Text.Json;
using System.Text.Json.Serialization;

namespace FurBuilder.Data
{
    public class Character : ICharacter
    {
        // Metadata
        public Guid Id { get; }
        public string Owner { get; set; }
        public DateTime CreatedAt { get; }
        public IList<string> Tags { get; set; }

        // (Arbitrary) list of configurable attributes; Used for character creation & editing. Only include properties related to the *character*, not metadata.
        [JsonIgnore]
        public ConfigurableAttribute[] ConfigurableAttributes
        {
            get
            {
                return [
                    // Testing length is more performant than string comparison. See https://stackoverflow.com/questions/7872633/most-performant-way-of-checking-empty-strings-in-c-sharp
                    // Don't need String.IsNullOrEmpty(), since the constructor ensures that these are *never* null.
                    new("Profile Image", ProfileImage.Length > 0),
                    new("Name", Name.Length > 0),
                    new("Species", Species.Length > 0),
                    new("Gender", Gender.Length > 0),
                    new("Age", Age > 0),
                    new("Forms", Forms.Count > 0),
                    new("Personality", Personality.Count > 0),
                    new("Background", Background.Length > 0),
                    new("Notes", Notes.Length > 0)
                ];
            }
        }

        // Basic information
        public string ProfileImage { get; set; }
        public string Name { get; set; }
        public string Species { get; set; }
        public string Gender { get; set; }
        public int Age { get; set; }

        // Detailed information
        public IList<Appearance> Forms { get; set; }
        public IList<string> Personality { get; set; }
        public string Background { get; set; }
        public string Notes { get; set; }

        public Character(string Owner = "", string Name = "", string Species = "", IList<string>? Tags = null, string ProfileImage = "", string Gender = "", int Age = 0)
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
            return JsonSerializer.Serialize(this, CharacterJsonContext.Default.Character);
        }

        public string ToMarkdown()
        {
            throw new NotImplementedException();
        }
    }
}
