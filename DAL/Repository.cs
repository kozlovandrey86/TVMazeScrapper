using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
namespace DAL
{
    public class Repository: IRepository
    {
        private readonly TVMazeScrapperContext _context;
        public Repository(TVMazeScrapperContext context)
        {
            _context = context;
        }

        public  async Task Create(){
            await _context.Database.EnsureCreatedAsync();
        }    

        public  async Task Save(IEnumerable<Show> shows)
        {
            try
            {
                await _context.Shows.AddRangeAsync(shows);
            _context.SaveChanges();
            }
            catch{
                //TODO:logging
            }
        }

        public IEnumerable<Show> GetAllShows()
        {
            return _context.Shows;
        }

        public  IEnumerable<Show> GetShows(int page = 1)
        {
            var pageSize = 10;
            if (page <= 0)
                return GetAllShows();
            return _context.Shows.Skip(pageSize * page).Take(pageSize);
        }
        
        public  async Task Drop(){
            await _context.Database.EnsureDeletedAsync();
        }
    }
}
