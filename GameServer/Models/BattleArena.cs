using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GameServer.Models
{
    public class BattleArena
    {
        public int id { get; set; }
        public Player player1 { get; set; }
        public Player player2 { get; set; }
        public Boolean bothConnected { get; set; } = false;
        public BattleArena()
        {
            
        }
    }
}
