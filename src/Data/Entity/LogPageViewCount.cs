using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Entity
{
    public class LogPageViewCount
    {
        private string _endPoint;

        public string? UserName { get; set; }
        public string EndPoint
        {
            get => _endPoint;
            set => _endPoint = value.Length > 100 ? value[..100] : value;
        }

        public DateTime CreatedAt { get; set; }
        public int Count { get; set; }

    }
}
