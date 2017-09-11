using Dota2.GC.Dota.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotaMatch.Params {

    class DotaLobbyParams {
        private List<ulong> RadiantTeam;
        private List<ulong> DireTeam;
        private int MinPlayers = 0;

        /// <summary>
        /// Checks if the ready player count is = to readyPlayers
        /// </summary>
        /// <param name="readyPlayers">Number of players required to start</param>
        /// <returns>True if the parameter matches the number of ready players</returns>
        public bool hasAllPlayers(int readyPlayers) {
            return (MinPlayers == readyPlayers);
        }

        /// <summary>
        /// Checks if the specified player is in the lobby and in the correct slot.
        /// </summary>
        /// <param name="member">Dota Lobby Member</param>
        /// <returns>True if the player is ready</returns>
        public bool isReadyPlayer(CDOTALobbyMember member) {
            if(RadiantTeam.Contains(member.id)) {
                return (member.team == DOTA_GC_TEAM.DOTA_GC_TEAM_GOOD_GUYS); 
            }
            if (DireTeam.Contains(member.id)) {
                return (member.team == DOTA_GC_TEAM.DOTA_GC_TEAM_BAD_GUYS);
            }
            return false;
        }

        /// <summary>
        /// Initializes new lobby params
        /// </summary>
        /// <param name="Radiant">List of radiant steamid64s</param>
        /// <param name="Dire">List of dire steamid64s</param>
        public DotaLobbyParams(ulong[] Radiant,ulong[] Dire) {
            RadiantTeam = Radiant.ToList<ulong>();
            DireTeam = Dire.ToList<ulong>();

            MinPlayers = DireTeam.Count + RadiantTeam.Count;
            if(MinPlayers == 0) { MinPlayers = 1; }
        }

        /// <summary>
        /// Initializes new lobby params
        /// </summary>
        /// <param name="Radiant">List of radiant steamid64s</param>
        /// <param name="Dire">List of dire steamid64s</param>
        public DotaLobbyParams(List<ulong> Radiant, List<ulong> Dire) {
            RadiantTeam = Radiant;
            DireTeam = Dire;

            MinPlayers = DireTeam.Count + RadiantTeam.Count;
            if (MinPlayers == 0) { MinPlayers = 1; }
        }
    }
}
