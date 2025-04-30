using System;
using System.Collections.Generic;

namespace HTM.Models;

public partial class Guest
{
    public int Guestid { get; set; }

    public string Guestname { get; set; } = null!;

    public decimal? Contactno { get; set; }

    public string? Email { get; set; }

    public string Address { get; set; } = null!;

    public virtual ICollection<Booking> Bookings { get; set; } = new List<Booking>();

    public virtual ICollection<Feedback> Feedbacks { get; set; } = new List<Feedback>();
}
