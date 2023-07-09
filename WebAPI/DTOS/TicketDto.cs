namespace WebAPI.DTOS
{
    using Domains.Enums;
    using System.ComponentModel.DataAnnotations;

    public class TicketDto
    {
        [Required]
        public string Description { get; set; }
        [Required]
        [RegularExpression(@"^\+20\d{10}$", ErrorMessage = "Invalid mobile number format")]
        public string PhoneNumber { get; set; }

        [Required]
        public Governorate Governorate { get; set; }
        [Required]
        public City City { get; set; }
        [Required]
        public string District { get; set; }
    }

    public class TickerResDTO
    {
        public int ID { get; set; }
        public string Description { get; set; }
        public DateTime CreationDateTime { get; set; }
        public string PhoneNumber { get; set; }
        public string GovernorateName { get; set; }
        public string CityName { get; set; }
        public string District { get; set; }
        public TicketStatus TicketStatus { get; set; }
    
    }
}
