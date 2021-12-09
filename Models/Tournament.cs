using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace FinalProject.Models
{
    public class Tournament
    {
        public int TournamentID {get; set;} // PK

        
        [Display(Name = "Tournament Name")]
        [Required]
        public string TournamentName {get; set;}

        
        [Display(Name = "Tournament Game")]
        [Required]
        public string TournamentGame {get; set;}

        
        [Display(Name = "Start Date")]
        [Required]
        public DateTime StartDate {get; set;}

        
        [Display(Name = "Tournament Details")]
        [Required]
        public string TournamentDetails {get; set;}

        public List<PlayerTournament> PlayerTournaments {get; set;} // Navigation Property. Tournament can have MANY PlayerTournaments
    }

    public class PlayerTournament
    {
        public int TournamentID {get; set;} // Composite PK, FK1
        public int PlayerID {get; set;} // Composite PK, FK2
        public Player Player {get; set;} // Navigation Property. 1 Player to 1 PlayerTournament
        public Tournament Tournament {get; set;} // Navigation Property. 1 Tournament to 1 PlayerTournament
    }
}