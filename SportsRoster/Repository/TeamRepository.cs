using Microsoft.EntityFrameworkCore;
using SportsRoster.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Threading;
using System.Threading.Tasks;

namespace SportsRoster.Repository
{
    public class TeamRepository : ITeamRepository
    {
        TeamDBContext db;
        public TeamRepository(TeamDBContext _db)
        {
            db = _db; //uses the database to build these methods
        }

        public async Task<int> AddPlayer(Player player)
        {
            if(db!=null)//Creater player with properties from player class.
            {
                //if less than 8 then add player
                await db.Players.AddAsync(player);
                await db.SaveChangesAsync();

                return player.Id;
            }
            return 0;
        } 

        public async Task<int> AddTeam(Team team)
        {
            if (db!=null)
            {
                await db.Teams.AddAsync(team);
                await db.SaveChangesAsync();
            }
            return 0;
        }

        public async Task<int> DeletePlayerByID(int? id)
        {
            int result = 0;
            if (db !=null)
            {
                var player = await db.Players.FirstOrDefaultAsync(n => n.Id == id); //finds the ID requested
                if (player !=null)
                {
                    db.Players.Remove(player);
                    result = await db.SaveChangesAsync();
                    
                }
                return result;
            }
            return result;
        }

        public async Task<int> DeleteTeamByID(int? id)//Works
        {
            int result = 0;
            if (db != null)
            {
                var team = await db.Teams.FirstOrDefaultAsync(n => n.Id == id); //finds the ID requested
                if (team != null)
                {
                    db.Teams.Remove(team);
                    result = await db.SaveChangesAsync();

                }
                return result;
            }
            return result;
        }

        public async Task<List<Player>> GetAllPlayers()
        {
            if (db!=null)
            {
                return await db.Players.ToListAsync();
            }
            return null;
        }

        public async Task<List<Team>> GetAllTeams()
        {
            if (db != null)
            {
                return await db.Teams.ToListAsync();
            }
            return null;
        }

        public async Task<TeamRoster> GetPlayerByID(int? id)
        {
            if(db!=null)
            {
                return await (from p in db.Players
                              from t in db.Teams
                              where p.Id == id
                              select new TeamRoster
                              {
                                  TeamId = t.Id,
                                  TeamLocation = t.TLocation,
                                  PlayerId = p.Id,
                                  PlayerFName = p.FName,
                                  PlayerLName = p.LName
                              }).FirstOrDefaultAsync();             
            }
            return null;
        }

        public async Task<List<TeamRoster>> GetPlayerByLastName(string? lName)//works
        {
            if (db != null)
            {
                return await(from p in db.Players
                             
                              //Can I do this?
                             where p.LName == lName
                             select new TeamRoster
                             {
                                 PlayerId = p.Id,
                                 PlayerFName = p.FName,
                                 PlayerLName = p.LName,

                                 
                             }).ToListAsync();
            }
            return null;
        }

        public async Task<List<TeamRoster>> GetPlayerByTeam(string? tName)
        {
            if (db != null)
            {
                return await(from t in db.Teams
                             from p in db.Players
                             where t.TName == tName
                             select new TeamRoster
                             {
                                 PlayerFName=p.FName,
                                 PlayerLName=p.LName
                             }).ToListAsync();
            }
            return null;
        }

        public async Task<TeamRoster> GetTeamByID(int? id)
        {
            if (db != null)
            {
                return await(from t in db.Teams
                             
                             where t.Id == id
                             select new TeamRoster
                             {
                                 TeamId = t.Id,
                                 TeamName= t.TName,
                                 TeamLocation = t.TLocation,
                                 
                             }).FirstOrDefaultAsync();
            }
            return null;
        }

        public async Task<List<TeamRoster>> GetTeamsByLocation(string? tLocation)
        {
            
            if (db != null)
            {
                return await (from t in db.Teams
                              where t.TLocation == tLocation
                              select new TeamRoster
                              {
                                  TeamId = t.Id,
                                  TeamName = t.TName,
                                  TeamLocation = t.TLocation
                              }).ToListAsync();
            }
            return null;
        }

        public async Task UpdatePlayer(Player player)
        {
            if (db != null)
            {
                db.Players.Update(player);
                await db.SaveChangesAsync();
            }
        }

        public async Task UpdateTeam(Team team)
        {

            if (db != null)
            {
                db.Teams.Update(team);
                await db.SaveChangesAsync();
            }
        }

            
    }
}
