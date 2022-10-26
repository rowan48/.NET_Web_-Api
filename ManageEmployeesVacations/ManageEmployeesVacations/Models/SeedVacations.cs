﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ManageEmployeesVacations.Models
{
    public class SeedVacations : IEntityTypeConfiguration<Vacation>
    {


        public void Configure(EntityTypeBuilder<Vacation> builder)
        {
            builder.HasData
            (
                new Vacation
                {
                    VacationId = 1,
                    VacationName = "Schedule",
                    Balance = 14
                },
                new Vacation
                {
                    VacationId = 2,
                    VacationName = "Casual",
                    Balance = 7
                }
            );
        }
    }
}
