using Microsoft.EntityFrameworkCore;
using SM.Domain;
using System;

namespace SM.Infrastracture.Efcore
{
    public class SettingContext : DbContext
    {
        public SettingContext(DbContextOptions<SettingContext> options) : base(options)
        {

        }
        public DbSet<SettingModel> setting { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {

            base.OnModelCreating(builder);
        }
    }
}
