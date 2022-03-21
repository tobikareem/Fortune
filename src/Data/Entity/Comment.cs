using System;
using System.Collections.Generic;

namespace Data.Entity
{
    public partial class Comment : Core.Models.Comment
    {
        public virtual Post Post { get; set; } = null!;
    }
}
