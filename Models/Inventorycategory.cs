using System;
using System.Collections.Generic;

namespace HTM.Models;

public partial class Inventorycategory
{
    public int Categoryid { get; set; }

    public string Categoryname { get; set; } = null!;

    public virtual ICollection<Inventory> Inventories { get; set; } = new List<Inventory>();
}
