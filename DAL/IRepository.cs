using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public interface IRepository
    {
        Task Create();

        Task Save(IEnumerable<Show> shows);

        IEnumerable<Show> GetShows();


        Task Drop();
        
    }
}
