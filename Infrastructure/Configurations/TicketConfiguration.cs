namespace Infrastructure.Configurations
{
    using Domains.Entities;
    using Domains.Enums;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using System.Data.SqlTypes;

    public class TicketConfiguration : IEntityTypeConfiguration<Ticket>
    {
        public void Configure(EntityTypeBuilder<Ticket> builder)
        {

            builder.Property(t => t.Description)
                .IsRequired()
                .HasMaxLength(200);
            builder.Property(t => t.PhoneNumber)
                .IsRequired();
            builder.Property(t => t.Governorate)
                .IsRequired();
            builder.Property(t => t.City)
                .IsRequired();
            builder.Property(t => t.District)
                .IsRequired();
            builder.Property(t => t.CreationDateTime)
                .HasComputedColumnSql("GETUTCDATE()")
                .ValueGeneratedOnAdd();
            builder.Property(t => t.TicketStatus)
                .HasDefaultValue(TicketStatus.Unhandeled);
            builder.HasData(CreateSeedingData());
            
        }

        public static List<Ticket> CreateSeedingData()
        {
            List<Ticket> tickets = new List<Ticket>()
            {
                new Ticket
                {
                    ID = 1,
                    Description = "Lorem ipsum dolor sit amet",
                    CreationDateTime = DateTime.Now.AddDays(-1),
                    PhoneNumber = "1234567890",
                    Governorate = Governorate.Cairo,
                    City = City.Cairo,
                    District = "Nasr City",
                    TicketStatus = TicketStatus.Handled
                },
                new Ticket
                {
                    ID = 2,
                    Description = "Consectetur adipiscing elit",
                    CreationDateTime = DateTime.Now.AddDays(-2),
                    PhoneNumber = "9876543210",
                    Governorate = Governorate.Alexandria,
                    City = City.Alexandria,
                    District = "Roushdy",
                    TicketStatus = TicketStatus.Unhandeled
                },
                new Ticket
                {
                    ID = 3,
                    Description = "Sed do eiusmod tempor incididunt",
                    CreationDateTime = DateTime.Now.AddDays(-3),
                    PhoneNumber = "5555555555",
                    Governorate = Governorate.Giza,
                    City = City.Giza,
                    District = "Dokki",
                    TicketStatus = TicketStatus.Unhandeled
                },
                new Ticket
                {
                    ID = 4,
                    Description = "Ut labore et dolore magna aliqua",
                    CreationDateTime = DateTime.Now.AddDays(-4),
                    PhoneNumber = "9999999999",
                    Governorate = Governorate.Luxor,
                    City = City.Luxor,
                    District = "Luxor City",
                    TicketStatus = TicketStatus.Handled
                },
                new Ticket
                {
                    ID = 5,
                    Description = "Excepteur sint occaecat cupidatat non proident",
                    CreationDateTime = DateTime.Now.AddDays(-5),
                    PhoneNumber = "1111111111",
                    Governorate = Governorate.Asyut,
                    City = City.Asyut,
                    District = "Asyut Center",
                    TicketStatus = TicketStatus.Unhandeled
                },
                };

            return tickets;
        }
    }
}
