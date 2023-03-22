using System;
using System.ComponentModel.DataAnnotations;

namespace GuardPRO.API7.DTO;

public class TimeChange
{
    [Required]
    public string? NewTime { get; set; } = null;
}
