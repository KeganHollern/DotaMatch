using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace DotaMatch.SteamAPI {
    #region JSON Objects
    public class Dota2HeroesRequest {
        public Result result { get; set; }
    }

    public class Result {
        public Hero[] heroes { get; set; }
        public int status { get; set; }
        public int count { get; set; }
    }

    public class Hero {
        public string name { get; set; }
        public int id { get; set; }
    }
    #endregion

    class SteamApiRequest {
        
        /// <summary>
        /// Get Dota 2 hero information table. (Name/Id).
        /// </summary>
        /// <param name="APIKey">Steam API Key</param>
        /// <returns></returns>
        public static Dota2HeroesRequest getHeroData(string APIKey) {
            string data = "";
            using (WebClient client = new WebClient()) {
                data = client.DownloadString("https://api.steampowered.com/IEconDOTA2_570/GetHeroes/v0001/?key=" + APIKey);
            }
            try {
                return JsonConvert.DeserializeObject<Dota2HeroesRequest>(data);
            } catch {
                return null;
            }
        }

    }
}
