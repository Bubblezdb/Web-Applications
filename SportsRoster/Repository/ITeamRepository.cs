using SportsRoster.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SportsRoster.Repository
{
    public interface ITeamRepository
    {
        //Properties to gather all the data from each class.

        //Player Functions
        //Add Player
        Task<int> AddPlayer(Player player);
        //Update Player
        Task UpdatePlayer(Player player);
        //Delete Player
        Task<int> DeletePlayerByID(int? id);
        //Return All Players
        Task<List<Player>> GetAllPlayers();
        //Search Player by LName
        Task<List<TeamRoster>> GetPlayerByLastName(string? lName); //gets players by lastname and assigning it to the view model
        //Search Player by Team 
        Task<List<TeamRoster>> GetPlayerByTeam(string? tName);
        //Search Player by ID
        Task<TeamRoster> GetPlayerByID(int? id);
        //Team Functions
        //AddTeam
        Task<int> AddTeam(Team team);
        //Update Team
        Task UpdateTeam(Team team);
        //Delete Team
        Task<int> DeleteTeamByID(int? id);
        //Return all Teams
        Task<List<Team>> GetAllTeams();
        //Search Team by Location
        Task<List<TeamRoster>> GetTeamsByLocation(string? tLocation);
        //Search Team by ID
        Task<TeamRoster> GetTeamByID(int? id);
        
    }
}
