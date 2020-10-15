using System;
using System.Collections.Generic;


namespace HalloWinForms
{
    public class Auto
    {
        public int Id { get; set; }
        public string Hersteller { get; set; }
        public string Modell { get; set; }
        public DateTime Baujahr { get; set; }
        public virtual Parkplatz Parkplatz { get; set; }
        public virtual ICollection<Person> Besitzer { get; set; } = new HashSet<Person>();
    }
}
