using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DAL
{
    public class Repository: IRepository
    {
        public  async Task Create(){
            using (var db = new  TVMazeScrapperContext()){
                await db.Database.EnsureCreatedAsync();
            }
        }    

        public  async Task Save(IEnumerable<Show> shows)
        {
            using (var db = new TVMazeScrapperContext())
            {
                try
                {
                    await db.Shows.AddRangeAsync(shows);
                    db.SaveChanges();
                }
                catch{
                    //TODO:logging
                }
            }
        }

        public  IEnumerable<Show> GetShows(){
            //using (var db = new TVMazeScrapperContext()){
            var db = new TVMazeScrapperContext();
                return db.Shows;
            //}
        }

        public  async Task Drop(){
            using (var db=new TVMazeScrapperContext()){
                await db.Database.EnsureDeletedAsync();
            }
        }
    }
}
