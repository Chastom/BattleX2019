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
        public static BattleArena arena = null;
        private readonly BattleArenaContext _context;
        public int ArenaCount { get; set; } = 0;

        public BAController(BattleArenaContext context)
        {
            _context = context;

            //if (_context.arenas.Count() > 0)
            //{
            // ArenaCount++;
            //if (arena == null)
            // {
            //     arena = new BattleArena() { id = 1 };
            // }
            // _context.arenas.Add(arena);
            // _context.SaveChanges();
            //}
        }

        //Should return the current status of the game
        // GET api/BA
        [HttpGet]
        public ActionResult<IEnumerable<BattleArena>> GetAll()
        {
            return _context.arenas.ToList();
        }

        // There should be only 1 battle arena running so in theory should return the same stuff a normal get returns
        // GET api/BA/1
        [HttpGet("{id}", Name = "GetBA")]
        public ActionResult<BattleArena> GetById(int id)
        {
            BattleArena ba = _context.arenas.Find(id);
            if (ba == null)
            {
                return NotFound("Battle arena was not found. Make sure it exists or create a new game!");
            }
            return ba;
        }

        //This should signal the server that a player has connected. Only one instance of a battle arena should be created so no idea how to assign it to the second player once he connects
        // POST api/BA/playerID
        [HttpPost("{id}", Name = "PostBA")]
        public ActionResult<BattleArena> Create(int id)
        {
            if (_context.arenas.Count() >= 1)
            {
                BattleArena foundArena = _context.arenas.FirstOrDefault();
                return CreatedAtRoute("GetBA", foundArena.id);
                //return NotFound("Battle arena wasn't created because it aleady exists");
            }
            BattleArena arena = new BattleArena() { id = 1 };
            _context.arenas.Add(arena);
            _context.SaveChanges();

            return CreatedAtRoute("GetBA", new { id = arena.id }, arena);
            //return Ok();
        }


        // PUT api/BA/1
        /*[HttpPut("{id}")]
        public IActionResult Update(long id, [FromBody] BattleArena ba)
        {
            var baa = _context.arenas.Find(id);
            if (baa == null)
            {
                return NotFound("Can't edit battle arena! Not found, make sure it exists!");
            }

            baa.id = ba.id;

            _context.arenas.Update(baa);
            _context.SaveChanges();

            return Ok();
        }*/


        // DELETE api/BA/1
        /*
        [HttpDelete("{id}")]
        public IActionResult Delete(long id)
        {
            var toDel = _context.arenas.Find(id);
            if (toDel == null)
            {
                return NotFound();
            }

            _context.arenas.Remove(toDel);
            _context.SaveChanges();
            return NoContent();
        }*/
    }
}