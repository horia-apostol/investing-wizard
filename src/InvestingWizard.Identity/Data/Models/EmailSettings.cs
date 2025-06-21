﻿namespace InvestingWizard.Identity.Data.Models
{
    public sealed class EmailSettings
    {
        public string? ApiKey { get; init; }
        public string? FromAddress { get; init; }
        public string? FromName { get; init; }
    }
}