using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace FinalProject.Models
{
    public class Tournament
    {
        public int TournamentID {get; set;} // PK

        [Required]
        [Display(Name = "Tournament Name")]
        public string TournamentName {get; set;}

        [Required]
        [Display(Name = "Tournament Game")]
        public string TournamentGame {get; set;}

        [Required]
        [Display(Name = "Start Date")]
        public DateTime StartDate {get; set;}

        [Required]
        [Display(Name = "Tournament Details")]
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