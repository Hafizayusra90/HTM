using System;
using System.Collections.Generic;

namespace HTM.Models;

public partial class Service
{
    public int Serviceid { get; set; }

    public string Servicename { get; set; } = null!;

    public string Description { get; set; } = null!;

    public decimal Price { get; set; }

    public string Available { get; set; } = null!;

    public virtual ICollection<Feedback> Feedbacks { get; set; } = new List<Feedback>();
}
