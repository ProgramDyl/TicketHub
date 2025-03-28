using System.ComponentModel.DataAnnotations;

namespace TicketHub
{
    public class Ticket
    {

        [Required(ErrorMessage = "ConcertID is required.")]
        [Range(1, int.MaxValue, ErrorMessage = "ConcertID must be greater than 0.")]
        public int ConcertId { get; set; }

        [EmailAddress]
        [Required(ErrorMessage = "A valid email is required to proceed.")]
        [RegularExpression(@"^[^@\s]+@[^@\s]+\.[^@\s]+$", ErrorMessage = "Please enter a valid email address.")]
        public string Email { get; set; } = string.Empty;


        [StringLength(50)]
        [Required(ErrorMessage = "Your name is required for the ticket purchase.")]
        public string Name { get; set; } = string.Empty;


        [Phone(ErrorMessage = "Please enter a valid phone number.")]
        [Required(ErrorMessage = "Phone number is required.")]
        [RegularExpression(@"^[+]?[(]?[0-9]{1,4}[)]?[-\s./0-9]*$",
        ErrorMessage = "Invalid phone number format.")]
        public string Phone { get; set; }


        [Required(ErrorMessage = "The number of tickets you need to buy is required!")]
        [Range(1, 10, ErrorMessage = "Customers are eligible to purchase up to 10 tickets per order.")] //customer can only purchase 10 tickets at a time
        public int Quantity { get; set; }


        [CreditCard(ErrorMessage = "Please enter a valid credit card number.")]
        [Required(ErrorMessage = "Credit card number is required.")]
        public string CreditCard { get; set; } = string.Empty;


        [Required(ErrorMessage = "Expiration date is required.")]
        public string Expiration { get; set; } = string.Empty;


        [Required(ErrorMessage = "CVV is required.")]
        [RegularExpression(@"^\d{3,4}$", ErrorMessage = "CVV must be 3 or 4 digits.")]
        public string Cvv { get; set; } = string.Empty;


        [Required(ErrorMessage = "An address is required for ticket purchase.")]
        [StringLength(75, MinimumLength = 5, ErrorMessage = "Address must be between 5 and 75 characters.")]
        public string Address { get; set; } = string.Empty;


        [Required(ErrorMessage = "City is required.")]
        public string City { get; set; } = string.Empty;


        [Required(ErrorMessage = "Province is required.")]
        [RegularExpression(@"^(AB|BC|MB|NB|NL|NS|NT|NU|ON|PE|QC|SK|YT)$", ErrorMessage = "Please enter a valid province code.")]
        public string Province { get; set; } = string.Empty;


        [Required(ErrorMessage = "Postal code is required.")]
        public string PostalCode { get; set; } = string.Empty;

         
        [Required(ErrorMessage = "Country is required.")]
        public string Country { get; set; } = string.Empty;

    }
}
