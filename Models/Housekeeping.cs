using System;
using System.Collections.Generic;

namespace HTM.Models;

public partial class Housekeeping
{
    public int Taskid { get; set; }

    public int? Roomid { get; set; }

    public string Taskdescription { get; set; } = null!;

    public DateOnly Taskdate { get; set; }

    public virtual Room? Room { get; set; }
}
