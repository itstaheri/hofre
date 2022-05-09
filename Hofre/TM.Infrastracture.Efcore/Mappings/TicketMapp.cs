using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TM.Domain.Ticket;

namespace TM.Infrastracture.Efcore.Mappings
{
    public class TicketMapp : IEntityTypeConfiguration<TicketModel>
    {
        public void Configure(EntityTypeBuilder<TicketModel> builder)
        {
            builder.HasMany(x=>x.Messages).WithOne(x => x.Ticket).HasForeignKey(x => x.TicketId);
        }
    }
}
