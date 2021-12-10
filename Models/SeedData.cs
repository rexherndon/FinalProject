using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;

namespace FinalProject.Models
{
    public static class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new Context(serviceProvider.GetRequiredService<DbContextOptions<Context>>()))
            {
                if (context.Player.Any())
                {
                    return;
                }

                List<Player> Players = new List<Player> {
                    new Player {
                        UserName="basicallyimrex", 
                        PlayerBio="Climbing to 3600 in Overwatch. Let's grind!", 
                        FavoriteGame="Overwatch"},
                    new Player {
                        UserName="mightfail15", 
                        PlayerBio="Just trying to climb with some homies.", 
                        FavoriteGame="League of Legends"},
                    new Player {
                        UserName="fallen_philosopher", 
                        PlayerBio="Radiant in Valorant. Jett one-trick", 
                        FavoriteGame="Valorant"},
                    new Player {
                        UserName="ByronasaurusRex", 
                        PlayerBio="git gud", 
                        FavoriteGame="Valorant"},
                    new Player {
                        UserName="Kong", 
                        PlayerBio="Insert Creative Bio Here", 
                        FavoriteGame="League of Legends"},
                    new Player {
                        UserName="jhman99", 
                        PlayerBio="Still waiting for Tarkov E-Sports smh", 
                        FavoriteGame="Rust"},
                    new Player {
                        UserName="Xperfection457", 
                        PlayerBio="WHAT DAY IS IT??", 
                        FavoriteGame="Battlefield 2042"},
                    new Player {
                        UserName="beeW", 
                        PlayerBio="1v1 me in Cuphead", 
                        FavoriteGame="Counter Strike: Global Offensive"},
                    new Player {
                        UserName="party_rocker_12", 
                        PlayerBio="bring back LMFAO please", 
                        FavoriteGame="Overwatch"},
                    new Player {
                        UserName="AL3X MARL3Y", 
                        PlayerBio="git gud", 
                        FavoriteGame="Counter Strike: Global Offensive"},
                    new Player {
                        UserName="jess", 
                        PlayerBio="Favorite Anime: Sword Art Online", 
                        FavoriteGame="Dota 2"},
                    new Player {
                        UserName="Logiebear", 
                        PlayerBio="git gud", 
                        FavoriteGame="Battlefield 2042"},
                    new Player {
                        UserName="Fatigue", 
                        PlayerBio="I'll try league out, it can't possibly be that bad right?", 
                        FavoriteGame="League of Legends"},
                    new Player {
                        UserName="Nightbaron21", 
                        PlayerBio="Vibin in greece rn, dont @me", 
                        FavoriteGame="Overwatch"},
                    new Player {
                        UserName="Rice Bowl", 
                        PlayerBio="stressed and depressed", 
                        FavoriteGame="League of Legends"},
                    new Player {
                        UserName="DeyCallMeJuan23", 
                        PlayerBio="git gud", 
                        FavoriteGame="Valorant"},
                    new Player {
                        UserName="Tower", 
                        PlayerBio="rip WoW fr man", 
                        FavoriteGame="Final Fantasy XIV"},
                    new Player {
                        UserName="D2Mowhawk", 
                        PlayerBio="who's candice?", 
                        FavoriteGame="Hotline Miami"},
                    new Player {
                        UserName="JCOALE", 
                        PlayerBio="soccer car go brrrr", 
                        FavoriteGame="Rocket League"},
                    new Player {
                        UserName="MediaCowboy", 
                        PlayerBio="git gud", 
                        FavoriteGame="Pac-Man"},
                    new Player {
                        UserName="OneHokage", 
                        PlayerBio="why did they add naruto in fortnite", 
                        FavoriteGame="Fortnite"},
                    new Player {
                        UserName="INFAMOUS", 
                        PlayerBio="don't check my spotify", 
                        FavoriteGame="Overwatch"},
                    new Player {
                        UserName="Natee", 
                        PlayerBio="y'all are the real MVP's", 
                        FavoriteGame="Overwatch"},
                    new Player {
                        UserName="cathasabucket", 
                        PlayerBio="Vice President for Buff Gaming/WTAMU Esports. Senior Strategic Comm major/Management minor. She/Her/Hers.", 
                        FavoriteGame="League of Legends"},
                    new Player {
                        UserName="StrawMaster", 
                        PlayerBio="git gud", 
                        FavoriteGame="Rust"},
                    new Player {
                        UserName="Cathardic", 
                        PlayerBio="FROG MAN MAIN", 
                        FavoriteGame="Overwatch"},
                    new Player {
                        UserName="ChrisBy", 
                        PlayerBio="Master Chief, more like Master Beef", 
                        FavoriteGame="Halo: Infinite"},
                    new Player {
                        UserName="TonyynoT13", 
                        PlayerBio="no toof tony reporting for duty", 
                        FavoriteGame="Rainbow Six: Siege"},
                    new Player {
                        UserName="chlomoney", 
                        PlayerBio="i only put minecraft cause WIZARD 101 WASNT ON THE LIST", 
                        FavoriteGame="Minecraft"},

                    // Inital seed count: 29
                };
                context.AddRange(Players);

                List<Tournament> Tournaments = new List<Tournament> {
                    new Tournament {
                        TournamentName="Winter 2021: Metrowest League - Fortnite 2v2", 
                        TournamentGame="Fortnite", 
                        StartDate= new DateTime(12/17/2021), 
                        TournamentDetails="Drop off the battlebus and compete for Vbucks in this exciting Duos Fortnite League with your friend! Do you and your friend have what it takes to earn victory? This is a league for players in teams of two. Each week, players in teams of two will participate in a custom lobby of up to 100 players for the battle royale. Players will receive points based on kills and placement they receive in the competition. There will be one winner each week."},
                    new Tournament {
                        TournamentName="Winter 2021: Metrowest League - Rocket League Advanced 3v3", 
                        TournamentGame="Rocket League", 
                        StartDate= new DateTime(12/18/2021), 
                        TournamentDetails="Grab your friends, and come battle it out with others in your community for this Rocket League 3v3 League! This league is intended for more competitive players, who are gold and above in comp. The league will have a 6 week regular season and a 2 week playoffs. Players will need to have Rocket League downloaded, and a device to play on (Xbox, Playstation, PC, or Switch)."},
                    new Tournament {
                        TournamentName="Winter 2021: Metrowest League - Fortnite 1v1", 
                        TournamentGame="Fortnite", 
                        StartDate= new DateTime(12/19/2021), 
                        TournamentDetails="Drop off the battlebus and compete for Vbucks in this exciting Solos Fortnite League! Do you have what it takes to climb to the top amongst 100 other players? Each week, players will participate in a custom lobby up to 100 players for the battle royale. Players will receive points based on kills and placement they receive in the competition and there will be one winner each week. Players must have Fortnite downloaded on a compatible device (PC or console)."},
                    new Tournament {
                        TournamentName="Texas Winter 2021", 
                        TournamentGame="Overwatch", 
                        StartDate= new DateTime(12/20/2021), 
                        TournamentDetails="Texas league for Collegiate Overwatch players. Games start the week of 12/20 and will be Monday nights at 9 pm CT."},
                    new Tournament {
                        TournamentName="Pacific Valorant Division A", 
                        TournamentGame="Valorant", 
                        StartDate= new DateTime(12/21/2021), 
                        TournamentDetails="Online Valorant league for players in the Pacific time zone. Games start 12/21 and will be Tuesday evenings at 8 PM Pacific Time. This is our most competitive league with an average team rank of Diamond+. There will be no skill cap. The regular season will be a 7-week round-robin with the top 8 teams qualifying for playoffs. All matches in the regular season will be a best of 1, while all matches in the playoffs will be a best of 3 games. 25% of the this league's entry fees will go towards prizing!"},
                    new Tournament {
                        TournamentName="Pacific Valorant Division B", 
                        TournamentGame="Valorant", 
                        StartDate= new DateTime(12/22/2021), 
                        TournamentDetails="This is a moderately competitive league with an average team rank of Platinum. Players ranked Diamond 1 or above at the start of the season will not be allowed on any team in this league. The regular season will be a 7-week round-robin with the top 8 teams qualifying for playoffs. "},
                    new Tournament {
                        TournamentName="Pacific Valorant Division C", 
                        TournamentGame="Valorant", 
                        StartDate= new DateTime(12/23/2021), 
                        TournamentDetails="This is an average competitive league with an average team rank of Gold. Players ranked Platinum 1 or above at the start of the season will not be allowed on any team in this league. The regular season will be a 7-week round-robin with the top 8 teams qualifying for playoffs. All matches in the regular season will be a best of 1, while all matches in the playoffs will be a best of 3 games."},
                    new Tournament {
                        TournamentName="California Rec League - Valorant Division A", 
                        TournamentGame="Valorant", 
                        StartDate= new DateTime(12/24/2021), 
                        TournamentDetails="This is a moderately competitive league with an average team rank of Diamond. Players ranked above Radiant at the start of the season will not be allowed on any team in this league. The league will have a 5 week regular season and 1 day playoff. All matches in the regular season will be a best of 1, while all matches in the playoffs will be a best of 3 games."},
                    new Tournament {
                        TournamentName="California Rec League - Valorant Division B", 
                        TournamentGame="Valorant", 
                        StartDate= new DateTime(12/25/2021), 
                        TournamentDetails="This is a moderately competitive league with an average team rank of Gold. Players ranked above Platinum at the start of the season will not be allowed on any team in this league. The league will have a 5 week regular season and 1 day playoff. All matches in the regular season will be a best of 1, while all matches in the playoffs will be a best of 3 games."},
                    new Tournament {
                        TournamentName="California Rec League - Valorant Division C", 
                        TournamentGame="Valorant", 
                        StartDate= new DateTime(12/26/2021), 
                        TournamentDetails="This is a moderately competitive league with an average team rank of Platinum. Players ranked above Diamond at the start of the season will not be allowed on any team in this league. The league will have a 5 week regular season and 1 day playoff. All matches in the regular season will be a best of 1, while all matches in the playoffs will be a best of 3 games."},
                    new Tournament {
                        TournamentName="Texas Esports League: COD Warzone", 
                        TournamentGame="Call of Duty: Modern Warfare", 
                        StartDate= new DateTime(12/27/2021), 
                        TournamentDetails="Gear up for this Call of Duty Warzone league! We have tournaments available for solos, duos, and squads. Grand Prize will be $1000 split among the team members."},
                    new Tournament {
                        TournamentName="Virginia Esports League - Warzone", 
                        TournamentGame="Call of Duty: Modern Warfare", 
                        StartDate= new DateTime(12/28/2021), 
                        TournamentDetails="Gear up for this Call of Duty Warzone league! We have tournaments available for solos, duos, and squads. Grand Prize will be $1000 split among the team members."},
                    new Tournament {
                        TournamentName="Vermont Esports League - Call Of Duty 2v2", 
                        TournamentGame="Call of Duty: Modern Warfare", 
                        StartDate= new DateTime(12/29/2021), 
                        TournamentDetails="Gear up for this exciting Call of Duty: Black Ops Tournament! This will be a 2v2 format, BO3. This league will run for 6 weeks - 5 weeks for the regular season, and 1 week for playoffs. Winning teams will receive a gift card for the console of their choice."},
                    new Tournament {
                        TournamentName="Iowa - Division B", 
                        TournamentGame="League of Legends", 
                        StartDate= new DateTime(12/30/2021), 
                        TournamentDetails="Iowa league for Collegiate League of Legends players. This league is for high skill players with an average skill level of Gold/Plat, and players will be capped at Diamond. Finals will be held in Iowa, exact location TBD."},
                    new Tournament {
                        TournamentName="Michigan - Division B", 
                        TournamentGame="League of Legends", 
                        StartDate= new DateTime(12/31/2021), 
                        TournamentDetails="Michigan league for Collegiate League of Legends players. This league is for high skill players with an average skill level of Gold/Plat, and players will be capped at Diamond. Finals will be held in Michigan, exact location TBD."},
                    new Tournament {
                        TournamentName="Northern Illinois - Division B", 
                        TournamentGame="League of Legends", 
                        StartDate= new DateTime(1/1/2021), 
                        TournamentDetails="Illinois league for Collegiate League of Legends players. This league is for high skill players with an average skill level of Gold/Plat, and players will be capped at Diamond. Finals will be held in Chicago, exact location TBD."},
                    new Tournament {
                        TournamentName="Southern Illinois - Division B", 
                        TournamentGame="League of Legends", 
                        StartDate= new DateTime(1/2/2021), 
                        TournamentDetails="Illinois league for Collegiate League of Legends players. This league is for high skill players with an average skill level of Gold/Plat, and players will be capped at Diamond. Finals will be held in Chicago, exact location TBD."},
                    new Tournament {
                        TournamentName="Iowa - Division C", 
                        TournamentGame="League of Legends", 
                        StartDate= new DateTime(1/3/2021), 
                        TournamentDetails="Iowa league for Collegiate League of Legends players. This league is for moderately skilled players with an average skill level of Gold, and players will be capped at Platinum. Finals will be held in Iowa, exact location TBD."},
                    new Tournament {
                        TournamentName="Illinois - Division C", 
                        TournamentGame="League of Legends", 
                        StartDate= new DateTime(1/4/2021), 
                        TournamentDetails="Illinois league for Collegiate League of Legends players. This league is for moderately skilled players with an average skill level of Gold, and players will be capped at Platinum. Finals will be held in Chicago, exact location TBD."},
                    new Tournament {
                        TournamentName="Michigan - Division C", 
                        TournamentGame="League of Legends", 
                        StartDate= new DateTime(1/5/2021), 
                        TournamentDetails="Michigan league for Collegiate League of Legends players. This league is for moderately skilled players with an average skill level of Gold, and players will be capped at Platinum. Finals will be held in Michigan, exact location TBD."},
                    new Tournament {
                        TournamentName="Amarillo Community Intramurals - Rocket League", 
                        TournamentGame="Rocket League", 
                        StartDate= new DateTime(1/6/2021), 
                        TournamentDetails="Rocket League competition for the Amarillo community. The league will have a 4 week regular season and 2 week playoff. This league is open to all current Amarillo college, West Texas A&M, and nearby high school students and faculty."},
                    new Tournament {
                        TournamentName="Tarleton State University Intramurals - Rocket League", 
                        TournamentGame="Rocket League", 
                        StartDate= new DateTime(1/7/2021), 
                        TournamentDetails="Rocket League competition for the Tarleton State community. The league will have a 4 week regular season and 2 week playoff. This league is open to all current/prospective Tarleton State students, graduates/alumni, and faculty."},
                    new Tournament {
                        TournamentName="University of Houston Intramurals - Rocket League", 
                        TournamentGame="Rocket League", 
                        StartDate= new DateTime(1/8/2021), 
                        TournamentDetails="Rocket League competition for the UH community. The league will have a 4 week regular season and 2 week playoff. This league is open to all current/prospective UH students and faculty."},
                    new Tournament {
                        TournamentName="Echo League Season 4", 
                        TournamentGame="Dota 2", 
                        StartDate= new DateTime(1/9/2021), 
                        TournamentDetails="Echo League is BACK!! We have teamed up with Leagues4Geeks to provide a brand new season, and after a long break it is finally time to put together a team and compete to be an Echo League Champion! After registration closes, teams will be split in to Bo2 round robin groups for a group stage, followed by a single elimination playoff among the top teams! This league will be an open league for any skill levels, with the winner taking home $250 in Steam Gift Cards for their team!"},
                    new Tournament {
                        TournamentName="Beta League", 
                        TournamentGame="Dota 2", 
                        StartDate= new DateTime(1/10/2021), 
                        TournamentDetails="This league does not have a description yet."},
                    new Tournament {
                        TournamentName="Thomasville Fortnite Winter Season", 
                        TournamentGame="Fortnite", 
                        StartDate= new DateTime(1/11/2021), 
                        TournamentDetails="This is a 1v1 Fortnite (cross-platform) competition. Games will be played online. There will be a 5 week regular season with a 1 day playoff for the top 4 teams. For this competition, players will play three games with their opponent as their duo. Whichever player gets the most kills over the course of the three games will win. All players will need the Fortnite game and the ability to play online matches. Please make a team with only yourself listed on the roster to join."},
                    new Tournament {
                        TournamentName="1v1 Fortnite Rec Tournament", 
                        TournamentGame="Fortnite", 
                        StartDate= new DateTime(1/12/2021), 
                        TournamentDetails="his is a free recreational league for 1v1 Fortnite. This is a standalone, single-elimination bracket tournament. All games begin at 11am CT. Open to all players from any region and all skill levels. For this competition players will queue for duos with their opponent for the most points. Details coming soon."},
                    new Tournament {
                        TournamentName="UIC Intramurals - OW", 
                        TournamentGame="Overwatch", 
                        StartDate= new DateTime(1/13/2021), 
                        TournamentDetails="Overwatch competition for the UIC community. Games start 01/13 and will be Thursday evenings at 8:00pm CT. The league will have a 4 week regular season and 2 week playoff. This league is open to all current UIC students."},

                    // Inital seed count: 28
                };
                context.AddRange(Tournaments);

                List<PlayerTournament> Enlisted = new List<PlayerTournament> {
                    new PlayerTournament {Player = Players[0], Tournament = Tournaments[27]},
                    new PlayerTournament {Player = Players[2], Tournament = Tournaments[16]},
                    new PlayerTournament {Player = Players[4], Tournament = Tournaments[8]},
                    new PlayerTournament {Player = Players[0], Tournament = Tournaments[4]},
                    new PlayerTournament {Player = Players[6], Tournament = Tournaments[4]},
                    new PlayerTournament {Player = Players[9], Tournament = Tournaments[4]},
                    new PlayerTournament {Player = Players[11], Tournament = Tournaments[4]},
                    new PlayerTournament {Player = Players[12], Tournament = Tournaments[6]},
                    new PlayerTournament {Player = Players[13], Tournament = Tournaments[6]},

                    new PlayerTournament {Player = Players[2], Tournament = Tournaments[27]},
                    new PlayerTournament {Player = Players[6], Tournament = Tournaments[27]},
                    new PlayerTournament {Player = Players[14], Tournament = Tournaments[4]},
                    new PlayerTournament {Player = Players[15], Tournament = Tournaments[11]},
                    new PlayerTournament {Player = Players[3], Tournament = Tournaments[11]},
                    new PlayerTournament {Player = Players[5], Tournament = Tournaments[13]},
                    new PlayerTournament {Player = Players[18], Tournament = Tournaments[1]},
                    new PlayerTournament {Player = Players[20], Tournament = Tournaments[1]},

                    // Initial Seed Count: 19
                    // new PlayerTournament {Player = Players[0], Tournament = Tournaments[5]},

                };
                context.AddRange(Enlisted);

                context.SaveChanges();

            }
        }
    }
}
