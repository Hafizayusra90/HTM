using System;
using System.Collections.Generic;

namespace HTM.Models;

public partial class Feedback
{
    public int Feedbackid { get; set; }

    public int? Guestid { get; set; }

    public DateOnly Fbdate { get; set; }

    public int? Serviceid { get; set; }

    public decimal Rating { get; set; }

    public string Commentt { get; set; } = null!;

    public virtual Guest? Guest { get; set; }

    public virtual Service? Service { get; set; }
}
