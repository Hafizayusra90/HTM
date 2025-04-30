using System;
using System.Collections.Generic;

namespace HTM.Models;

public partial class Paymentmethod
{
    public int Paymentmethodid { get; set; }

    public string Paymentmethodname { get; set; } = null!;

    public virtual ICollection<Payment> Payments { get; set; } = new List<Payment>();
}
