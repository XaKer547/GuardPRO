﻿using GuardPRO.API7.Database.Models;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace GuardPRO.API7.Database.Models;

public class Invite
{
    public int Id { get; set; }

    [Column(TypeName = "DATE")]
    public DateTime Date { get; set; }
    public StatusInvite? Status { get; set; }
    public string? ReasonDeny { get; set; }

    public TimeSpan? TimeOut { get; set; }

    public int UserId { get; set; }
    public User User { get; set; }

    public Applicant Applicant { get; set; }
    public Group? Group { get; set; }
}

public enum StatusInvite
{
    CHECKING = 1,
    ACCEPT = 2,
    DENY = 3
}