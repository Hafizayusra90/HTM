using System;
using System.Collections.Generic;

namespace HTM.Models;

public partial class Roomytype
{
    public int Roomtypeid { get; set; }

    public string Roomtypename { get; set; } = null!;

    public string Bedtype { get; set; } = null!;

    public virtual ICollection<Room> Rooms { get; set; } = new List<Room>();
}
