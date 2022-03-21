using System;
using System.Collections.Generic;

namespace Data.Entity
{
    public partial class PostCategory : Core.Models.PostCategory
    {
        public virtual Category Category { get; set; } = null!;
        public virtual Post Post { get; set; } = null!;
    }
}
