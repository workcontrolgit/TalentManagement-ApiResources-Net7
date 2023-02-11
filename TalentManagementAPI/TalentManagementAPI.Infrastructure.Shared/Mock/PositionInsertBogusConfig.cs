﻿using Bogus;
using System;
using TalentManagementAPI.Domain.Entities;

namespace TalentManagementAPI.Infrastructure.Shared.Mock
{
    public class PositionInsertBogusConfig : Faker<Position>
    {
        public PositionInsertBogusConfig()
        {
            RuleFor(o => o.Id, f => Guid.NewGuid());
            RuleFor(o => o.PositionTitle, f => f.Name.JobTitle());
            RuleFor(o => o.PositionNumber, f => f.Commerce.Ean13());
            RuleFor(o => o.PositionDescription, f => f.Name.JobDescriptor());
            RuleFor(o => o.PositionSalary, f => f.Finance.Amount());
            RuleFor(o => o.Created, f => f.Date.Past(1));
            RuleFor(o => o.CreatedBy, f => f.Name.FullName());
            RuleFor(o => o.LastModified, f => f.Date.Recent(1));
            RuleFor(o => o.LastModifiedBy, f => f.Name.FullName());

        }
    }
}