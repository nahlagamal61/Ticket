namespace Domains.Entities
{
    using Domains.Enums;
    using System;
    using System.ComponentModel.DataAnnotations;

    public class Ticket
    {
       
        public int ID { get; set; }
        public string Description { get; set; }
        public DateTime CreationDateTime { get; set; }
        public DateTime ManualCreationDateTime { get; set; }
        [RegularExpression(@"^\+20\d{10}$", ErrorMessage = "Invalid mobile number format")]
        public string PhoneNumber { get; set; }

        public Governorate Governorate { get; set; }
        public City City { get; set; }
        public string District { get; set; }
        public TicketStatus TicketStatus { get; set; }
    }
    
}
