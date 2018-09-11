using System.Collections.Generic;

namespace DAL
{
    public class Show
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public List<Cast> Casts { get; set; }
    }
}