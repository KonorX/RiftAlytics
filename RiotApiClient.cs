using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Text.Json.Nodes;
using System.Threading.Tasks;

namespace RiftAlytics
{
    public class RiotApiClient
    {
        private readonly HttpClient _httpClient;
        private readonly string _apiKey= "RGAPI-b26cf9b0-c584-419c-b3e0-0887caf2ac34";
        
        
        public RiotApiClient() {
            _httpClient = new HttpClient();
            _httpClient.DefaultRequestHeaders.Add("X-Riot-Token", _apiKey);
        }

        public async Task<string> GetSummonerPuuidByNameAsync(string name, string tag)
        {
            var response = await _httpClient.GetAsync($"https://europe.api.riotgames.com/riot/account/v1/accounts/by-riot-id/{name}/{tag}?api_key={_apiKey}");
            response.EnsureSuccessStatusCode();

            using var json = await JsonDocument.ParseAsync(await response.Content.ReadAsStreamAsync());
            return json.RootElement.GetProperty("puuid").GetString();
        }

        public async Task<SummonerData> GetSummonerInfoAsync(string puuid, string name, string tag)
        {
            SummonerData summonerData = new SummonerData();
            var response = await _httpClient.GetAsync($"https://ru.api.riotgames.com/lol/summoner/v4/summoners/by-puuid/{puuid}?api_key={_apiKey}");
            response.EnsureSuccessStatusCode();
            
            using var json = await JsonDocument.ParseAsync( await response.Content.ReadAsStreamAsync());
            summonerData.Puuid = puuid;
            summonerData.FullName = $"{name}#{tag}";
            summonerData.Level=json.RootElement.GetProperty("summonerLevel").GetInt32();
            return summonerData;
        }

        public async Task<double> GetWinrateAsync(string puuid, int count = 20)
        {
            try
            {
                var matchIds= await GetMatchIdsAsync(puuid, count);
                int wins = 0;
                foreach (var match in matchIds)
                {
                    if (await IsWinAsync(puuid,match))
                    {
                        wins++;
                    }
                }
                return (double)wins / matchIds.Count * 100;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return -1;
                
            }
        }

        public async Task<List<PlayerStats>> GetPlayersMatchInfo(string matchid, string puuid)
        {
            List<PlayerStats> playerStats = new List<PlayerStats>();

            var response = await _httpClient.GetAsync($"https://europe.api.riotgames.com/lol/match/v5/matches/{matchid}?api_key={_apiKey}");
            response.EnsureSuccessStatusCode();
            using JsonDocument json = JsonDocument.Parse(await response.Content.ReadAsStringAsync());
            var root = json.RootElement;
            foreach (var participant in root.GetProperty("info").GetProperty("participants").EnumerateArray()) 
            {
                PlayerStats tempPlayer = new PlayerStats();
                if (participant.GetProperty("puuid").GetString() == puuid)
                {
                    tempPlayer.kills = participant.GetProperty("kills").GetInt32();
                    tempPlayer.deaths = participant.GetProperty("deaths").GetInt32();
                    tempPlayer.assists = participant.GetProperty("assists").GetInt32();
                    tempPlayer.championName = participant.GetProperty("championName").GetString();
                    tempPlayer.role = participant.GetProperty("individualPosition").GetString();
                    tempPlayer.kda = participant.GetProperty("challenges").GetProperty("kda").GetDouble();
                    tempPlayer.stealthWards=participant.GetProperty("challenges").GetProperty("stealthWardsPlaced").GetInt32();
                    tempPlayer.controlWards = participant.GetProperty("challenges").GetProperty("controlWardsPlaced").GetInt32();
                    tempPlayer.IsCustomer = true;
                    tempPlayer.killParticipation = participant.GetProperty("challenges").GetProperty("killParticipation").GetDouble();
                    playerStats.Add(tempPlayer);
                }
                else 
                {
                    tempPlayer.kills = participant.GetProperty("kills").GetInt32();
                    tempPlayer.deaths = participant.GetProperty("deaths").GetInt32();
                    tempPlayer.assists = participant.GetProperty("assists").GetInt32();
                    tempPlayer.championName = participant.GetProperty("championName").GetString();
                    tempPlayer.IsCustomer = false;
                    playerStats.Add(tempPlayer);
                }
                
            }
            return playerStats;

        }

        public async Task<List<string>> GetMatchIdsAsync(string puuid, int count)
        {
            var response = await _httpClient.GetAsync($"https://europe.api.riotgames.com/lol/match/v5/matches/by-puuid/{puuid}/ids?start=0&count={count}&api_key={_apiKey}");
            response.EnsureSuccessStatusCode();
            return JsonSerializer.Deserialize<List<string>>(await response.Content.ReadAsStringAsync());
        }

        public async Task<MatchInfo> GetMatchInfoAsync(string puuid,string matchId)
        {
            MatchInfo info = new MatchInfo();
            info.MatchId = matchId;
            var response = await _httpClient.GetAsync($"https://europe.api.riotgames.com/lol/match/v5/matches/{matchId}?api_key={_apiKey}");
            response.EnsureSuccessStatusCode() ;
            using JsonDocument json = JsonDocument.Parse(await response.Content.ReadAsStringAsync());
            var root = json.RootElement;
            info.GameMode = root.GetProperty("info").GetProperty("gameMode").GetString();
            foreach (var participant in root.GetProperty("info").GetProperty("participants").EnumerateArray())
            {
                if (participant.GetProperty("puuid").GetString()==puuid)
                {
                    info.IsWin = participant.GetProperty("win").GetBoolean();
                    return info;
                }
            }
            throw new Exception("ошибка с поиском данных об игре");
            
        }

        public async Task<bool> IsWinAsync(string puuid, string matchId)
        {
            var response = await _httpClient.GetAsync($"https://europe.api.riotgames.com/lol/match/v5/matches/{matchId}?api_key={_apiKey}");
            response.EnsureSuccessStatusCode();
            using JsonDocument json = JsonDocument.Parse(await response.Content.ReadAsStringAsync());
            var root = json.RootElement;

            foreach (var participant in root.GetProperty("info").GetProperty("participants").EnumerateArray())
            {
                if (participant.GetProperty("puuid").GetString()==puuid)
                {
                    return participant.GetProperty("win").GetBoolean();
                }
            }
            throw new Exception("игрока не было в матче");
        }
    }
}
