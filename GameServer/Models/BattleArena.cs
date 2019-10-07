using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GameServer.Models
{
    public class BattleArena
    {
        public int id { get; set; }
        //private static BattleArena obj1;
        //private static BattleArena obj2;
        //public static List<BattleArena> objects = new List<BattleArena>();
        public BattleArena()
        {
            
        }

        /*public static List<BattleArena> getInstance()
        {
            if (obj1 == null && obj2 == null)
            {
                obj1 = new BattleArena();
                obj2 = new BattleArena();
                objects.Add(obj1);
                objects.Add(obj2);
            }
            return objects;
        }*/
    }
}
