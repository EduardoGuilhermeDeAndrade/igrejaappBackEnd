﻿using igreja.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace igreja.Infrastructure.Data.Configurations
{
    public class FinancialMovementConfiguration : IEntityTypeConfiguration<FinancialMovement>
    {
        public void Configure(EntityTypeBuilder<FinancialMovement> builder)
        {
            builder.HasKey(mv => mv.Id);

            builder.Property(mv => mv.MovementDate)
                   .IsRequired();

            builder.Property(mv => mv.MovementType)
                   .IsRequired()
                   .HasMaxLength(50);

            builder.Property(mv => mv.Description)
                   .HasMaxLength(500);

            builder.HasOne(mv => mv.Temple)
                   .WithMany(t => t.FinancialMovements)
                   .HasForeignKey(mv => mv.TempleId);

            builder.HasOne(mv => mv.Member)
                   .WithMany(m => m.FinancialMovements)
                   .HasForeignKey(mv => mv.MemberId);

            builder.HasOne(mv => mv.AccountApplications)
                   .WithMany()
                   .HasForeignKey(mv => mv.AccountApplicationId);
        }
    }
}
