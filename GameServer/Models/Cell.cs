using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GameServer.Models
{
    public class Cell
    {
        public int id;
        public bool isHit;
        public bool isArmored;
        public Coordinates coords;

        public Cell()
        {
            
        }
    }
}
