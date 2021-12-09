using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace FinalProject.Models
{
    public class Player
    {
        public int PlayerID {get; set;} // PK

        
        [Display(Name = "User Name")]
        [Required]
        public string UserName {get; set;}

        [Display(Name = "Player Bio")]
        public string PlayerBio {get; set;}

        // Note: This property replaces GamesAttached in my original concept design.
        [Display(Name = "Favorite Game")]
        public string FavoriteGame {get; set;}

        // Navigation Property. Players can enroll in MANY PlayerTournaments
        public List<PlayerTournament> PlayerTournaments {get; set;}

        
    }
}