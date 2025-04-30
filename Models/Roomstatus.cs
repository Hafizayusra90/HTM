using System;
using System.Collections.Generic;

namespace HTM.Models;

public partial class Roomstatus
{
    public int Statusid { get; set; }

    public string Statusname { get; set; } = null!;

    public virtual ICollection<Room> Rooms { get; set; } = new List<Room>();
}
