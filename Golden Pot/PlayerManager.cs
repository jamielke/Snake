using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Golden_Pot
{
    public class PlayerManager
    {
        private List<Player> players;

        public PlayerManager(List<Player> players)
        {
            this.players = players;
        }

        public List<Player> getPlayers()
        {
            return players;
        }
    }
}