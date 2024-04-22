﻿using System.ComponentModel.DataAnnotations;

namespace MiljøFestivalv2.Shared
{
	public class Bruger
	{
        // Fjerner minutter og sekunder fra fødselsdag, bruges i klienten
        public DateOnly GetFødselsdag() 
        {
            return DateOnly.FromDateTime(this.fødselsdag);
        }
        public int bruger_id { get; set; }
       
        public string rolle { get; set; } = "";
        public string fulde_navn { get; set; }
        public string email { get; set; }                                                                       
        // Gør telefon nummer til den kun kan have 8 cifre lang
        [Required(ErrorMessage = "Telefon nummer er påkrævet")]
        [RegularExpression(@"^\d{8}$", ErrorMessage = "Telefon nummer skal være 8 cifre langt")]
        public int telefon_nummer { get; set; } = 0;
        public DateTime fødselsdag { get; set; }
        //Requirement på CPR nummer mht længde
        [Required(ErrorMessage = "CPR-nummer er påkrævet")]
        [StringLength(10, MinimumLength = 10, ErrorMessage = "CPRnummer skal være præcis 10 cifre langt og uden bindestreg")]
        public string cpr_nummer { get; set; }
        //Requirement til brugernavn, så det ikke må være tomt
        [Required(ErrorMessage = "Brugernavn er påkrævet")]
        public string brugernavn { get; set; }
        // Gør password skal have mindst et stort bogstav og et tal
        [Required(ErrorMessage = "Password er påkrævet")]
        [RegularExpression(@"^(?=.*[A-Z])(?=.*\d).+$", ErrorMessage = "Password skal have mindst ét stort bogstav og ét tal")]
        public string password { get; set; }
        public bool er_aktiv { get; set; } = true;
        public bool er_blacklistet { get; set; } = false;
        public int dine_point { get; set; }
    }
}

