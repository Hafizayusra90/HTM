using System;
using System.Collections.Generic;

namespace HTM.Models;

public partial class Bookingdate
{
    public int Bookingid { get; set; }

    public DateOnly Checkindate { get; set; }

    public DateOnly Checkoutdate { get; set; }
}
