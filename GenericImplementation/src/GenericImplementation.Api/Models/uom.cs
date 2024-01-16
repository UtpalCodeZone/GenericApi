using System;
using System.Collections.Generic;

namespace GenericImplementation.Api.Models
{
    [GeneratedController("api/uom")]
    public partial class uom
    {
        public int id { get; set; }
        public Guid row_id { get; set; }
        public string name { get; set; } = null!;
        public string code { get; set; } = null!;
        public string? description { get; set; }
        public bool? status { get; set; }
        public bool deleted { get; set; }
        public int created_user { get; set; }
        public DateTime created_date { get; set; }
        public int? modified_user { get; set; }
        public DateTime? modified_date { get; set; }
        public int tenant_id { get; set; }
        public string audit { get; set; } = null!;
    }
}
