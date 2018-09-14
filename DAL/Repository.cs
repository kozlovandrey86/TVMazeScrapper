using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DAL
{
    public class Repository
    {
        public static async Task Create(){
            using (var db = new  TVMazeScrapperContext()){
                await db.Database.EnsureCreatedAsync();
            }
        }    

        public static async Task Save(IEnumerable<Show> shows)
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

        public static IEnumerable<Show> GetShows(){
            using (var db = new TVMazeScrapperContext()){
                return db.Shows;
            }
        }

        public static async Task Drop(){
            using (var db=new TVMazeScrapperContext()){
                await db.Database.EnsureDeletedAsync();
            }
        }
    }
}
