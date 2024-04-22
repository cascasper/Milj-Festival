﻿using Microsoft.AspNetCore.Mvc;
using Server.Models;
using Microsoft.AspNetCore.Cors;
using MiljøFestivalv2.Shared;
using System.Diagnostics;

namespace Server.Controllers
{
    // Angiver klassen er en API controller
    [ApiController]

    // Rute til denne controller
    [Route("api/bookinger")]
    public class BookingController : ControllerBase
    {
        // Privat instans af IBookingRepository
        private IBookingRepository BookingRepo;

        // Constructor til BookingController, som initialiserer BookingRepo med den injicerede IBookingRepository
        public BookingController(IBookingRepository BookRepo)
        {
            BookingRepo = BookRepo;
        }

        
        [EnableCors("policy")]
        // Definerer en HTTP GET-metode sætter URL'en
        [HttpGet("hentallebookinger")]
        public async Task<IEnumerable<Booking>> HentAlleBookinger()
        {
            return await BookingRepo.HentAlleBookinger();
        }

        [EnableCors("policy")]
        [HttpGet("hentbookingerforbruger/{BrugerId}")]
        public async Task<IEnumerable<Booking>> HentBookingerForBruger(int BrugerId)
        {
            Console.WriteLine(BrugerId);
            return await BookingRepo.HentBookingerForBruger(BrugerId);
        }

        [EnableCors("policy")]
        // Definerer en HTTP POST-metode sætter URL'en
        [HttpPost("opretbooking")]
        public async Task<IActionResult> OpretBooking([FromBody] BookingSql Booking)
        {
            // Kører en Try/catch exception der prøver at køre koden og hvis den finder en fejl printer den fejlBeskeden i konsollen. 
            try
            {
                await BookingRepo.OpretBooking(Booking);
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [EnableCors("policy")]
        // Definerer en HTTP PUT-metode sætter URL'en
        [HttpPut("skiftstatus/{BookingId}")]
        public async Task<IActionResult> SkiftLåsStatus(int BookingId)
        {
            try
            {
                await BookingRepo.SkiftLåsStatus(BookingId);
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [EnableCors("policy")]
        // Definerer en HTTP DELETE-metode sætter URL'en
        [HttpDelete("slet/{BookingId}")]
        public async Task SletBooking(int BookingId)
        {
            Booking booking = await BookingRepo.HentBookingSingle(BookingId);
            await BookingRepo.SletBooking(BookingId);
        }
    }
}
