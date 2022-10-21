using System;
using System.Collections.Generic;

namespace StockManagement.Models
{
    public partial class Position
    {
        public Position()
        {
            LoginControls = new HashSet<LoginControl>();
        }

        public int PositionId { get; set; }
        public string PositionRole { get; set; } = null!;

        public virtual ICollection<LoginControl> LoginControls { get; set; }
    }
}
