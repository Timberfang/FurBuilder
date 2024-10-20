﻿using System.Text.Json.Serialization;

namespace FurBuilder.Data
{
    public interface ICharacter
    {
        // Metadata
        Guid Id { get; }
        string Owner { get; set; }
        DateTime CreatedAt { get; }
        IList<string> Tags { get; set; }
        [JsonIgnore]
        ConfigurableAttribute[] ConfigurableAttributes { get; }

        // Basic information
        string ProfileImage { get; set; }
        string Name { get; set; }
        string Species { get; set; }
        string Gender { get; set; }
        int Age { get; set; }

        // Detailed information
        IList<Appearance> Forms { get; set; } // Allows for multiple forms (e.g. werewolves, shapeshifters, etc.)
        IList<string> Personality { get; set; }
        string Background { get; set; }
        string Notes { get; set; }

        // Methods
        public string ToString();
        public string ToJson();
        public string ToMarkdown();
    }
}
