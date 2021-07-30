﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using TaskoMask.Domain.Core.Models;
using TaskoMask.Domain.Core.Resources;

namespace TaskoMask.Domain.Entities
{
    [Display(Name = nameof(DomainMetadata.Organization), ResourceType = typeof(DomainMetadata))]
    public class Organization : BaseEntity
    {
        public Organization(string name, string description, string userId)
        {
            Name = name;
            Description = description;
            UserId = userId;
        }

        public string  Name { get; private set; }
        public string  Description { get; private set; }
        public string UserId { get; private set; }

        public void SetName(string name)
        {
            Name = name;
        }

        public void SetDescription(string description)
        {
            Description = description;
        }
    }
}
