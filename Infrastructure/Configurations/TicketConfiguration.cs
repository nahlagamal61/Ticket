﻿namespace Infrastructure.Configurations
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
                .HasComputedColumnSql("GETDATE()");
            
            builder.Property(t => t.TicketStatus)
                .HasDefaultValue(TicketStatus.Unhandled);
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
                    CreationDateTime = DateTime.Now,
                    ManualCreationDateTime = DateTime.Now,
                    PhoneNumber = "+201234567890",
                    Governorate = Governorate.Cairo,
                    City = City.CairoCity,
                    District = "Nasr City",
                    TicketStatus = TicketStatus.Handled
                },
                new Ticket
                {
                    ID = 2,
                    Description = "Consectetur adipiscing elit",
                    CreationDateTime = DateTime.Now.AddDays(-2),
                    ManualCreationDateTime = DateTime.Now,
                    PhoneNumber = "9876543210",
                    Governorate = Governorate.Giza,
                    City = City.GizaCity,
                    District = "Eldoqi",
                    TicketStatus = TicketStatus.Unhandled
                },
                new Ticket
                {
                    ID = 3,
                    Description = "Sed do eiusmod tempor incididunt",
                    CreationDateTime = DateTime.Now.AddDays(-3),
                    ManualCreationDateTime = DateTime.Now,
                    PhoneNumber = "+20999999999",
                    Governorate = Governorate.Giza,
                    City = City.GizaCity,
                    District = "Dokki",
                    TicketStatus = TicketStatus.Unhandled
                },
                new Ticket
                {
                    ID = 4,
                    Description = "Ut labore et dolore magna aliqua",
                    CreationDateTime = DateTime.Now.AddDays(-4),
                    ManualCreationDateTime = DateTime.Now,
                    PhoneNumber = "+20999999999",
                    Governorate = Governorate.Luxor,
                    City = City.Damanhur,
                    District = "Luxor City",
                    TicketStatus = TicketStatus.Handled
                },
                new Ticket
                {
                    ID = 5,
                    Description = "Excepteur sint occaecat cupidatat non proident",
                    CreationDateTime = DateTime.Now.AddDays(-5),
                    ManualCreationDateTime = DateTime.Now,
                    PhoneNumber = "+20111111111",
                    Governorate = Governorate.Cairo,
                    City = City.Helwan,
                    District = "Helewam",
                    TicketStatus = TicketStatus.Unhandled
                },
                };

            return tickets;
        }
    }
}
