using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using SGuF.Domain.Enities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SGuF.Infra.Mapping
{
    public class UserLikeMapping : IEntityTypeConfiguration<UserLike>
    {
        public void Configure(EntityTypeBuilder<UserLike> builder)
        {
            builder.HasKey(keyExpression: p => p.Id);

            builder
                .HasOne(x => x.User)
                .WithMany(x => x.UserLikes)
                .HasForeignKey(x => x.UserId);

            builder
                .HasOne(x => x.Photo)
                .WithMany(x => x.UserLikes)
                .HasForeignKey(x => x.PhotoId);
        }
    }
    
    
}
