using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace GameServer.Models
{
    public class BattleArenaContext : DbContext
    {
        public BattleArenaContext(DbContextOptions<BattleArenaContext> options)
        : base(options)
        {
        }

        public DbSet<BattleArena> arenas { get; set; }
}
}
