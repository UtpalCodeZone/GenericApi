using System;
using System.Collections.Generic;

namespace GenericImplementation.Api.Models
{
    [GeneratedController("api/protocol")]
    public partial class protocol
    {
        public protocol()
        {
            endpoints = new HashSet<endpoint>();
        }

        public int id { get; set; }
        public Guid row_id { get; set; }
        public string name { get; set; } = null!;
        public string code { get; set; } = null!;
        public bool? status { get; set; }
        public bool deleted { get; set; }
        public int created_user { get; set; }
        public DateTime created_date { get; set; }
        public int? modified_user { get; set; }
        public DateTime? modified_date { get; set; }
        public int tenant_id { get; set; }
        public string audit { get; set; } = null!;

        public virtual ICollection<endpoint> endpoints { get; set; }
    }
}
