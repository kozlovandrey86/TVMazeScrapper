using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
namespace DAL
{
    public class Show
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public virtual ICollection<Cast> Casts { get; set; }
    }
}