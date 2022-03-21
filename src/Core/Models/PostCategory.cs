using System;
using System.Collections.Generic;

namespace Core.Models
{
    public partial class PostCategory
    {
        public int Id { get; set; }
        public int PostId { get; set; }
        public int CategoryId { get; set; }

    }
}
