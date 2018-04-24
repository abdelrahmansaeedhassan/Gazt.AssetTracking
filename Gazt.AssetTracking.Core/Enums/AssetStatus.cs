using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace Gazt.AssetTracking.Core.Enums
{
    public enum AssetStatus : short
    {
        [Description("New asset")]
        New = 1,
        Assigned = 2,
        Damaged = 3,
        Lost = 4,
        Stock = 5
    }
}
