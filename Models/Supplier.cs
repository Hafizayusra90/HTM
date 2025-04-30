using System;
using System.Collections.Generic;

namespace HTM.Models;

public partial class Supplier
{
    public int Supplierid { get; set; }

    public string Suppliername { get; set; } = null!;

    public string Contactperson { get; set; } = null!;

    public decimal? Contactno { get; set; }

    public string? Email { get; set; }

    public string Address { get; set; } = null!;
}
