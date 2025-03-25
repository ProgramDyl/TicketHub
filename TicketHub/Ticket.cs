using System.ComponentModel.DataAnnotations;

namespace TicketHub
{
    public class Ticket
    {

        [Required(ErrorMessage = "ConcertID is required.")]
        [Range(1, int.MaxValue, ErrorMessage = "ConcertID must be greater than 0.")]
        public int ConcertId { get; set; }
        
        //[EmailAddress]
        //[Required(ErrorMessage = "A valid email is required.")]
        //public string Email { get; set; } = string.Empty;

        [MaxLength(20)]
        [Required(ErrorMessage = "Your name is required for the ticket purchase.")]
        public string Name { get; set; } = string.Empty;

        //[Phone]
        //[Required(ErrorMessage = "Phone number is required.")]
        //public int Phone { get; set; }

        //[Required(ErrorMessage = "The number of tickets you need to buy is required!")]
        //public int Quantity { get; set; }

        //[CreditCard]
        //[Required(ErrorMessage = "Credit card number is required.")]
        //public string CreditCard { get; set; } = string.Empty;

        //[Required(ErrorMessage = "Expiration date is required.")]
        //public string Expiration { get; set; } = string.Empty;

        //[Required(ErrorMessage = "CVV is required.")]
        //public string Cvv { get; set; } = string.Empty;

        //[Required(ErrorMessage = "Address is required.")]
        //public string Address { get; set; } = string.Empty;

        //[Required(ErrorMessage = "City is required.")]
        //public string City { get; set; } = string.Empty;

        //[Required(ErrorMessage = "Province is required.")]
        //public string Province { get; set; } = string.Empty;

        //[Required(ErrorMessage = "Postal code is required.")]
        //public string PostalCode { get; set; } = string.Empty;

        //[Required(ErrorMessage = "Country is required.")]
        //public string Country { get; set; } = string.Empty;
        
    }
}
