using System;
using System.Collections.Generic;

namespace HTM.Models;

public partial class Inventory
{
    public int Itemid { get; set; }

    public string Itemname { get; set; } = null!;

    public int? Categoryid { get; set; }

    public decimal Quantity { get; set; }

    public string Reorderlevel { get; set; } = null!;

    public decimal Unitcost { get; set; }

    public virtual Inventorycategory? Category { get; set; }
}
