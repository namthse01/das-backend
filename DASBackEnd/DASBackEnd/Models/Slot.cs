﻿using System;
using System.Collections.Generic;

namespace DASBackEnd.Models;

public partial class Slot
{
    public int Id { get; set; }

    public int? SlotNo { get; set; }

    public string? SlotStatus { get; set; }

    public DateTime? Date { get; set; }

    public string? DayInWeek { get; set; }

    public int? AccountId { get; set; }

    public string? DoctorName { get; set; }

    public virtual Account? Account { get; set; }

    public virtual ICollection<Booking> Bookings { get; } = new List<Booking>();
}
