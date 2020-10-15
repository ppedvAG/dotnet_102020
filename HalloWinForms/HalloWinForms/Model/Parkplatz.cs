using System.Collections.Generic;


namespace HalloWinForms
{
    public  class Parkplatz
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public virtual ICollection<Auto> Autos { get; set; } = new HashSet<Auto>();
    }
}
