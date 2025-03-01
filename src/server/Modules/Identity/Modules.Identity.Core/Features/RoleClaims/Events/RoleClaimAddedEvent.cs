﻿using System;
using FluentPOS.Modules.Identity.Core.Entities;
using FluentPOS.Shared.Core.Domain;

namespace FluentPOS.Modules.Identity.Core.Features.RoleClaims.Events
{
    public class RoleClaimAddedEvent : Event
    {
        public int Id { get; }
        public string RoleId { get; }
        public string ClaimType { get; }
        public string ClaimValue { get; }
        public string Group { get; }
        public string Description { get; }

        public RoleClaimAddedEvent(FluentRoleClaim roleClaim)
        {
            RoleId = roleClaim.RoleId;
            Group = roleClaim.Group;
            ClaimType = roleClaim.ClaimType;
            ClaimValue = roleClaim.ClaimValue;
            Description = roleClaim.Description;
            Id = roleClaim.Id;
            AggregateId = Guid.NewGuid();
        }
    }
}