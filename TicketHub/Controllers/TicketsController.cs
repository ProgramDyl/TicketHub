using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace TicketHub.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TicketsController : ControllerBase
    {
        private readonly ILogger<TicketsController> _logger;
        private readonly IConfiguration _configuration;

        public TicketsController(ILogger<TicketsController> logger, IConfiguration configuration)
        {
            _logger = logger;
            _configuration = configuration;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok("Welcome to TicketHub! - GET");
        }

        [HttpPost]
        public IActionResult Post(Ticket ticket)
        {

            ////validate contact
            //if (string.IsNullOrEmpty(ticket.CustomerName))
            //{
            //    return BadRequest("Invalid name");
            //}

            //if (int.IsNegative(ticket.concertId))
            //{
            //    return BadRequest("Invalid Ticket Number");
            //}

            if (ModelState.IsValid)
            {
                return Ok("Hello " + ticket.Name + "," + "thank you for purchasing a ticket for " + ticket.ConcertId + " from TicketHub! - POST");
            }
            else
            {
                return BadRequest("Invalid ticket");
            }
        }






    }
}
