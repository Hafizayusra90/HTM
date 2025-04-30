using System;
using System.Collections.Generic;

namespace HTM.Models;

public partial class Paymentstatus
{
    public int Statusid { get; set; }

    public string Statusname { get; set; } = null!;

    public virtual ICollection<Payment> Payments { get; set; } = new List<Payment>();
}
