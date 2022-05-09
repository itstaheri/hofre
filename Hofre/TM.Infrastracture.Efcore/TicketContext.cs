using Microsoft.EntityFrameworkCore;
using System;
using TM.Domain.Ticket;
using TM.Infrastracture.Efcore.Mappings;

namespace TM.Infrastracture.Efcore
{
    public class TicketContext : DbContext
    {
        public TicketContext(DbContextOptions<TicketContext> options) : base(options)
        {

        }
        public DbSet<TicketModel> tickets { get; set; }
        public DbSet<MessageModel> messages { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new TicketMapp());
            builder.ApplyConfiguration(new MessageMapp());
            base.OnModelCreating(builder);
        }
    }
}
