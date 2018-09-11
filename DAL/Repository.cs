using System;
using System.Collections;
using System.Collections.Generic;

namespace DAL
{
    public class Repository
    {
        
        public static void Save(){
        
        }

        public static IEnumerable<Show> GetShows(){
            using (var db = new TVMazeScrapperContext()){
                return db.Shows;
            }
        }
    }
}
