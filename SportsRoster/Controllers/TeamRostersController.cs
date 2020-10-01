using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SportsRoster.Model;
using SportsRoster.Repository;

namespace SportsRoster.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TeamRostersController : ControllerBase
    {
        ITeamRepository teamRepository;

        public TeamRostersController(ITeamRepository _teamRepository)
        {
            teamRepository = _teamRepository;
        }

        // GET: api/TeamRosters
        [HttpGet]
        [Route("AllTeams")]//works
        public async Task<ActionResult> GetTeamRoster()//works
        {
            try
            {
                var teams = await teamRepository.GetAllTeams();
                if (teams == null)
                {
                    return NotFound();
                }
                return Ok(teams);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }
        [HttpGet]
        [Route("AllPlayers")]//Works
        public async Task<ActionResult> GetPlayers()//Works
        {
            try
            {
                var players = await teamRepository.GetAllPlayers();
                if (players == null)
                {
                    return NotFound();
                }
                return Ok(players);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        // GET: api/TeamRosters/5
        [HttpGet]
        [Route("TeamsByID")]//Works
        public async Task<ActionResult> GetTeamById(int? id)//Works
        {

            try
            {
                var post = await teamRepository.GetTeamByID(id);
                if (post == null)
                {
                    return NotFound();
                }
                return Ok(post);
            } catch (Exception)
            {
                return BadRequest();
            }
        }
        [HttpGet]
        [Route("TeamsByLocation")]//works
        public async Task<ActionResult> GetTeamById(string? location)//Works
        {

            try
            {
                var post = await teamRepository.GetTeamsByLocation(location);
                if (post == null)
                {
                    return NotFound();
                }
                return Ok(post);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }
        [HttpGet]
        [Route("PlayerByTeam")]//works
        public async Task<ActionResult> GetPlayerByTeam(string? team)//works
        {

            try
            {
                var post = await teamRepository.GetPlayerByTeam(team);
                if (post == null)
                {
                    return NotFound();
                }
                return Ok(post);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }
        [HttpGet]
        [Route("PlayerByName")]//works
        public async Task<ActionResult> GetPlayerByName(string? lName)//works
        {

            try
            {
                var post = await teamRepository.GetPlayerByLastName(lName);
                if (post == null)
                {
                    return NotFound();
                }
                return Ok(post);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }
        [HttpGet]
        [Route("PlayerByID")]//works
        public async Task<ActionResult> GetPlayerById(int? id)//works
        {
            if (id == null)
            {
                return BadRequest();
            }
            try
            {
                var post = await teamRepository.GetPlayerByID(id);
                if (post == null)
                {
                    return NotFound();
                }
                return Ok(post);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        // PUT: api/TeamRosters/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut]
        [Route("UpdatePlayer")]//works
        public async Task<IActionResult> UpdatePlayer([FromBody] Player player)//Fix
        {

            if (ModelState.IsValid)
            {
                try
                {
                    await teamRepository.UpdatePlayer(player);
                    return Ok();
                }
                catch (Exception ex)
                {
                    if (ex.GetType().FullName ==
                    "Microsoft.EntityFrameworkCore.DbUpdateConcurrencyException")
                    {
                        return NotFound();
                    }
                    return BadRequest();
                }
            }
            return BadRequest();


        }
        [HttpPut]
        [Route("UpdateTeam")]//Works
        public async Task<IActionResult> UpdateTeam([FromBody]Team team)//Fix
        {


            if (ModelState.IsValid)
            {
                try
                {
                    await teamRepository.UpdateTeam(team);
                    return Ok();
                }
                catch (Exception ex)
                {
                    if (ex.GetType().FullName ==
                    "Microsoft.EntityFrameworkCore.DbUpdateConcurrencyException")
                    {
                        return NotFound();
                    }
                    return BadRequest();
                }
            }
            return BadRequest();
        }






 


        // POST: api/TeamRosters
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        [Route("AddTeam")]//works
        public async Task<ActionResult> AddTeam([FromBody] Team team)//works
        {
            await teamRepository.AddTeam(team);
            return CreatedAtAction(nameof(GetTeamRoster), new { id = team.Id }, team);
        }

        [HttpPost]
        [Route("AddPlayer")]//works
        public async Task<ActionResult> AddPlayer([FromBody] Player player)
        {
            await teamRepository.AddPlayer(player);
            return CreatedAtAction(nameof(GetPlayers), new { id = player.Id }, player);
        }

        // DELETE: api/TeamRosters/5
        [HttpDelete]
        [Route("DeleteTeam")]//works
        public async Task<ActionResult> DeleteTeam(int id)
        {
            int result = 0;
            
            try
            { 
                result = await teamRepository.DeleteTeamByID(id); 
                if (result == 0) 
                { 
                    return NotFound(); 
                } 
                return Ok(); 
            } 
            catch (Exception)
            { 
                return BadRequest(); 
            }

        }

        // DELETE: api/TeamRosters/5
        [HttpDelete]
        [Route("DeletePlayer")]//works
        public async Task<ActionResult> DeletePlayer(int id)
        {
            int result = 0;

            try
            {
                result = await teamRepository.DeletePlayerByID(id);
                if (result == 0)
                {
                    return NotFound();
                }
                return Ok();
            }
            catch (Exception)
            {
                return BadRequest();
            }

        }
    }
}
