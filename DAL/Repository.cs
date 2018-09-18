using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using Microsoft.EntityFrameworkCore;
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

        public async Task<IEnumerable<Show>> GetShows(int page = 0)
        {
            var pageSize = 1;
            if (page < 0)
                return GetAllShows();
            var shows = _context.Shows
                               .Skip(pageSize * page)
                               .Take(pageSize);
            await shows.ForEachAsync(s => _context.Entry(s).Collection(c => c.Casts.OrderByDescending(b => b.Birthday)));
            _context.Entry(shows).Collection(s=>s. cast)
            // .Include(s=>s.Casts.OrderByDescending());
            return shows;


        }
        
        public  async Task Drop(){
            await _context.Database.EnsureDeletedAsync();
        }
    }
}
