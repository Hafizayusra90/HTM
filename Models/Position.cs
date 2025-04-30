using System;
using System.Collections.Generic;

namespace HTM.Models;

public partial class Position
{
    public int Positionid { get; set; }

    public string Positionname { get; set; } = null!;

    public virtual ICollection<Staff> Staff { get; set; } = new List<Staff>();
}
