using System;
using System.Collections.Generic;

namespace GenericImplementation.Api.Models
{
    [GeneratedController("api/endpoint")]
    public partial class endpoint
    {
        public int id { get; set; }
        public Guid row_id { get; set; }
        public int protocol_id { get; set; }
        public string name { get; set; } = null!;
        public string server_url { get; set; } = null!;
        public string setting { get; set; } = null!;
        public bool? status { get; set; }
        public bool deleted { get; set; }
        public int created_user { get; set; }
        public DateTime created_date { get; set; }
        public int? modified_user { get; set; }
        public DateTime? modified_date { get; set; }
        public int tenant_id { get; set; }
        public string audit { get; set; } = null!;

        public virtual protocol protocol { get; set; } = null!;
    }
}
