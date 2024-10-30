using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SGuF.Domain.Enities;
using SGuF.Domain.Enities.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace SGuF.Infra.Context
{
    public class SGuFDbContext : IdentityDbContext<AppUser>
    {
        public SGuFDbContext(DbContextOptions<SGuFDbContext> options) : base(options)  
        {
            
        }

        public DbSet<UserLike> UserLikes { get; set; }
        public DbSet<Photo> Photos { get; set; }


        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfigurationsFromAssembly(typeof(SGuFDbContext).Assembly);

            foreach (var relationship in builder.Model.GetEntityTypes().SelectMany(e => e.GetForeignKeys())) relationship.DeleteBehavior = DeleteBehavior.ClientSetNull;

            base.OnModelCreating(builder);
        }
    }
}
