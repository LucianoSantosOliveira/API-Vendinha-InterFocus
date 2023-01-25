using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using API_Vendinha_InterFocus.Model;
using Microsoft.Extensions.Hosting;

namespace API_Vendinha_InterFocus.Data
{
    public class API_Vendinha_InterFocusContext : DbContext
    {
        public API_Vendinha_InterFocusContext (DbContextOptions<API_Vendinha_InterFocusContext> options)
            : base(options)
        {
        }

        public DbSet<API_Vendinha_InterFocus.Model.Cliente> Cliente { get; set; } = default!;

        public DbSet<API_Vendinha_InterFocus.Model.Divida> Divida { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Divida>()
                .HasOne(p => p.Cliente)
                .WithMany(b => b.Dividas)
                .HasForeignKey(b => b.ClienteId);
        }
    }
}
