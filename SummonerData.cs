using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RiftAlytics
{
    public class SummonerData
    {
        public string Puuid {  get; set; }
        public string FullName { get; set; }
        public long Level { get; set; }

        public async Task addUserToDb(SummonerData summoner)
        {
            using (var context= new SQLiteDbContext())
            {
                context.Database.Migrate();
                bool ifExistsInDb= await context.SummonerData.AnyAsync(u=> u.FullName == summoner.FullName);
                if (!ifExistsInDb)
                {
                    
                    context.SummonerData.Add(summoner);
                    context.SaveChangesAsync();
                }
                
                
            }
        }
    }

    public class MatchInfo
    {
        public string GameMode {  get; set; }
        public string MatchId { get; set; }
        public bool IsWin   { get; set; }
        
    }


}
