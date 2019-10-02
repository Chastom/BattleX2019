using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using GameServer.Models;

namespace GameServer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BAController : ControllerBase
    {

        private readonly BattleArenaContext _context;
        public int ArenaCount { get; set; } = 0;

        public BAController(BattleArenaContext context)
        {
            _context = context;

            if (_context.arenas.Count() == 0)
            {
                ArenaCount++;
                List<BattleArena> arenos = BattleArena.getInstance();
                _context.arenas.Add(arenos[0]);
                _context.arenas.Add(arenos[1]);
                _context.SaveChanges();
            }
        }

        // GET api/BA
        [HttpGet]
        public ActionResult<IEnumerable<BattleArena>> GetAll()
        {
            return _context.arenas.ToList();
        }
    }
}