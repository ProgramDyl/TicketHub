using Azure.Storage.Queues;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace TicketHub.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [EnableCors("AllowAzureStaticWebApp")]
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
        public async Task<IActionResult> Post(Ticket ticket)
        {
            //validate ticket
            if (ModelState.IsValid == false)
            {
                return BadRequest(ModelState);
            }

            //post message to azure storage queue
            string queueName = "tickets";

            string? connectionString = _configuration["AzureStorageConnectionString"];

            if (string.IsNullOrEmpty(connectionString))
            {
                return BadRequest("An error has occurred. ");
            }

            QueueClient queueClient = new QueueClient(connectionString, queueName);

            //serialize an object to json
            string message = JsonSerializer.Serialize(ticket);

            ////send string msg to queue
            await queueClient.SendMessageAsync(ticket.Email + " purchased: " + ticket.Quantity + " tickets to: " + ticket.ConcertId);



            var planTextBytes = Encoding.UTF8.GetBytes(message);
            await queueClient.SendMessageAsync(Convert.ToBase64String(planTextBytes));

            return Ok($"""
                ==== TICKET PURCHASE RECEIPT ====

                Customer Information:
                Name: {ticket.Name}
                Email: {ticket.Email}
                Phone: {ticket.Phone}

                Event Information:
                Concert ID: {ticket.ConcertId}
                Quantity: {ticket.Quantity}

                Delivery Address:
                Address: {ticket.Address}
                City: {ticket.City}
                {ticket.PostalCode}
                {ticket.Country}

                Payment Information:
                Card: {ticket.CreditCard}
                Expires: {ticket.Expiration}

                ==================================
                Thank you for your purchase, {ticket.Name}!
                A confirmation email has been sent to {ticket.Email}.
                """);
        }

            

    }






    }
