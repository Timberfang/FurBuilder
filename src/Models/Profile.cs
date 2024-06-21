using System;
using System.Collections.Generic;

namespace FurBuilder.Models
{
    public class Profile
    {
        // TODO: Check data types on these fields before using them.

        private string Name;
        private string Species;
        private DateOnly DateOfBirth;
        private string Sex;
        private string Owner;
        private string EyeColor;
        private List<string> FurColors;
        private string Backstory;
        private float Height;
        private float Weight;
        private string Build;
        private string Type;
        private Guid ID;
        private DateOnly IssueDate;

        public Profile()
        {
            Name = String.Empty;
            Species = String.Empty;
            DateOfBirth = new DateOnly(1900, 01, 01);
            Sex = String.Empty;
            Owner = String.Empty;
            EyeColor = String.Empty;
            FurColors = [];
            Backstory = String.Empty;
            Height = 0;
            Weight = 0;
            Build = String.Empty;
            Type = String.Empty;
            ID = Guid.NewGuid();
            IssueDate = DateOnly.FromDateTime(DateTime.Now);
        }
    }
}
