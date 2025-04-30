using System;
using System.Collections.Generic;

namespace HTM.Models;

public partial class Payment
{
    public int Paymentid { get; set; }

    public int? Bookingid { get; set; }

    public DateOnly Paymentdate { get; set; }

    public int? Paymentmethodid { get; set; }

    public decimal Amount { get; set; }

    public int? Statusid { get; set; }

    public virtual Booking? Booking { get; set; }

    public virtual Paymentmethod? Paymentmethod { get; set; }

    public virtual Paymentstatus? Status { get; set; }
}
