using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace RiftAlytics
{
    public class PlayerStats
    {
        public bool IsCustomer {  get; set; }
        public string championName {  get; set; }
        public string role { get; set;}
        public int deaths {  get; set; }
        public double kda { get; set; }
        public int assists { get; set; }
        public int stealthWards { get; set; }
        public int controlWards { get; set; }
        public int kills { get; set; }
        public double killParticipation { get; set; }

        public PlayerStats() { }
        public PlayerStats(string championName,int kills, int deaths, int assists, bool isCustomer = false)
        {
            
            this.championName = championName;
            
            this.deaths = deaths;
            this.kills = kills;
            this.assists = assists;
        }

        public PlayerStats(bool isCustomer, string championName, string role, double kda, int kills, int deaths, int assists, int stealthwards, int controlwards, double killParticipation)
        {
            this.IsCustomer = true;
            this.championName= championName;
            this.role = role;
            this.kda = kda;
            this.kills = kills;
            this.deaths = deaths;
            this.assists = assists;
            this.stealthWards = stealthwards;
            this.controlWards = controlwards;
            this.killParticipation = killParticipation;
        }
    }
}
