﻿using GH.WebUI.Core.Models;
using System.Data.Entity.ModelConfiguration;

namespace GH.WebUI.Persistence.EntityConfigurations
{
    public class NotificationConfiguration : EntityTypeConfiguration<Notification>
    {
        public NotificationConfiguration()
        {
            HasRequired(n => n.Gig);
        }
    }
}