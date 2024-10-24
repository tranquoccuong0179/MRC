﻿using System;
using System.Collections.Generic;

namespace Repository.Entity;

public partial class Service
{
    public Guid Id { get; set; }

    public string ServiceName { get; set; } = null!;

    public string? Description { get; set; }

    public decimal Price { get; set; }

    public int Duration { get; set; }

    public string Status { get; set; } = null!;

    public DateTime? InsDate { get; set; }

    public DateTime? UpDate { get; set; }

    public virtual ICollection<Booking> Bookings { get; set; } = new List<Booking>();
}