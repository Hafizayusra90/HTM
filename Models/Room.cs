using System;
using System.Collections.Generic;

namespace HTM.Models;

public partial class Room
{
    public int Roomid { get; set; }

    public decimal Roomno { get; set; }

    public int? Roomtypeid { get; set; }

    public int Floorno { get; set; }

    public decimal Pricepernight { get; set; }

    public int? Statusid { get; set; }

    public virtual ICollection<Booking> Bookings { get; set; } = new List<Booking>();

    public virtual ICollection<Housekeeping> Housekeepings { get; set; } = new List<Housekeeping>();

    public virtual Roomytype? Roomtype { get; set; }

    public virtual Roomstatus? Status { get; set; }
}
