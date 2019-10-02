using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GameServer.Models
{
    public class Ship
    {
        public int id { get; set; }
        public string name { get; set; }
        public int remainingTiles { get; set; }
    }
}
