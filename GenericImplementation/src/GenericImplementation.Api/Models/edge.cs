using System;
using System.Collections.Generic;

namespace GenericImplementation.Api.Models
{
    [GeneratedController("api/edge")]
    public partial class edge
    {
        public int id { get; set; }
        public Guid row_id { get; set; }
        public int site_id { get; set; }
        public string name { get; set; } = null!;
        public string code { get; set; } = null!;
        public string? make { get; set; }
        public string? model { get; set; }
        public string? mac_id { get; set; }
        public string? ip_address { get; set; }
        public int os_id { get; set; }
        public string? comments { get; set; }
        public bool? status { get; set; }
        public bool deleted { get; set; }
        public DateTime created_date { get; set; }
        public DateTime? modified_date { get; set; }
        public int created_user { get; set; }
        public int? modified_user { get; set; }
        public int tenant_id { get; set; }
        public bool is_provisioned { get; set; }
        public string audit { get; set; } = null!;

        public virtual o os { get; set; } = null!;
    }
}
