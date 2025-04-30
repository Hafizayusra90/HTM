using System;
using System.Collections.Generic;

namespace HTM.Models;

public partial class Department
{
    public int Deptid { get; set; }

    public string Deptname { get; set; } = null!;

    public virtual ICollection<Staff> Staff { get; set; } = new List<Staff>();
}
