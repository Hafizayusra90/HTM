using System;
using System.Collections.Generic;

namespace HTM.Models;

public partial class Booking
{
    public int Bookingid { get; set; }

    public int? Guestid { get; set; }

    public int? Roomid { get; set; }

    public int? Statusid { get; set; }

    public virtual Guest? Guest { get; set; }

    public virtual ICollection<Payment> Payments { get; set; } = new List<Payment>();

    public virtual Room? Room { get; set; }

    public virtual Bookingstatus? Status { get; set; }
}
