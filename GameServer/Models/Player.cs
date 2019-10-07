using System;
namespace GameServer.Models
{
    public class Player
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public Player(int id, string name)
        {
            this.Id = id;
            this.Name = name;
        }
    }
}
