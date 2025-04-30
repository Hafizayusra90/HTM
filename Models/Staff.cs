using System;
using System.Collections.Generic;

namespace HTM.Models;

public partial class Staff
{
    public int Staffid { get; set; }

    public string Staffname { get; set; } = null!;

    public int? Positionid { get; set; }

    public int? Deptid { get; set; }

    public DateOnly Hiredate { get; set; }

    public decimal? Contactno { get; set; }

    public virtual Department? Dept { get; set; }

    public virtual Position? Position { get; set; }
}
