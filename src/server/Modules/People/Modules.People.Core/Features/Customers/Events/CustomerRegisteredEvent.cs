﻿using FluentPOS.Shared.Core.Domain;
using System;
using FluentPOS.Modules.People.Core.Entities;

namespace FluentPOS.Modules.People.Core.Features.Customers.Events
{
    public class CustomerRegisteredEvent : Event
    {
        public Guid Id { get; }
        public string Name { get; }
        public string Phone { get; }
        public string Email { get; }
        public string ImageUrl { get; }
        public string Type { get; }

        public CustomerRegisteredEvent(Customer customer)
        {
            Name = customer.Name;
            Phone = customer.Phone;
            Email = customer.Email;
            ImageUrl = customer.ImageUrl;
            Type = customer.Type;
            Id = customer.Id;
            AggregateId = customer.Id;
        }
    }
}