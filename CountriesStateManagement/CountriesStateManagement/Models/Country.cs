using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CountriesStateManagement.Models
{
    public class Country
    {
        public string Name { get; set; }
        public List<string> Languages { get; set; }
        public string HelloWorld { get; set; }
        public string Description { get; set; }
        public List<string> Colors { get; set; }

        // Constructors
        public Country(string Name, List<string> Languages, string HelloWorld, string Description, List<string> Colors)
        {
            this.Name = Name;
            this.Languages = Languages;
            this.HelloWorld = HelloWorld;
            this.Description = Description;
            this.Colors = Colors;
        }
    }
}
